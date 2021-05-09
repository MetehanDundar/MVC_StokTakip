using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;

namespace MVC_StokTakip.Controllers
{
    [Authorize]
    [HandleError]
    public class StokController : Controller
    {
        StokDbEntities db = new StokDbEntities();

        // /elmah.axd ile hata logları alacağım
        public ActionResult Index()
        {
            var model = db.Stok1.ToList();
            //hata almak için 0'a bölünme hatası
            //int a = 10, b = 0;
            //int c = a / b;
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new Stok1();
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(Stok1 s)
        {
            if (!ModelState.IsValid)
            {
                //Model doğrulanmazsa get metodu gibi çalışacak.
                var model = new Stok1();
                return View(model);
            }
            if (Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi +uzanti ;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                s.Resim = "~/image/" + dosyaadi +uzanti ;
            }
            db.Entry(s).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index", "Stok");
        }

        [HttpGet]
        public ActionResult MiktarEkle(int id)
        {
            var model = db.Stok1.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult MiktarEkle(Stok1 s)
        {
            var model = db.Stok1.Find(s.ID);
            model.StokMiktar = model.StokMiktar + s.StokMiktar;
            db.SaveChanges();
            return RedirectToAction("Index", "Stok");
        }

        [HttpGet]
        public ActionResult MiktarCikar(int id)
        {
            var model = db.Stok1.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult MiktarCikar(Stok1 s)
        {
            var model = db.Stok1.Find(s.ID);
            model.StokMiktar = model.StokMiktar - s.StokMiktar;
            db.SaveChanges();
            return RedirectToAction("Index", "Stok");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var model = db.Stok1.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Guncelle(Stok1 s)
        {
            if (!ModelState.IsValid)
            {
                var model = db.Stok1.Find(s.ID);
                return View(model);
            }
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Stok");
        }

        
        public ActionResult Sil(int id)
        {
            var model = db.Stok1.FirstOrDefault(x => x.ID == id);
            db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            //var model = db.Stok1.Find(id);
            //db.Stok1.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index","Stok");
        }
    }
}