using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace ajax_notes.Controllers
{
    public class DjangoUpdateController : Controller
    {
        [HttpGet]
        [Route("updateDjango/{id}")]
        public IActionResult DjangoUpdate(int id, string title, string description)
        {
            return View();
        }

        [HttpPost]
        [Route("updateDjango/{id}")]
        public IActionResult updateDjango(int id, string title, string description)
        {
            string updateQuery = $"UPDATE django SET title = '{title}', description = '{description}' WHERE id = {id}";
            DbConnector.Execute(updateQuery);
            return RedirectToAction("DjangoUpdate");
        }

    }
}




