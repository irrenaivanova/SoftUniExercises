﻿using Horizons.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Horizons.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!(User.Identity?.IsAuthenticated ?? false))
            {
                return View();
            }
            return RedirectToAction("Index", "Destination");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
