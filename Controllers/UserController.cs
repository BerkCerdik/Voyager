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
    public class UserController : Controller
    {
        private readonly VoyagerContext _context;

        public UserController(VoyagerContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Passenger user = _context.Passengers.FirstOrDefault(x => x.ID == id);

            PassengerVM model = new PassengerVM();
            model.ID = user.ID;
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.Password = user.Password;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(PassengerVM model)
        {
            if (ModelState.IsValid)
            {
                Passenger user = _context.Passengers.FirstOrDefault(x => x.ID == model.ID);
                model.Name = user.Name;
                model.Surname = user.Surname;
                model.Email = user.Email;
                model.Password = user.Password;

                _context.SaveChanges();

                return RedirectToAction("Edit","User");
            }
            return View();
        }
    }
}
