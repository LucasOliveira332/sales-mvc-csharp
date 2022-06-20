﻿using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;
using SalesMvc.Models.ViewModels;
using System.Diagnostics;

namespace SalesMvc.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly SeedingService _seedingServices;

        public HomeController(ILogger<HomeController> logger, SeedingService seedingServices)
        {
            _logger = logger;
            _seedingServices = seedingServices;
        }

        public IActionResult Index()
        {
            _seedingServices.Seed();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}
