﻿using Microsoft.AspNetCore.Mvc;

namespace NinjaManager.Controllers
{
    public class NinjaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
