using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Controllers
{
    public class PassengerLoginController : Controller
    {
        private readonly VoyagerContext _context;

        public PassengerLoginController(VoyagerContext context, IMemoryCache memoryCache)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(PassengerLoginVM model)
        {
            if (ModelState.IsValid)
            {
                var passenger = _context.Passengers.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);


                if (passenger != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Email),
                    //new Claim(ClaimTypes.Role,model.Roles)
                };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    /*passenger.LastLoginDate = DateTime.Now*/;
                    _context.SaveChanges();

                    return RedirectToAction("Home", "AdminArea");
                }
                else
                {
                    ViewBag.error = "E-Mail or Password wrong!";
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PassengerLoginVM model)
        {
            if (ModelState.IsValid)
            {
                Passenger passenger = new Passenger();
                passenger.Name = model.Name;
                passenger.Surname = model.Surname;
                passenger.Email = model.Email;
                passenger.Password = model.Password;
                passenger.Password = model.Password;
                _context.Passengers.Add(passenger);
                _context.SaveChanges();
                return RedirectToAction("Index", "PassengerLogin");
            }

            return View();


        }
    }

}
