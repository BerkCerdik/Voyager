using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;

namespace Voyager.Controllers
{
    public class DriverController : Controller
    {

        private readonly VoyagerContext _context;
        public DriverController(VoyagerContext context)
        {
            _context = context;
        }

    
        public IActionResult Index()
        {
            List<Driver> drivers = _context.Drivers.ToList();
            return View(drivers);
        }

    }
}
