using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;

namespace MVC_StokTakip.Controllers
{
    public class ErrorController : Controller
    {
        StokDbEntities db = new StokDbEntities();

        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }

        [Authorize]
        public ActionResult List()
        {
            var model = db.ELMAH_Error.ToList();
            return View(model);
        }
    }
}