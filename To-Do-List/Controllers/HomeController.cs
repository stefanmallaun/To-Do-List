﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using To_Do_List.Models;

namespace To_Do_List.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Overview()
        {
            return View();
        }

        
    }
}