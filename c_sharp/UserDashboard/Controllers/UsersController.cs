using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserDashboard.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace UserDashboard.Controllers
{
    public class UsersController : Controller
    {
        private UserDashboardContext _context;
        public UsersController(UserDashboardContext context)
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
        [Route("processregister")]
        public IActionResult ProcessRegister(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User currUser = _context.Users.SingleOrDefault(user => user.Email == model.Email);

                if (currUser != null)
                {
                    ModelState.AddModelError("email", "Email is already registered");
                    return View("Index", model);
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
            return View("Index", model);
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            ViewBag.Login = new LoginViewModel();
            return View();

        }

        [HttpPost]
        [Route("processLogin")]
        public IActionResult ProcessLogin(LoginViewModel model)
        {
            User currUser = _context.Users.SingleOrDefault(user => user.Email == model.Email);
            if (currUser != null && model.Password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if (0 != Hasher.VerifyHashedPassword(currUser, currUser.Password, model.Password))
                {
                    HttpContext.Session.SetInt32("CurrUser", currUser.UserId);
                    ViewBag.currUser = currUser;
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("password", "Incorrect Password");
                }
            }
            else if (currUser == null)
            {
                ModelState.AddModelError("email", "Email Not Found");
            }
            return View("Login");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
