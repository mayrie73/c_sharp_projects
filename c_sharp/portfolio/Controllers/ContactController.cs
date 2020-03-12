using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers {
    public class ContactController : Controller {
        [HttpGet]
        [Route("/contact")]
        public IActionResult Contact() {
            return View("Contact");
        }
    }
}