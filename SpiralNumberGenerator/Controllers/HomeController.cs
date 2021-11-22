﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloperCodeTest.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Index(int inputNumber)
        {
            SpiralGenerator sg = new SpiralGenerator();

            int?[,] arr = sg.Generate(inputNumber);

            return View(arr);
        }


    }
}