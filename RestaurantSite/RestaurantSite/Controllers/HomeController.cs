using RestaurantSite.Models;
using RestaurantSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantSite.Controllers
{


	public class HomeController : Controller
	{
		HAMBURGERDBEntities4 db=new HAMBURGERDBEntities4();
		public ActionResult Index() {
			ViewBag.TBLFIRSAT=db.TBLFIRSAT.ToList();
			ViewBag.TBLFIRSAT2=db.TBLFIRSAT2.ToList();
			ViewBag.TBLFOOTER=db.TBLFOOTER.ToList();
			ViewBag.TBLGALERI=db.TBLGALERI.ToList();
			ViewBag.TBLMENU=db.TBLMENU.ToList();
			ViewBag.TBLYORUMLAR=db.TBLYORUMLAR.ToList();
			ViewBag.TBLGİRİS = db.TBLGİRİS.ToList();
			ViewBag.TBLABOUT = db.TBLABOUT.ToList();
			return View();
		}
		


		/*GİRİŞ İŞLEMLERİ*/
		
		public ActionResult GİRİSPARTİAL()
		{
			ViewBag.TBLGİRİS = db.TBLGİRİS.ToList();
			return View();
		}


		/*ABOUT İŞLEMLERİ*/

		public ActionResult ABOUTPARTİAL()
		{
			ViewBag.TBLABOUT = db.TBLABOUT.ToList();
			return View();
		}

		/*FIRSAT İŞLEMLERİ*/
		public ActionResult FIRSATPARTİAL()
		{
			ViewBag.TBLFIRSAT = db.TBLFIRSAT.ToList();
			return View();
		}

		public ActionResult FIRSAT2PARTİAL()
		{
			ViewBag.TBLFIRSAT2 = db.TBLFIRSAT2.ToList();
			return View();
		}
		/*GALERİ İŞLEMLERİ*/
		public ActionResult GALERİPARTİAL()
		{
			ViewBag.TBLGALERI = db.TBLGALERI.ToList();

			return View();
		}

		/*YORUMLAR İŞLEMLERİ*/
		public ActionResult YORUMLARPARTİAL()
		{
			ViewBag.TBLYORUMLAR = db.TBLYORUMLAR.ToList();

			return View();
		}

		/*MENÜ İŞLEMLERİ*/
		public ActionResult MENUPARTİAL()
		{
			ViewBag.TBLMENU = db.TBLMENU.ToList();
			return View();
		}
		[HttpGet]
		public ActionResult PARTİALYORUM()
		{
			return View();
		}
		[HttpPost]
		
		[HttpGet]
		public ActionResult Aletisim()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Aletisim(TBLYORUMLAR p)
		{
			p.YorumStatus = false;
			db.TBLYORUMLAR.Add(p);

			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Yusuf()
		{
			return View();
		}



	}
}