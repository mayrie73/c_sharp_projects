using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserDashboard.Models;

namespace UserDashboard.Controllers
{
    public class WallController : Controller
    {
        private UserDashboardContext _context;

        public WallController(UserDashboardContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Wall/{id}")]
        public IActionResult Wall(int id)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                ViewBag.AllPosts = _context.Posts
                  .Include(p => p.User)
                  .OrderByDescending(p => p.CreatedAt)
                  .Include(p => p.Comment)
                    .ThenInclude(comment => comment.User)
                  .ToList();
                int? logId = HttpContext.Session.GetInt32("UserId");
                ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);

            }
            return View("Wall");
        }

        [HttpPost]
        [Route("PostMessage")]
        public IActionResult PostMessage(Post post)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                Post NewPost = new Post
                {
                    PostContent = post.PostContent,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = (int)HttpContext.Session.GetInt32("UserId")
                };
                _context.Posts.Add(NewPost);
                _context.SaveChanges();
                ViewBag.AllPosts = _context.Posts
                  .Include(p => p.User)
                  .OrderByDescending(p => p.CreatedAt)
                  .Include(p => p.Comment)
                    .ThenInclude(thisComment => thisComment.User)
                  .ToList();
                int? logId = HttpContext.Session.GetInt32("UserId");
                ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [Route("PostComment")]
        public IActionResult PostComment(string CommentContent, int PostId)
        {
            Console.WriteLine("Post ID is: " + PostId);
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                Comment NewComment = new Comment
                {
                    CommentContent = CommentContent,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    PostId = PostId,
                    UserId = (int)HttpContext.Session.GetInt32("UserId")
                };
                _context.Comments.Add(NewComment);
                _context.SaveChanges();
                ViewBag.AllPosts = _context.Posts
                  .Include(p => p.User)
                  .OrderByDescending(p => p.CreatedAt)
                  .Include(p => p.Comment)
                    .ThenInclude(thisComment => thisComment.User)
                  .ToList();
                int? logId = HttpContext.Session.GetInt32("UserId");
                ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}

