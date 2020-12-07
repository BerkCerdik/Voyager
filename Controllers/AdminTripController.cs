using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Vm;
using Voyager.Models.Orm.Entities;

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
            List<TripVM> trips = _context.Trips.Select(q => new TripVM()
            {
                ID = q.ID,
                PassengerID = q.PassengerID,
                DriverID = q.DriverID,
                DeparturePoint = q.DeparturePoint,
                ArrivalPoint = q.ArrivalPoint,
               //Price eklenecek

            }).ToList();

            return View(trips);
            
        }
    }
}
