using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;

namespace Voyager.Controllers
{
    public class PassengerController : Controller
    {
        private readonly VoyagerContext _context;

        public PassengerController(VoyagerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Passenger> passengers = _context.Passengers.ToList();
            return View(passengers);
        }
        
    }
}
