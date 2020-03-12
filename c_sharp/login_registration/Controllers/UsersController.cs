using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using login_registration.Models;


namespace login_registration.Controllers
{
    public class UsersController : Controller
    {
        private readonly DbConnector _dbConnector;

        public UsersController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.email = "";
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                string validateEmail = $"SELECT * FROM users WHERE(email = '{model.email}')";
                var emailExists = _dbConnector.Query(validateEmail);
                if (emailExists.Count == 0)
                {
                    string query = $"INSERT INTO users(first_name, last_name, email, password, created_at)VALUES('{model.first_name}', '{model.last_name}', '{model.email}', '{model.password}', NOW())";
                    _dbConnector.Execute(query);
                    HttpContext.Session.SetString("user", model.first_name);
                    var sessionQuery = _dbConnector.Query(validateEmail);
                    int sessionId = (int)sessionQuery[0]["id"];
                    return RedirectToAction("Success");
                }
                else
                {

                    ViewBag.email = "This email already exists";
                    return View("Index");
                }

            }
            else
            {
                ViewBag.email = "";
                return View("Index");
            }

        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            string user = HttpContext.Session.GetString("user");
            ViewBag.user = user;
            return View();
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            ViewBag.email = "";
            ViewBag.password = "";
            return View();
        }

        [HttpPost]
        [Route("loggedIn")]
        public IActionResult LoggedIn(Login model)
        {
            if (ModelState.IsValid)
            {
                string query = $"SELECT * FROM users WHERE(email = '{model.email}')";
                var exists = _dbConnector.Query(query);
                if (exists.Count == 0)
                {
                    ViewBag.email = "Email not found";
                    return View("Login");
                }
                else
                {
                    string password = (exists[0]["password"]).ToString();
                    if (password != model.password)
                    {
                        ViewBag.password = "Invalid password!";
                        return View("Login");
                    }
                    else
                    {
                        int id = (int)exists[0]["id"];
                        HttpContext.Session.SetInt32("id", id);
                        string first_name = (exists[0]["first_name"]).ToString();
                        HttpContext.Session.SetString("user", first_name);
                        return RedirectToAction("Success");
                    }
                }
            }
            else
            {
                ViewBag.email = "";
                ViewBag.password = "";
                return View("Login");
            }
        }
    }
}
