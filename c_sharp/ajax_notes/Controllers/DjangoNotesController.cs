using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace ajax_notes.Controllers
{
    public class DjangoNotesController : Controller
    {
        [HttpGet]
        [Route("/DjangoNotes")]
        public IActionResult DjangoNotes()
        {
            List<Dictionary<string, object>> AllDjangoNotes = DbConnector.Query("SELECT * FROM django");
            ViewBag.DjangoNotes = AllDjangoNotes;
            return View();
        }

        [HttpPost]
        [Route("createDjango")]
        public IActionResult createDjango(string title, string description)
        {
            string stringTitle = '"' + title + '"';
            string stringDescription = '"' + description + '"';
            string query = $"INSERT INTO django(title, description, created_at)VALUES({stringTitle}, {stringDescription}, NOW());";
            DbConnector.Execute(query);
            return RedirectToAction("DjangoNotes");
        }
        [HttpGet]
         [Route("deleteDjango/{id}")]
        public IActionResult deleteDjango(int id)
        {   
            string query = $"DELETE FROM django WHERE(id = {id})";
            DbConnector.Execute(query);
            return RedirectToAction("DjangoNotes");
        }

       

    }
}

