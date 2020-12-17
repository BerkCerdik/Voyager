using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;

namespace Voyager.Areas.AdminArea.Controllers
{
    [Authorize]
    [Area("AdminArea")]
    public class BaseController : Controller
    {
        private readonly VoyagerContext _context;
        private readonly IMemoryCache _memoryCache;

        public BaseController(VoyagerContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            List<Menu> adminMenus = new List<Menu>();
            bool isExist = _memoryCache.TryGetValue("menus", out adminMenus);
            if (!isExist)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));

                adminMenus = _context.Menus.ToList();
                _memoryCache.Set("menus", adminMenus, cacheEntryOptions);
            }

            ViewBag.menus = adminMenus;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
