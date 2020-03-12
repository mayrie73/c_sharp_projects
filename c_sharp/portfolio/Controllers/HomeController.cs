using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        [Route("")]
        public IActionResult Home() {
            return View();
        }
    }
}