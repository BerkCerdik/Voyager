using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AdminTripController : BaseController
    {
        
            private readonly VoyagerContext _context;

            public AdminTripController(VoyagerContext context, IMemoryCache memoryCache) : base(context, memoryCache)
            {
                _context = context;
            }
        public IActionResult Index()
        {
                   

            List<TripVM> trips = _context.Trips.Include(x => x.Payment).Include(a => a.Passenger).Include(b => b.Driver).Select(q => new TripVM()
            {
                ID = q.ID,
                PassengerName = q.Passenger.Name,
                PassengerLastname = q.Passenger.Surname,
                DriverName = q.Driver.Name,
                DriverLastname = q.Driver.Surname,
                Price = q.Payment.Price,
                DeparturePoint = q.DeparturePoint,
                ArrivalPoint = q.ArrivalPoint


            }).ToList();

            return View(trips);
        }

        public IActionResult TripDetails(int id)
        {
            TripVM trip = _context.Trips.Include(a => a.Passenger).Include(b => b.Driver).Include(c => c.Payment ).Select(q => new TripVM()
            {
                ID = q.ID,
                ArrivalPoint = q.ArrivalPoint,
                DeparturePoint = q.DeparturePoint,
                PassengerName = q.Passenger.Name,
                PassengerLastname = q.Passenger.Surname,
                DriverName = q.Driver.Name,
                DriverLastname = q.Driver.Surname,
                Price = q.Payment.Price


            }).FirstOrDefault(x => x.ID == id);

            return View(trip);
        }
    }
}
