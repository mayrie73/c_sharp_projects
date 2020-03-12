using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class UsersController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(string first_name, string last_name, int age, string email, string password)
        {
            var user = new User
            {
                first_name = first_name,
                last_name = last_name,
                age = age,
                email = email,
                password = password
            };
            if (TryValidateModel(user) == false)
            {
                ViewBag.errors = ModelState.Values;
                return View("Error");
            }

            return RedirectToAction("Success");
        }
        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            return View();
        }

    }
}
