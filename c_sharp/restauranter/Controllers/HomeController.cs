using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using restauranter.Models;
using System.Linq;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _context;

        public HomeController(ReviewContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("addReview")]
        public IActionResult AddReview(Review newReview)
        {
            _context.Add(newReview);
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }
        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Review> allReviews = _context.Reviews.ToList();
            ViewBag.Reviews = allReviews;
            return View("Reviews");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult DeleteReview(int id)
        {
            Review reviewToDelete = _context.Reviews.SingleOrDefault(r => r.ReviewId == id);
            _context.Remove(reviewToDelete);
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }
    }
}
