using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Controllers
{
    public class HomeController : Controller
    {
        private readonly VoyagerContext _context;

        public HomeController(VoyagerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM model = new HomeVM();
            model.Destination = "";
            model.Source = "";
            model.Drivers = _context.Drivers.Where(q => q.IsDeleted == false).OrderBy(q => q.Name).ToList();
            

            return View(model);
        }

        [HttpPost]
        public IActionResult Booking(HomeVM model)
        {
            //Kullanıcı loginse işlemi yap değilse login sayfasına yönlendir!!

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                Payment payment = new Payment();
                payment.Price = 10;
                _context.Payments.Add(payment);
                _context.SaveChanges();


                int passengerid = Convert.ToInt32(HttpContext.User.Claims.ToArray()[0].Value);
                Trip trip = new Trip();
                trip.DriverID = model.DriverID;
                trip.DeparturePoint = model.Source;
                trip.ArrivalPoint = model.Destination;
                trip.PassengerID = passengerid;
                trip.PaymentID = payment.ID;

               

                _context.Trips.Add(trip);
                _context.SaveChanges();
                TempData["message"] = "Booking işlemi başarılı!";
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Index", "passengerlogin");
            }
           
        }
    }
}
