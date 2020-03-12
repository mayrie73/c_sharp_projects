using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserDashboard.Models;

namespace UserDashboard.Controllers
{
    public class AddController : Controller
    {

        private UserDashboardContext _context;

        public AddController(UserDashboardContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("addNew")]
        public IActionResult AddUser()
        {
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if (loggedInId == null)
            {
                return RedirectToAction("AddUser", "Add");
            }
            return View();
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User currUser = _context.Users.SingleOrDefault(user => user.Email == model.Email);

                if (currUser != null)
                {
                    ModelState.AddModelError("email", "Email is already registered");
                    return View("AddUser", model);
                }
                User newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                };
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                currUser = _context.Users.SingleOrDefault(user => user.Email == newUser.Email);
                ViewBag.currUser = currUser;
                HttpContext.Session.SetInt32("CurrUser", currUser.UserId);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            return View("AddUser", model);


        }
    }

}