using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Home()
        {
            TempData["gameStatus"] = "playing";
            int? happiness = HttpContext.Session.GetInt32("happiness");
            if (happiness == null)
            {
                HttpContext.Session.SetInt32("happiness", 20);
                TempData["message"] = "Welcome to the Dojodachi Game!!!";
            }
            int? fullness = HttpContext.Session.GetInt32("fullness");
            if (fullness == null)
            {
                HttpContext.Session.SetInt32("fullness", 20);
            }
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy == null)
            {
                HttpContext.Session.SetInt32("energy", 50);
            }
            int? meals = HttpContext.Session.GetInt32("meals");
            if (meals == null)
            {
                HttpContext.Session.SetInt32("meals", 3);
            }
            if(fullness == 0 || happiness == 0)
            {
                TempData["gameStatus"] = "over";
                TempData["message"] = "Sad News!! Your Dodachi has died.";
            }
            else if(energy >= 100 && fullness >= 10 && happiness >=100)
            {
                TempData["gameStatus"] = "over";
                TempData["message"] = "Congratulations, you won!!";
            }
            TempData["happiness"] = HttpContext.Session.GetInt32("happiness");
            TempData["fullness"] = HttpContext.Session.GetInt32("fullness");
            TempData["energy"] = HttpContext.Session.GetInt32("energy");
            TempData["meals"] = HttpContext.Session.GetInt32("meals");
            return View();
        }
        [Route("/feed")]
        [HttpGet]
        public IActionResult Feed()
        {
            if (HttpContext.Session.GetInt32("meals") > 0)
            {
                int? meals = HttpContext.Session.GetInt32("meals") - 1;
                HttpContext.Session.SetInt32("meals", (int)meals);
                Random chance = new Random();
                int liked = chance.Next(1, 5);
                if (liked == 1)
                {
                    TempData["message"] = "Your Dojodachi does not like the meal";
                }
                else
                {
                    Random rand = new Random();
                    int fill = rand.Next(5, 11);
                    int? fullness = HttpContext.Session.GetInt32("fullness") + fill;
                    HttpContext.Session.SetInt32("fullness", (int)fullness);
                    TempData["message"] = $"Your Dojodachi's fullness increased by {fill} points";
                }
            }
            else
            {
                TempData["message"] = "You have no meals!";
            }

            return RedirectToAction("Home");
        }
        [Route("/play")]
        [HttpGet]
        public IActionResult Play()
        {
            if (HttpContext.Session.GetInt32("energy") >= 5)
            {
                int? energy = HttpContext.Session.GetInt32("energy") - 5;
                HttpContext.Session.SetInt32("energy", (int)energy);
                Random chance = new Random();
                int liked = chance.Next(1, 5);
                if (liked == 1)
                {
                    TempData["message"] = "Your Dojodachi does not want to play";
                }
                else
                {
                    Random rand = new Random();
                    int increase = rand.Next(5, 11);
                    int? happiness = HttpContext.Session.GetInt32("happiness");
                    HttpContext.Session.SetInt32("happiness", (int)happiness + increase);
                    TempData["message"] = $"Your Dojodachi increased its happiness by {increase}";
                }
            }
            else
            {
                TempData["message"] = "Your Dojodachi doesn't have enough energy to play";
            }
            return RedirectToAction("Home");
        }
        [Route("/work")]
        [HttpGet]
        public IActionResult Work()
        {
            int? energy = HttpContext.Session.GetInt32("energy");
            if(energy < 5)
            {
                TempData["message"] = "Your Dojodachi doesn't have enough energy to work";
            }
            else{
                HttpContext.Session.SetInt32("energy", (int)energy -5);
                Random rand = new Random();
                int gain = rand.Next(1,4);
                int? meals = HttpContext.Session.GetInt32("meals");
                HttpContext.Session.SetInt32("meals",(int)meals + gain);
                TempData["message"] = $"Your Dojodachi earned {gain} meals";
            }
            return RedirectToAction("Home");
        }
        [Route("/sleep")]
        [HttpGet]
        public IActionResult Sleep()
        {
            int? energy = HttpContext.Session.GetInt32("energy");
            HttpContext.Session.SetInt32("energy", (int)energy +15);
            int? fullness = HttpContext.Session.GetInt32("fullness") -5;
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            int? happiness = HttpContext.Session.GetInt32("happiness")-5;
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            TempData["message"] = "Your Dojodachi gained 15 energy points, lost 5 fullness and 5 happiness points";
            return RedirectToAction("Home");
        }
        [Route("/restart")]
        [HttpGet]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Home");
        }
    }
}
