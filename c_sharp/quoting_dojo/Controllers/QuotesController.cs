using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
namespace quoting_dojo.Controllers
{
    public class QuotesController : Controller
    {
        [HttpGet]
        [Route("/quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            ViewBag.Users = AllUsers;
            return View();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult create(string name, string quote)
        {
            string stringName = '"' + name + '"';
            string stringQuote = '"' + quote + '"';
            string query = $"INSERT INTO users(name, quote , created_at)VALUES({stringName}, {stringQuote}, NOW());";
            DbConnector.Execute(query);
            return RedirectToAction("Quotes");
        }



    }
}