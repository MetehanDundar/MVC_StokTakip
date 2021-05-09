using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;
using System.Web.Security;

namespace MVC_StokTakip.Controllers
{
    public class KullaniciController : Controller
    {
        StokDbEntities db = new StokDbEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici1 k)
        {
            var kullanici = db.Kullanici1.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);
            if (kullanici!=null)
            {
                FormsAuthentication.SetAuthCookie(k.KullaniciAdi, false);
                return RedirectToAction("Index","Stok");
            }
            else
            {
                ViewBag.hata = "Kullanıcı adı veya şifre yanlış";
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Stok");
        }

        [HttpGet]
        public ActionResult Kaydol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kaydol(Kullanici1 k)
        {
            if (!ModelState.IsValid) return View();

            db.Entry(k).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Login", "Kullanici");
        }
    }
}