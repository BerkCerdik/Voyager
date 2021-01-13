using Microsoft.AspNetCore.Mvc;
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
    public class AdminUserController : BaseController
    {
        private readonly VoyagerContext _context;


        public AdminUserController(VoyagerContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<AdminUserVM> adminusers = _context.AdminUsers.Where(q => q.IsDeleted == false).Select(q => new AdminUserVM()
            {
                ID = q.ID,
                EMail = q.Email,
                Name = q.Name,
                Password = q.Password,
                Surname = q.Surname,
                Roles=q.Roles

            }).ToList();

            return View(adminusers);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminUserVM model)
        {
            if (ModelState.IsValid)
            {
                AdminUser adminuser = new AdminUser();
                adminuser.Name = model.Name;
                adminuser.Surname = model.Surname;
                adminuser.Email = model.EMail;
                adminuser.Password = model.Password;
                //adminuser.Roles = model.Roles;
                _context.AdminUsers.Add(adminuser);
                _context.SaveChanges();
                //return RedirectToAction("Index", "AdminUser");
                return Redirect("/AdminArea/AdminUser/Index/");

            }

            return View();


        }

        public IActionResult Edit(int id)
        {

            AdminUser adminuser = _context.AdminUsers.FirstOrDefault(x => x.ID == id);

            AdminUserVM model = new AdminUserVM();
            model.Name = adminuser.Name;
            model.Password = adminuser.Password;
            model.Surname = adminuser.Surname;
            model.EMail = adminuser.Email;
            model.Roles = adminuser.Roles;


            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AdminUserVM model)
        {
            AdminUser adminuser = _context.AdminUsers.FirstOrDefault(x => x.ID == model.ID);

            if (ModelState.IsValid)
            {
                adminuser.Name = model.Name;
                adminuser.Surname = model.Surname;
                adminuser.Email = model.EMail;
                adminuser.Password = model.Password;
                adminuser.Roles = model.Roles;

                _context.SaveChanges();
                return View(model);
            }
            return RedirectToAction("Index", "AdminUser");
        }

        public IActionResult Detail(int id)
        {
            AdminUser adminuser = _context.AdminUsers.FirstOrDefault(x => x.ID == id);

            AdminUserVM model = new AdminUserVM();
            model.Name = adminuser.Name;
            model.Surname = adminuser.Surname;
            model.EMail = adminuser.Email;
            model.Password = adminuser.Password;
            model.Roles = adminuser.Roles;


            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            AdminUser adminuser = _context.AdminUsers.FirstOrDefault(x => x.ID == id);

            adminuser.IsDeleted = true;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
