﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NieGumex.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //tralalalal
            //dodane o 17:30 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult Support()
        {
            
            return View();
        }
    }
}