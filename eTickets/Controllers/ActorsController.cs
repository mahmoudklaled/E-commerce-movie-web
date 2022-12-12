using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _services;
        

        public ActorsController(IActorsService services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var data =await _services.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {

            var data = await _services.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName" ,"ProfilePictureURL","Bio")]Actor actor)
        {

            if(!ModelState.IsValid) { 
                return View(actor); 
            }
            await _services.AddAsync(actor);
            return RedirectToAction("Index");
            //return View();
        }

        //Get : Actor /Deatils/id
        public async Task<IActionResult> Details(int id)
        {
            var actordetails = await _services.GetByIdAsync(id);
            if(actordetails == null)
            {
                return View("NotFound");
            }
            return View(actordetails);
        }

        // GEt Actor/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var actordetail = await _services.GetByIdAsync(id);
            if (actordetail == null) return View("NotFound");
            return View(actordetail);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id ,[Bind("id", "FullName", "ProfilePictureURL", "Bio")] Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _services.UpdateAsync(id , actor);
            return RedirectToAction("Index");
            //return View();
        }


        // GEt Actor/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var actordetail = await _services.GetByIdAsync(id);
            if (actordetail == null) return View("NotFound");
            return View(actordetail);
        }

        [HttpPost ,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfimed(int id)
        {

            var actordetail = await _services.GetByIdAsync(id);
            if (actordetail == null) return View("NotFound");
            await _services.DeleteAsync(id);
            return RedirectToAction("Index");
            //return View();
        }

    }
}
