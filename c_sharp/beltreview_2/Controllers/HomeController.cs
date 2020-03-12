using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using beltreview.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace beltreview.Controllers
{
    public class HomeController : Controller
    {
        private BeltReviewContext _context;
        public HomeController(BeltReviewContext context)
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
        [Route("Register")]
        public IActionResult Register(RegisterViewModel model)
        {

            System.Console.WriteLine(ModelState.IsValid);
            int num = _context.Users.Where(u => u.Email == model.Email).ToList().Count;
            System.Console.WriteLine(num);
            if (num != 0)
            {
                ViewBag.error = "Email already exists";
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    Alias = model.Alias,
                    Email = model.Email,
                    Password = model.Password,
                };
                System.Console.WriteLine(user.CreatedAt);
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                System.Console.WriteLine(user.Password);
                _context.Add(user);
                _context.SaveChanges();
                System.Console.WriteLine(user.UserId);
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Main", "Ideas");
            }
            return View("Index");
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("processLogin")]
        public IActionResult ProcessLogin(LoginViewModel model)
        {
            if (model.Password == null)
            {
                ViewBag.LoginError = "Password cannot be blank";
                return View("Login");
            }
            List<User> userlist = _context.Users.Where(u => u.Email == model.Email).ToList();
            if (userlist.Count == 0)
            {
                ViewBag.LoginError = "Enter a valid email";
                return View("Login");
            }
            User user = userlist.First();
            var Hasher = new PasswordHasher<User>();
            if (Hasher.VerifyHashedPassword(user, user.Password, model.Password) != 0)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Main", "Ideas");
            }
            ViewBag.LoginError = "Password is Invalid";
            return View("Login");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
