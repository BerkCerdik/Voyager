﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Controllers
{
    public class AdminTripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}