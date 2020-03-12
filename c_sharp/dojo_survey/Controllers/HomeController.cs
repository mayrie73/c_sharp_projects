using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace dojo_survey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View();
        }
    }
}