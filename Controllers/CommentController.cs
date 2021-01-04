using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Voyager.Models.Orm.Context;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Controllers
{
    public class CommentController : Controller
    {
        private readonly VoyagerContext _context;

        public CommentController(VoyagerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CommentVM> comments = _context.Comments.Include(a => a.Trip).ThenInclude(Trip => Trip.Passenger).Include(a => a.Trip).ThenInclude(Trip => Trip.Driver).Select(q => new CommentVM()
            {
                ID = q.ID,
                TripID = q.TripID,
                Content = q.Content,
                Point = q.Point,
                PassengerName = q.Trip.Passenger.Name,
                PassengerLastname = q.Trip.Passenger.Surname,
                DriverName = q.Trip.Driver.Name,
                DriverLastname = q.Trip.Driver.Surname

            }).ToList();

            return View(comments);
        }

      
        public IActionResult Add(int id)
        {
            Comment comment = new Comment();

            comment.TripID = id;
            comment.Point = 0;
            comment.Content = " ";            

            _context.SaveChanges();
            return RedirectToAction("Edit", "Comment", new {id = id });

          
        }

        public IActionResult Edit(int id)
        {
            Comment comment = _context.Comments.FirstOrDefault(x => x.TripID == id);
            CommentVM model = new CommentVM();
            model.Content = comment.Content;
            model.Point = comment.Point;
            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(CommentVM model)
        {
            Comment comment= _context.Comments.FirstOrDefault(x => x.ID == model.ID);

            if (ModelState.IsValid)
            {
                comment.Content = model.Content;
                comment.Point = model.Point;
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return RedirectToAction("Index", "Comment");
            }

            return View();
        }

    }



}

