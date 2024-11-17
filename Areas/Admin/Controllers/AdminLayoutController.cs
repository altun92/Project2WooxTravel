using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            var a = Session["y"];
            var b = Session["z"];

            ViewBag.kullaniciAdi = a;
            ViewBag.kullaniciEmail = b;

            var values = context.Messages.Where(x=>x.ReceiverMail==b).OrderByDescending(y=>y.SendDate).ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult NavbarDestinationList()
        {
            var values = context.Destinations.OrderByDescending(x => x.DestinationId).Take(4).ToList();

            ViewData["EklenenGünListesi"] = values.Select(y => (DateTime.Now - y.CreateDate).Days).ToList();

            return PartialView(values);
        }
    }
}