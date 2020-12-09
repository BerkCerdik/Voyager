using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Controllers
{
    public class AdminPassengerController : Controller
    {
        private readonly VoyagerContext _context;

        public AdminPassengerController(VoyagerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<PassengerVM> passengers = _context.Passengers.Select(q => new PassengerVM()
            {
                ID= q.ID,
                Email = q.Email,
                Name = q.Name,
                Password = q.Password,
                Surname = q.Surname

            }).ToList();

            return View(passengers);
        }

        public IActionResult PassengerDetail(int id)
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int ID)
        {
            Passenger passenger = _context.Passengers.FirstOrDefault(x => x.ID == ID);

            return RedirectToAction("Index", "AdminPassenger");
        }


    }
}
