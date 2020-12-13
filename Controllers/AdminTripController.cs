using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Controllers
{
    public class AdminTripController : Controller
    {
        
            private readonly VoyagerContext _context;

            public AdminTripController(VoyagerContext context)
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
            Trip trip = _context.Trips.FirstOrDefault(x => x.ID == id);
            TripVM model = new TripVM();
            model.PassengerName = trip.Passenger.Name;
            model.PassengerLastname = trip.Passenger.Surname;
            model.DriverName = trip.Driver.Name;
            model.DriverLastname = trip.Driver.Surname;
            model.Price = trip.Payment.Price;
            model.DeparturePoint = trip.DeparturePoint;
            model.ArrivalPoint = trip.ArrivalPoint;


            return View(model);
        }
    }
}
