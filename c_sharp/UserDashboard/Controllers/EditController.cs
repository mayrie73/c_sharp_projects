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
    public class EditController : Controller
    {

        private UserDashboardContext _context;

        public EditController(UserDashboardContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("EditUser/{id}")]
        public IActionResult EditUser(int Id)
        {
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if (loggedInId == null)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                User CurrentUser = _context.Users.SingleOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("CurrUserId"));
                ViewBag.User = CurrentUser;
                ViewBag.EditUser = _context.Users.Where(u => u.UserId == Id).SingleOrDefault();
                return View("EditUser");
            }
        }
        /*public IActionResult EditUser(int id) {
            User CurrentUser = _context.Users.SingleOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("CurrUserId"));
            ViewBag.User = CurrentUser;
            ViewBag.EditUser = _context.Users.SingleOrDefault(u => u.UserId == id);
            ViewBag.Errors = TempData["Errors"];
            return View("EditUser");*/

        [HttpPost]
        [Route("EditUser/{id}")]
        public IActionResult EditUser(int id, User model)
        {
            User CurrentUser = _context.Users.SingleOrDefault(u => u.UserId == id);
            ViewBag.User = CurrentUser;

            System.Console.WriteLine(model.AccessLevel);

            CurrentUser.FirstName = model.FirstName;
            CurrentUser.LastName = model.LastName;
            CurrentUser.Email = model.Email;
            CurrentUser.AccessLevel = model.AccessLevel;
            CurrentUser.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "Dashboard");
        }

        [HttpPost]
        [Route("UpdatePassword/{id}")]
        public IActionResult UpdatePassword(int id, string Password, String PasswordConfirm)
        {
            User CurrentUser = _context.Users.SingleOrDefault(u=> u.UserId == id);

            ViewBag.User = CurrentUser;

            var Hasher = new PasswordHasher<User>();
            // Check if passwords match then add to DB
            if (Password == PasswordConfirm)
            {
                CurrentUser.Password = Password;
                CurrentUser.Password = Hasher.HashPassword(CurrentUser, CurrentUser.Password);
                CurrentUser.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Dashboard", "Dashboard");
            }
            // If password match fails
            return RedirectToAction("EditUser");
        }


    }
}