using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace ajax_notes.Controllers
{
    public class PythonNotesController : Controller
   {
        [HttpGet]
        [Route("/PythonNotes")]
        public IActionResult PythonNotes()
        {
            List<Dictionary<string, object>> AllPythonNotes = DbConnector.Query("SELECT * FROM python");
            ViewBag.PythonNotes = AllPythonNotes;
            return View();
        }
       
        [HttpPost]
        [Route("createPython")]
        public IActionResult createPython(string title, string description)
        {
            string stringTitle = '"' + title + '"';
            string stringDescription = '"' + description + '"';
            string query = $"INSERT INTO python(title, description, created_at)VALUES({stringTitle}, {stringDescription}, NOW());";
            DbConnector.Execute(query);
            return RedirectToAction("PythonNotes");
        }
        [HttpGet]
        [Route("deletePython/{id}")]
        public IActionResult deletePython(int id)
        {   
            string query = $"DELETE FROM python WHERE(id = {id})";
            DbConnector.Execute(query);
            return RedirectToAction("PythonNotes");
        }

        [HttpPost]
        [Route("/updatePython")]
        public IActionResult updatePython(int id, string title, string description )
        {
            string updateQuery =  $"UPDATE python SET title = {title}, description = '{description}' WHERE id = {id}";
            DbConnector.Execute(updateQuery);
            return RedirectToAction("PythonNotes");
        }
    }
}