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
    public class TrainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trainers
        public async Task<ActionResult> Index()
        {
            var trainers = db.Trainers.Include(t => t.ExercisePlan);
            return View(await trainers.ToListAsync());
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
        public async Task<ActionResult> Create([Bind(Include = "TrainerId,FirstName,LastName,ExperienceDescription,ImageName,ExercisePlanId")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExercisePlanId = new SelectList(db.ExercisePlans, "ExercisePlanId", "ExercisePlanName", trainer.ExercisePlanId);
            return View(trainer);
        }

        // GET: Trainers/Edit/5
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

        // GET: Trainers/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trainer trainer = await db.Trainers.FindAsync(id);
            db.Trainers.Remove(trainer);
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