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
            ViewBag.totalmessageCount = context.Messages.Count();

            var maxCapacity = context.Destinations.Max(x=>x.Capacity);
            ViewBag.maxCapacity = context.Destinations.Where(x=>x.Capacity==maxCapacity).Select(y=>y.Title).FirstOrDefault();

            var maxPrice = context.Destinations.Max(x=>x.Price);
            ViewBag.maxPriceDestination = context.Destinations.Where(x => x.Price == maxPrice).Select(y => y.Title).FirstOrDefault();

            var counttesekkurMessage=context.Messages.Count(x=>x.Subject=="Teşekkür");
            ViewBag.totalmessageTesekkur = counttesekkurMessage;

            var longestTour = context.Destinations.Max(x=>x.DayNight);
            ViewBag.longestTour = context.Destinations.Where(x=>x.DayNight== longestTour).Select(y=>y.Title).FirstOrDefault();

            ViewBag.readmessageCount= context.Messages.Where(x=>x.IsRead==true).Count();

            ViewBag.unreadmessageCount = context.Messages.Where(x => x.IsRead == false).Count();

            ViewBag.Numberofreservationsgreaterthan20 = context.Reservations.Where(x=>x.PersonCount>20).Count();

            return View();
        }
    }
}