using LukeDucaSEAssignment2Sit1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LukeDucaSEAssignment2Sit1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private DataContext db = new DataContext();
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (Request.IsAuthenticated == true)
                {
                    string role = db.tbl_Users.SingleOrDefault(x => x.Username == Context.User.Identity.Name).tbl_Roles.Type;
                    string[] roles = new string[1] { role };
                    Context.User = new System.Security.Principal.GenericPrincipal(Context.User.Identity, roles);
                }
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
