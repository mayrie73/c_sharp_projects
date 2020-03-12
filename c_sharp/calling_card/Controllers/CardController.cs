using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class CardController : Controller
    {
        [HttpGet]
        [Route("/{FirstName}/{LastName}/{Age}/{FavoriteColor}")]
        public JsonResult DisplayInt(string FirstName, string LastName, int Age, string FavoriteColor)
        {
            var person = new
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                FavoriteColor = FavoriteColor
            };
            return Json(person);
        }
    }
}