using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Voyager.Models.Orm.Context;
using Voyager.Models.Vm;

namespace Voyager.Controllers
{
    public class TripController : Controller
    {

        private readonly VoyagerContext _context;

        public TripController(VoyagerContext context)
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

    }
}
