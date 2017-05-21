using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InEdIT.Models;
using Newtonsoft.Json;

namespace InEdIT.Controllers
{
    public class AuthentificationController : Controller
    {
        // GET: Authentification
        [HttpGet]
        public ActionResult SignIn()
        {
            return RedirectToAction("Index", "Student");
            var principalModel = new EditPrincipalModel
            {
                Id = new Guid("B2AF469F-B0C9-4A84-BCEB-81A21AB74D5A"),
                Name = "Stefan",
                UserType = UserType.Student
            };
            var principalJson = JsonConvert.SerializeObject(principalModel);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1, "Stefan", DateTime.Now, DateTime.Now.AddHours(8), false, principalJson);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie cookie = new HttpCookie("principal", encTicket);
            Response.Cookies.Add(cookie);

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(FormCollection userData)
        {
            var principalModel = new EditPrincipalModel
            {
                Id = new Guid("B2AF469F-B0C9-4A84-BCEB-81A21AB74D5A"),
                Name = "Stefan",
                UserType = UserType.Student
            };
            var principalJson = JsonConvert.SerializeObject(principalModel);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1, "Stefan", DateTime.Now, DateTime.Now.AddHours(8), false, principalJson);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie cookie = new HttpCookie("principal", encTicket);
            Response.Cookies.Add(cookie);
            
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult SignUp(FormCollection userDava)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SignInOrSignUp()
        {
            return View();
        }
    }
}