using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Vm;

namespace Voyager.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly VoyagerContext _context;

        public AdminLoginController(VoyagerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminUserVM model)
        {
            var adminuser = _context.AdminUsers.Any(x => x.Email == model.EMail && x.Password == model.Password);
            if (adminuser)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

            
        }
    }
}
