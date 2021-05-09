using MVC_StokTakip.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_StokTakip
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new ElmahExceptionFilter()); //Ekledigim filtreyi dahil ettim
            GlobalFilters.Filters.Add(new HandleErrorAttribute()); //Projedeki tüm controller'lar icin uygulanması icin. Bu sekilde proje seviyesinde alacagımız her hata yakalanır.
        }
    }
}
