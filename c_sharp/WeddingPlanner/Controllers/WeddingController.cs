using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers{
    public class WeddingController : Controller{
        private WeddingContext _context;
        public WeddingController(WeddingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard(){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if(loggedInId == null){
                return RedirectToAction("Index", "User");
            }
            User currUser = new User(); 
            currUser = _context.Users.Include(u => u.Wedding).SingleOrDefault(user => user.UserId == loggedInId);
            ViewBag.currUser = currUser;
            List<int> weddingIds = new List<int>();
            foreach(var wedding in currUser.Wedding){
            weddingIds.Add(wedding.WeddingId);
            }
            ViewBag.Attending = weddingIds;
            ViewBag.AllWeddings = _context.Weddings.Include( w => w.Guests).ThenInclude(g => g.Guest).ToList();
            return View();
        }

        [HttpGet]
        [Route("Wedding")]
        public IActionResult WeddingForm(){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if(loggedInId == null){
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        [HttpPost]
        [Route("PostWedding")]
        public IActionResult addWedding(WeddingViewModel model){
            if(ModelState.IsValid){
                if(model.Date < DateTime.Today){
                    ModelState.AddModelError("date", "Date Cannot be set to future date!");
                    return View("Wedding", model);
                }
                Wedding NewWedding = new Wedding{
                    Bride = model.Bride,
                    Groom = model.Groom,
                    Date = model.Date,
                    UserId = (int) HttpContext.Session.GetInt32("CurrUser"),
                    Address = model.Address
                };
                _context.Add(NewWedding);
                _context.SaveChanges();
                return RedirectToAction("Wedding", new {Id = NewWedding.WeddingId});
            }
            return View("WeddingForm");
        }
        
        [HttpGet]
        [Route("UpdateWedding/{Id}")]
        public IActionResult UpdateWedding(int Id){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if(loggedInId == null){
                return RedirectToAction("Index", "User");
            }else{
            Wedding wedding = new Wedding();
            wedding = _context.Weddings.Where(w => w.WeddingId == Id).Include(w => w.Guests).ThenInclude(g => g.Guest).SingleOrDefault();
            
            return View("UpdateWedding", wedding);
            }
        }

        [HttpPost]
        [Route("UpdateWedding/{Id}")]
        public IActionResult UpdateWedding(WeddingViewModel model){
            
            Wedding UpdatingWedding = _context.Weddings.Where(w => w.WeddingId == model.WeddingId).FirstOrDefault();
                if(UpdatingWedding != null){
                UpdatingWedding.Bride = model.Bride;
                UpdatingWedding.Groom = model.Groom;
                UpdatingWedding.Date = model.Date;
                UpdatingWedding.UserId = (int) HttpContext.Session.GetInt32("CurrUser");
                UpdatingWedding.Address = model.Address;

                _context.Update(UpdatingWedding);
                _context.SaveChanges();               
                return RedirectToAction("Wedding", new {Id = UpdatingWedding.WeddingId});
        }
        return RedirectToAction("Wedding", model);
        }


        [HttpGet]
        [Route("Wedding/{Id}")]
        public IActionResult Wedding(int Id){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if(loggedInId == null){
                return RedirectToAction("Index", "User");
            }
            Wedding Wedding = new Wedding();
            Wedding = _context.Weddings.Include(w => w.Guests).ThenInclude(g => g.Guest).SingleOrDefault(w => w.WeddingId == Id);
            ViewBag.mapstring ="https://maps.googleapis.com/maps/api/staticmap?center=";
            ViewBag.mapstring += Wedding.Address.Replace(" ", ""); 
            ViewBag.mapstring += "&markers=color:Red%7C";
            ViewBag.mapstring += Wedding.Address.Replace(" ", "");
            ViewBag.mapstring += "&size=150x150&zoom=15&key=AIzaSyCaHab6VlVEjcTPh7SFtXMyOL0zdbqHiRc";
            return View(Wedding);
        }
        [HttpGet]
        [Route("delWedding/{Id}")]
        public IActionResult delWedding(int Id){
            Wedding Wed = _context.Weddings.Where(w => w.WeddingId == Id).FirstOrDefault();
            if(Wed != null)
            {
                _context.Remove(Wed);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
                return RedirectToAction("Dashboard");
            
        }
        [HttpGet]
        [Route("RSVP/{Id}")]
        public IActionResult RSVP(int Id){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            GuestList NewConnection = new GuestList{
                GuestId = (int)loggedInId,
                WeddingId =Id
            };
            _context.Guests.Add(NewConnection);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        [Route("UnRSVP/{Id}")]
        public IActionResult UnRSVP(int Id){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            GuestList retrievedConnection = _context.Guests.SingleOrDefault( g => g.GuestId == loggedInId && g.WeddingId == Id);
            _context.Guests.Remove(retrievedConnection);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }   
}