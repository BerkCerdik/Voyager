using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Vm;

namespace Voyager.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AdminPaymentController : BaseController
    {

        private readonly VoyagerContext _context;

        public AdminPaymentController(VoyagerContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _context = context;
        }
            public IActionResult Index()
        {
            List<PaymentVM> payments = _context.Trips.Include(q => q.Payment).Select(q => new PaymentVM()
            {
                Price=q.Payment.Price,
                ID=q.ID

            }).ToList();

            return View(payments);
        }

        public IActionResult PaymentDetail()
        {
            return View();
        }
    }
}
