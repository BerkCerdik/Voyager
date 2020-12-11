using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Context;
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
            List<CommentVM> comments = _context.Comments.Select(q => new CommentVM()
            {
                ID = q.ID,
                TripID=q.TripID,
                Content =q.Content,
                Point=q.Point
                
                

            }).ToList();
            return View(comments);
        }
    }
}
