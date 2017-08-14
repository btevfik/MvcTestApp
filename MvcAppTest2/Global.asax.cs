using MvcAppTest2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using System.Data.Entity.Migrations;
using MvcAppTest2.Migrations;

namespace MvcAppTest2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // CODE FIRST MIGRATIONS
#if !DEBUG
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
#else
            Database.SetInitializer<ConferenceContext>(new ConferenceContextIntializer());
#endif
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
