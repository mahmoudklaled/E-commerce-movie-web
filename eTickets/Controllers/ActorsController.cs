using eTickets.Data;
using eTickets.Data.Services;
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
    }
}
