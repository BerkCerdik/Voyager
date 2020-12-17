using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;

namespace Voyager.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class HomeController : BaseController
    {

        private readonly VoyagerContext _context;

        public HomeController(VoyagerContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
