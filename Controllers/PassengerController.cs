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
    public class PassengerController : Controller
    {
        private readonly VoyagerContext _context;

        public PassengerController(VoyagerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<PassengerVM> passengers = _context.Passengers.Select(q => new PassengerVM()
            {

                Email = q.Email,
                Name = q.Name,
                Password = q.Password,
                Surname = q.Surname
            }).ToList();
            return View(passengers);
        }

    }
}
