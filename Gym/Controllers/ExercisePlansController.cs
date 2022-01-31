using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gym.Models;
using System.Web.Helpers;
using Gym.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace Gym.Controllers
{
    public class ExercisePlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        [Route("ExercisePlans/Fshi/{id}")]
        public JsonResult Fshi(int? id)
        {
            ExercisePlan exercise = db.ExercisePlans.Find(id);
            db.ExercisePlans.Remove(exercise);
            int result = db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        // GET: ExercisePlans
        public async Task<ActionResult> Index(string value)
        {
            IQueryable<ExercisePlan> exerc = db.ExercisePlans;
            if (!String.IsNullOrEmpty(value))
            {
                switch (value)
                {
                    case "low":
                        exerc = exerc.Where(e => e.Price <= 50);
                        break;
                    case "medium":
                        exerc = exerc.Where(e => e.Price > 50 && e.Price <= 150);
                        break;
                    case "high":
                        exerc = exerc.Where(e => e.Price > 150);
                        break;
                    case "all":
                        exerc = exerc.Where(e => e.Price > 0);
                        break;
                    default:
                        exerc = exerc.Where(e => e.ExercisePlanName.Contains(value));
                        break;
                }

            }
            return View(await exerc.ToListAsync());
        }

        /*
        // GET: ExercisePlans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercisePlan exercisePlan = await db.ExercisePlans.FindAsync(id);
            if (exercisePlan == null)
            {
                return HttpNotFound();
            }
            return View(exercisePlan);
        }
        */

        [HttpGet]
        public ActionResult Details(int id)
        {
            var exercisePlan = db.ExercisePlans.FirstOrDefault(i => i.ExercisePlanId == id);
            var exercisePlanModel = new UserExercisePlanViewModel();
            if (exercisePlan != null)
            {
                exercisePlanModel.ExercisePlanName = exercisePlan.ExercisePlanName;
                exercisePlanModel.ExercisePlanId = exercisePlan.ExercisePlanId;                
                exercisePlanModel.Description = exercisePlan.Description;
                exercisePlanModel.ImageName = exercisePlan.ImageName;                
                exercisePlanModel.DurationInDays = exercisePlan.DurationInDays;
                exercisePlanModel.Price = exercisePlan.Price;
                exercisePlanModel.Sessions = exercisePlan.Sessions;
               
                var userId = User.Identity.GetUserId();

                var userExercisePlan = db.UserExercisePlans.FirstOrDefault(i => i.ExercisePlanId == id && i.IsActive == true && i.Id == userId);
                if (userExercisePlan != null)
                {
                    exercisePlanModel.IsActive = true;
                }
                else
                {
                    exercisePlanModel.IsActive = false;
                }
            }

            return View(exercisePlanModel);
        }


        [HttpPost]
        public ActionResult AddUserExercisePlan(int id)
        {
            var userId = User.Identity.GetUserId();
            var exercisePlan = db.ExercisePlans.FirstOrDefault(i => i.ExercisePlanId == id);

            if (exercisePlan != null)
            {
                var userExercisePlans = db.UserExercisePlans.Where(i => i.Id == userId && i.IsActive != false);
                foreach (var userExercisePlan in userExercisePlans)
                {
                    userExercisePlan.IsActive = false;
                    userExercisePlan.EndDate = DateTime.Now;
                }
                db.UserExercisePlans.Add(new UserExercisePlan { ExercisePlanId = id, Id = userId, StartDate = DateTime.Now, IsActive = true });
                db.SaveChanges();
                return RedirectToAction("UserInformation", "Account");
            }
            else
            {
                return View("Index", "ExercisePlans");
            }


        }

        [HttpPost]
        public ActionResult EndUserExercisePlan(int id)
        {
            var userId = User.Identity.GetUserId();
            var exercisePlan = db.ExercisePlans.FirstOrDefault(i => i.ExercisePlanId == id);

            if (exercisePlan != null)
            {
                var userExercisePlan = db.UserExercisePlans.FirstOrDefault(i => i.Id == userId && i.IsActive == true);

                userExercisePlan.IsActive = false;
                userExercisePlan.EndDate = DateTime.Now;

                db.SaveChanges();

                return RedirectToAction("UserInformation", "Account");
            }
            else
            {
                return View("Details", "ExercisePlans");
            }
        }


        // GET: ExercisePlans/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExercisePlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ExercisePlanId,ExercisePlanName,Description,DurationInDays,Price,Sessions,ImageName")] ExercisePlan exercisePlan, HttpPostedFileBase ImageName)
        {
            if (ModelState.IsValid)
            {
                WebImage img = new WebImage(ImageName.InputStream);
                img.Save(Konstante3.PathImazh3 + ImageName.FileName);
                db.ExercisePlans.Add(new ExercisePlan
                {
                    ExercisePlanName = exercisePlan.ExercisePlanName,
                    Description = exercisePlan.Description,
                    DurationInDays = exercisePlan.DurationInDays,
                    Price = exercisePlan.Price,
                    Sessions = exercisePlan.Sessions,
                    ImageName = ImageName.FileName
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercisePlan);
        }

        // GET: ExercisePlans/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercisePlan exercisePlan = await db.ExercisePlans.FindAsync(id);
            if (exercisePlan == null)
            {
                return HttpNotFound();
            }
            return View(exercisePlan);
        }

        // POST: ExercisePlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit([Bind(Include = "ExercisePlanId,ExercisePlanName,Description,DurationInDays,Price,Sessions,ImageName")] ExercisePlan exercisePlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercisePlan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(exercisePlan);
        }



        [Authorize(Roles = "Admin")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
