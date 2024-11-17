using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;

namespace Project2WooxTravel.Controllers
{
    public class DefaultController : Controller
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

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }

        public PartialViewResult PartialSlider()
        {
            var values = context.Destinations.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialCountry(int sayfa = 1)
        {
            var values = context.Destinations.ToList().ToPagedList(sayfa, 3);
            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public ActionResult TourDetail(int id)
        {
            var values = context.Destinations.Where(x=>x.DestinationId==id).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewReservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewReservation(Reservation reservation)
        {
            reservation.ReservationDate = DateTime.Now;
            context.Reservations.Add(reservation);
            context.SaveChanges();

            TempData["SuccessMessage"] = "Rezervasyon başarıyla kaydedildi!";
            return RedirectToAction("Index", "Default");
        }
    }
}