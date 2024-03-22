﻿using RestaurantSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantSite.Controllers
{
    public class LoginController : Controller
    {
        HAMBURGERDBEntities4 db=new HAMBURGERDBEntities4();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBLADMİN p)
        {
			var c = db.TBLADMİN.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
			if (c != null)
			{
				return RedirectToAction("Index", "Admin");
			}
			else
			{
				return RedirectToAction("Index");

			}

		}
	}
}