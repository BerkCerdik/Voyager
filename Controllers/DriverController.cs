using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

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
            List<DriverVM> drivers = _context.Drivers.Select(q => new DriverVM()
            {

                Email = q.Email,
                Name = q.Name,
                Password = q.Password,
                Surname = q.Surname
            }).ToList(); 
            return View(drivers);
        }

    }
}
