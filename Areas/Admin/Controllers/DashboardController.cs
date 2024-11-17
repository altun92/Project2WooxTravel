using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            ViewBag.categoryCount = context.Categories.Count();
            ViewBag.userCount = context.Admins.Count();
            ViewBag.destinationCount = context.Destinations.Count();
            ViewBag.reservationCount = context.Reservations.Count();

            return View();
        }
    }
}