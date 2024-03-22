using RestaurantSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantSite.Controllers
{
    public class AdminController : Controller
    {
        
        HAMBURGERDBEntities4 db=new HAMBURGERDBEntities4();

        /*GİRİŞ İŞLEMLERİ*/
        public ActionResult Index()
        {
            var degerler=db.TBLGİRİS.ToList();
            return View(degerler);
        }
		[HttpGet]
        public ActionResult GirisGuncelle(int id) 
        {
            var ggg = db.TBLGİRİS.Find(id);
            return View(ggg);
        }
        [HttpPost]
        public ActionResult GirisGuncelle(TBLGİRİS p)
        {
            var gg=db.TBLGİRİS.Find(p.GirisID);
            gg.GirisID = p.GirisID;
            gg.GirisImageURL = p.GirisImageURL;
            gg.GirisBaslik= p.GirisBaslik;
            gg.GirisTelefon=p.GirisTelefon;
            db.TBLGİRİS.AddOrUpdate(gg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		/*ABOUT İŞLEMLERİ*/
		public ActionResult About()
        {
            var about=db.TBLABOUT.ToList();
            return View(about);
        }
        [HttpGet]
        public ActionResult AboutGuncelle(int id)
        {
            var degerler = db.TBLABOUT.Find(id);
            return View(degerler); }
        [HttpPost]
        public ActionResult AboutGuncelle(TBLABOUT p)
        {
            var deger = db.TBLABOUT.Find(p.AboutID);
            deger.AboutID= p.AboutID;
            deger.AboutBaslik= p.AboutBaslik;
            deger.AboutText= p.AboutText;
            deger.AboutImageURL= p.AboutImageURL;
            db.TBLABOUT.AddOrUpdate(deger);
            db.SaveChanges();
            return RedirectToAction("About","Admin");
        }
        /*FIRSAT İŞLEMLERİ*/
        public ActionResult Firsat()
        {
            var firsat=db.TBLFIRSAT.ToList();
             return View(firsat);
        }
        public ActionResult FirsatSil(int id)
        {
            var sil = db.TBLFIRSAT.Find(id);
            db.TBLFIRSAT.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Firsat", "Admin");
        }
        [HttpGet]
        public ActionResult FirsatGuncelle(int id)
        {
            var fg = db.TBLFIRSAT.Find(id);
            return View(fg);
        }
        [HttpPost]
        public ActionResult FirsatGuncelle(TBLFIRSAT p)
        {
            var fg = db.TBLFIRSAT.Find(p.FirsatID);
            fg.FirsatID= p.FirsatID;
            fg.FirsatBaslik= p.FirsatBaslik;
			fg.FirsatAciklama1 = p.FirsatAciklama1;
			fg.FirsatAciklama2 = p.FirsatAciklama2;
			fg.FirsatAciklama3 = p.FirsatAciklama3;
            fg.FirsatFiyat= p.FirsatFiyat;
            fg.Renk= p.Renk;
            db.TBLFIRSAT.AddOrUpdate(fg);
            db.SaveChanges();
            return RedirectToAction("Firsat","Admin");
        }
        [HttpGet]
        public ActionResult FirsatEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FirsatEkle(TBLFIRSAT p)
        {
            var degerler = db.TBLFIRSAT.Add(p);
            db.SaveChanges();
            return RedirectToAction("Firsat","Admin");
        }
		/*MENU İŞLEMLERİ*/
		public ActionResult Menu()
		{
			var menu = db.TBLMENU.ToList();
			return View(menu);
		}

		public ActionResult MenuSil(int id)
        {
            var sil = db.TBLMENU.Find(id);
            db.TBLMENU.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Menu", "Admin");
        }

        [HttpGet]
        public ActionResult MenuGuncelle(int id)
        {
            var deger=db.TBLMENU.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult MenuGuncelle(TBLMENU p)
        {
            var degerler = db.TBLMENU.Find(p.BurgerID);
            degerler.BurgerID= p.BurgerID;
            degerler.BurgerAd= p.BurgerAd;
            degerler.BurgerFiyat= p.BurgerFiyat;
            db.TBLMENU.AddOrUpdate(degerler);
            db.SaveChanges();
            return RedirectToAction("Menu", "Admin");
        }
        [HttpGet]
        public ActionResult YeniBurger()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Yeniburger(TBLMENU p)
        {
            db.TBLMENU.Add(p);
            db.SaveChanges();
            return RedirectToAction("Menu", "Index");
        }


        /*YORUM İŞLEMLERİ*/
        public ActionResult Yorum(bool tip)
        {
            List<TBLYORUMLAR> yorum = new List<TBLYORUMLAR>();
            if (tip)
            {
				yorum = db.TBLYORUMLAR.Where(a=>a.YorumStatus==true).ToList();
			}
            else
            {
				yorum = db.TBLYORUMLAR.Where(a => a.YorumStatus == false).ToList();

			}

			return View(yorum);
        }
        public ActionResult YorumSil(int id)
        {
            var sil=db.TBLYORUMLAR.Find(id);
            db.TBLYORUMLAR.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult onayver(int id)
        {
            var yorum = db.TBLYORUMLAR.Where(a => a.YorumID == id).FirstOrDefault();
            yorum.YorumStatus = true;
            db.TBLYORUMLAR.AddOrUpdate(yorum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
        /*ADMİN İŞLEMLERİ*/

        public ActionResult Admin()
        {
            var admin = db.TBLADMİN.ToList();
            return View(admin);
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var ag=db.TBLADMİN.Find(id);
            return View(ag);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMİN p)
        {
            var degerler=db.TBLADMİN.Find(p.AdminID);
            degerler.AdminID = p.AdminID;
            degerler.AdminUserName = p.AdminUserName;
            degerler.AdminPassword = p.AdminPassword;
            db.TBLADMİN.AddOrUpdate(degerler);
            db.SaveChanges();
            return RedirectToAction("Admin", "Admin");
        }







	}
}