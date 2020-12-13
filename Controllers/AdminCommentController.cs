using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Controllers
{
    public class AdminCommentController : Controller
    {
        private readonly VoyagerContext _context;
        private object db;

        public AdminCommentController(VoyagerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CommentVM> comments = _context.Comments.Include(a => a.Passenger).Include(b => b.Driver).Select(q => new CommentVM()
            
            {
                ID = q.ID,
                TripID=q.TripID,
                Content =q.Content,
                Point=q.Point,
                //PassengerName = q.Passenger.Name,
                //PassengerLastname = q.Passenger.Surname,
                //DriverName = q.Driver.Name,
                //DriverLastname = q.Driver.Surname



            }).ToList();
            return View(comments);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
