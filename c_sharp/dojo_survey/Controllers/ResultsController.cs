using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojo_survey.Controllers
{
    public class ResultsController : Controller
    {
        [HttpPost]
        [Route("/submit")]
        public IActionResult Results(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("Results");
        }
    }
}