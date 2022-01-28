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

namespace Gym.Controllers
{
    public class ExercisePlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExercisePlans
        public async Task<ActionResult> Index()
        {
            return View(await db.ExercisePlans.ToListAsync());
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
        public async Task<ActionResult> Create([Bind(Include = "ExercisePlanId,ExercisePlanName,Description,DurationInDays,Price,Sessions,ImageName")] ExercisePlan exercisePlan)
        {
            if (ModelState.IsValid)
            {
                db.ExercisePlans.Add(exercisePlan);
                await db.SaveChangesAsync();
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