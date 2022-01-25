using Gym.Models;
using log4net;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace Gym.Controllers
{

    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}