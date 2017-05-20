using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using InEdIT.Models;
using Newtonsoft.Json;

namespace InEdIT
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            if (authTicket == null) return;

            var serializeModel =
                JsonConvert.DeserializeObject<EditPrincipalModel>(authTicket.UserData);

            var principal = new EditPrincipal(serializeModel.Name);
            principal.Id = serializeModel.Id;
            principal.UserType = serializeModel.UserType;

            HttpContext.Current.User = principal;
        }
    }
}
