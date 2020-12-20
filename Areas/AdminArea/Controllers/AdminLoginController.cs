using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Vm;


namespace Voyager.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AdminLoginController : Controller
    {
        private readonly VoyagerContext _context;

        public AdminLoginController(VoyagerContext context, IMemoryCache memoryCache)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminUserVM model)
        {
            if (ModelState.IsValid)
            {
                var adminuser = _context.AdminUsers.Any(x => x.Email == model.EMail && x.Password == model.Password);


                if (adminuser != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Name),
                    //new Claim(ClaimTypes.Role, adminuser.Roles)
                };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    //adminuser.LastLoginDate = DateTime.Now;
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Home");
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

    }
}
