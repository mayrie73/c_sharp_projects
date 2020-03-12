using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojo_league.Models;
using dojo_league.Factory;

namespace dojo_league.Controllers
{
    public class NinjaController : Controller
    { 
        private readonly DojoFactory dojoFactory;
        private readonly NinjaFactory ninjaFactory;
        public NinjaController(){
            ninjaFactory= new NinjaFactory();
            dojoFactory = new DojoFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.allDojos = dojoFactory.FindAll();
            ViewBag.allNinjas = ninjaFactory.FindAll();
            return View();
        }
        [HttpPost]
        [Route("addNinja")]
        public IActionResult addNinja(Ninja ninja)
        {
            if(ModelState.IsValid)
            {
                ninjaFactory.Add(ninja);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.allDojos = dojoFactory.FindAll();
                ViewBag.allNinjas = ninjaFactory.FindAll();
                return View("Index");
            }
        }
        [HttpGet]
        [Route("ninjas/{id}")]  
        public IActionResult ViewNinja(int id)
        {
            ViewBag.ninja = ninjaFactory.FindByID(id);
            return View("Ninja");
        }
    }
}
