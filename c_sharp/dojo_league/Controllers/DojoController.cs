using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojo_league.Models;
using dojo_league.Factory;

namespace dojo_league.Controllers
{
    public class DojoController : Controller
    { 
        private readonly DojoFactory dojoFactory;
        private readonly NinjaFactory ninjaFactory;
        public DojoController(){
            ninjaFactory= new NinjaFactory();
            dojoFactory = new DojoFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("AllDojos")]
        public IActionResult AllDojos()
        {
            ViewBag.allDojos = dojoFactory.FindAll();
            ViewBag.allNinjas = ninjaFactory.FindAll();
            return View();
        }
        [HttpPost]
        [Route("addDojo")]
        public IActionResult addDojo(Dojo dojo)
        {
            if(ModelState.IsValid)
            {
                dojoFactory.Add(dojo);
                return RedirectToAction("AllDojos");
            }
            else
            {
                ViewBag.allDojos = dojoFactory.FindAll();
                ViewBag.allNinjas = ninjaFactory.FindAll();
                return View("AllDojos");
            }
        }
        [HttpGet]
        [Route("dojos/{id}")]  
        public IActionResult ViewDojo(int id)
        {
            ViewBag.dojo = dojoFactory.FindByID(id);
            return View("Dojo");
        }
    }
}
