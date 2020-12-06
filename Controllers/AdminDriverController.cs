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
    public class AdminDriverController : Controller
    {
        private readonly VoyagerContext _context;
        public AdminDriverController(VoyagerContext context)
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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DriverVM model)
        {
            if (ModelState.IsValid)
            {
                Driver driver= new Driver();
                driver.Name = model.Name;
                driver.Surname = model.Surname;
                driver.Experience = model.DriverLicense;
                driver.Email = model.Email;
                driver.Password = model.Password;
                driver.Plate = model.CarPlate;
                _context.Drivers.Add(driver);
                _context.SaveChanges();
            }

           return RedirectToAction("Index","AdminDriver");
        }

        public IActionResult DriverDetail(int id)
        {
            Driver driver= _context.Drivers.FirstOrDefault(x => x.ID == id);

            return Json(driver);
        }


    }
}
