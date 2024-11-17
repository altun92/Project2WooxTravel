using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;

namespace Project2WooxTravel.Controllers
{
    public class LoginController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x=>x.UserName == admin.UserName && x.Password==admin.Password);

            if (values != null) 
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["x"] = values.UserName;
                Session["y"] = values.Name;
                Session["z"] = values.Email;
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }
    }
}