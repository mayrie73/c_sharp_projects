using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using beltreview.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace beltreview.Controllers
{
    public class IdeasController : Controller
    {
        private BeltReviewContext _context;
        public IdeasController(BeltReviewContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("BrightIdeas")]
        public IActionResult Main()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.User = _context.Users.Where(u => u.UserId == (int)UserId).ToList().First();
            ViewBag.Ideas = _context.Ideas.Include(i => i.Likes).Include(i => i.user).OrderByDescending(i => i.Likes.Count).ToList();
            return View();
        }
        [HttpPost]
        [Route("IdeaNew")]
        public IActionResult IdeaNew(string IdeaText)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Idea idea = new Idea
            {
                IdeaText = IdeaText,
                UserId = (int)UserId,
            };
            _context.Add(idea);
            _context.SaveChanges();
            return RedirectToAction("Main");

        }
        [HttpGet]
        [Route("Ideas/users/{id}")]
        public IActionResult Ideacreate(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.User = _context.Users.Where(u => u.UserId == id).Include(u => u.Ideas).Include(u => u.Likes).ToList().First();
            return View("user");
        }
        [HttpGet]
      [Route("Ideas/like/{id}")]
        public IActionResult Likeidea(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Like like = new Like
            {
                UserId = (int)UserId,
                IdeaId = id,
            };
            _context.Likes.Add(like);
            _context.SaveChanges();
            return RedirectToAction("Main");
        }
        [HttpGet]
            [Route("Ideas/{id}")]
        public IActionResult Idea(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Idea = _context.Ideas.Where(i => i.IdeaId == id).Include(i => i.user).ToList().First();
            List<int> UserIds = _context.Likes.Include(i => i.User).Where(i => i.IdeaId == id).Select(i => i.UserId).Distinct().ToList();

            List<User> users = new List<User>();
            foreach (int UserLikeId in UserIds)
            {
                users.Add(_context.Users.Where(u => u.UserId == UserLikeId).ToList().First());
            }
            ViewBag.Users = users;

            return View();
        }
        [HttpGet]
       [Route("Ideas/delete/{id}")]
        public IActionResult delete(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Idea idea = _context.Ideas.Where(i => i.IdeaId == id).ToList().First();
            if (idea.UserId != (int)UserId)
            {
                return RedirectToAction("Main");
            }
            List<Like> Likes = _context.Likes.Where(i => i.IdeaId == id).ToList();
            foreach (Like Like in Likes)
            {
                _context.Likes.Remove(Like);
            }
            _context.Ideas.Remove(idea);
            _context.SaveChanges();
            return RedirectToAction("Main");
        }
    }
}
