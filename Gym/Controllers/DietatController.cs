using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Dietat.Controllers
{
    public class DietatController : Controller
    // GET: Diet
    {
        public ActionResult Index()
        {
            ViewBag.DietatList = "Gym Shop Dietat List Page";

            List<Dietat> IList = new List<Dietat>()

            {
               new DietatList {ID=1 , Name="Gain Weight", Category="Diet",Price=20.00$},
               new DietatList {ID=2, Name="Lose Weight", Category="Diet", Price=20.00$},

           };

            return View(IList);

        }

    