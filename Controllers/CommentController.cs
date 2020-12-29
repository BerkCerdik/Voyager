﻿using System;
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

        public IActionResult Edit()
        {
            return View();
        }

    }



}
