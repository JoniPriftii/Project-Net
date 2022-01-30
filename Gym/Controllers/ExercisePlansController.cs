﻿using System;
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
    public class ExercisePlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        // GET: ExercisePlans/Create
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

        // GET: ExercisePlans/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: ExercisePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ExercisePlan exercisePlan = await db.ExercisePlans.FindAsync(id);
            db.ExercisePlans.Remove(exercisePlan);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
