using Project2WooxTravel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        TravelContext db = new TravelContext();

        public ActionResult BarChart()
        {
            var values = db.Destinations.ToList();
            return View(values);
        }

        public ActionResult LineChart()
        {
            var values = db.Reservations.ToList();
            return View(values);
        }

        public ActionResult PieChart()
        {
            var values = db.Destinations.ToList();
            return View(values);
        }

        public ActionResult DonutChart()
        {
            var values = db.Destinations.ToList();
            return View(values);
        }
    }
}