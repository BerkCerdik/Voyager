using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Voyager.Models;
using Voyager.Models.Enums;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AdminDriverController : BaseController
    {
        private readonly VoyagerContext _context;
        

        public AdminDriverController(VoyagerContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<DriverVM> drivers = _context.Drivers.Where(q => q.IsDeleted == false).Select(q => new DriverVM()
            {
                ID=q.ID,
                Email = q.Email,
                Name = q.Name,
                Password = q.Password,
                Surname = q.Surname

            }).ToList();

            return View(drivers);
        }

        //[RoleControl(EnumRoles.AdminUserList)]
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
                driver.Password = model.Password;
                _context.Drivers.Add(driver);
                _context.SaveChanges();
                return RedirectToAction("Index", "AdminDriver");
            }

                return View();


        }

        public IActionResult Edit(int id)
        {

            Driver driver = _context.Drivers.FirstOrDefault(x => x.ID == id);

            DriverVM model = new DriverVM();
            model.Name = driver.Name;
            model.Password = driver.Password;
            model.Surname = driver.Surname;
            model.Email = driver.Email;
            model.CarPlate = driver.Plate;
            model.DriverLicense = driver.Experience;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DriverVM model)
        {
            Driver driver = _context.Drivers.FirstOrDefault(x => x.ID == model.ID);

            if (ModelState.IsValid)
            {
                driver.Name = model.Name;
                driver.Surname = model.Surname;
                driver.Experience = model.DriverLicense;
                driver.Email = model.Email;
                driver.Password = model.Password;
                driver.Plate = model.CarPlate;
                _context.SaveChanges();
                return View(model);
            }
            return RedirectToAction("Index","AdminDriver");
        }

        public IActionResult Detail(int id)
        {
            Driver driver = _context.Drivers.FirstOrDefault(x => x.ID == id);

            DriverVM model = new DriverVM();
            model.Name = driver.Name;
            model.Surname = driver.Surname;
            model.Email = driver.Email;
            model.Password = driver.Password;
            model.CarPlate = driver.Plate;

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Driver driver = _context.Drivers.FirstOrDefault(x => x.ID == id);

            driver.IsDeleted = true;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
