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

namespace Gym.Controllers
{
    public class TrainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        [Route("Trainers/Fshi/{id}")]
        public JsonResult Fshi(int? id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
            int result = db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        // GET: Trainers
        public async Task<ActionResult> Index(string value)
        {
            IQueryable<Trainer> trainer = db.Trainers;
            if (!String.IsNullOrEmpty(value))
            {
                trainer = trainer.Where(t => t.FirstName.Contains(value));
            }
            return View(await trainer.ToListAsync());
        }

        // GET: Trainers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        [Authorize(Roles="Admin")]
        public ActionResult Create()
        {
            ViewBag.ExercisePlanId = new SelectList(db.ExercisePlans, "ExercisePlanId", "ExercisePlanName");
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([Bind(Include = "TrainerId,FirstName,LastName,ExperienceDescription,ImageName,ExercisePlanId")] Trainer trainer, HttpPostedFileBase ImageName)
        {
            if (ModelState.IsValid)
            {
                WebImage img = new WebImage(ImageName.InputStream);
                img.Save(Konstante1.PathImazh1 + ImageName.FileName);
                db.Trainers.Add(new Trainer
                {
                    FirstName = trainer.FirstName,
                    LastName = trainer.LastName,
                    ExperienceDescription = trainer.ExperienceDescription,
                    ImageName = ImageName.FileName
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        // GET: Trainers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExercisePlanId = new SelectList(db.ExercisePlans, "ExercisePlanId", "ExercisePlanName", trainer.ExercisePlanId);
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit([Bind(Include = "TrainerId,FirstName,LastName,ExperienceDescription,ImageName,ExercisePlanId")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExercisePlanId = new SelectList(db.ExercisePlans, "ExercisePlanId", "ExercisePlanName", trainer.ExercisePlanId);
            return View(trainer);
        }

        

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
