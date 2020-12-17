using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AdminPassengerController : BaseController
    {
        private readonly VoyagerContext _context;

        public AdminPassengerController(VoyagerContext context, IMemoryCache memoryCache) : base(context, memoryCache)
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
            Passenger passenger = _context.Passengers.FirstOrDefault(x => x.ID == id);

            PassengerVM model = new PassengerVM();
            model.Name = passenger.Name;
            model.Surname = passenger.Surname;
            model.Email = passenger.Email;

            return View(model);
        }
        public IActionResult Edit(int ID)
        {
            Passenger passenger = _context.Passengers.FirstOrDefault(x => x.ID == ID);

            PassengerVM model = new PassengerVM();
            model.Name = passenger.Name;
            model.Surname = passenger.Surname;
            model.Email = passenger.Email;
            model.ID = passenger.ID;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(PassengerVM model)
        {

            Passenger passenger = _context.Passengers.FirstOrDefault(q => q.ID == model.ID);
            passenger.Email = model.Email;

            _context.SaveChanges();

            return View(model);
        }

        


    }
}
