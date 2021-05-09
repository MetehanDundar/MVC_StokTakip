using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;

namespace MVC_StokTakip.Controllers
{
    [Authorize]
    public class LogController : Controller
    {
        StokDbEntities db = new StokDbEntities();
        
        [HttpGet]
        public ActionResult Index()
        {
            
            var model = db.StokLogs.ToList();
            return View(model);
        }

    }
}