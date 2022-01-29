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

namespace Gym.Controllers
{
    public class DietPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DietPlans
        public async Task<ActionResult> Index(string value)
        {
            IQueryable<DietPlan> diets = db.DietPlans;
            if (!String.IsNullOrEmpty(value))
            {
                switch (value)
                {
                    case "gain":
                        diets = diets.Where(d => d.Category == "Gain Weight");
                        break;
                    case "build":
                        diets = diets.Where(d => d.Category == "Build Muscle");
                        break;
                    case "loose":
                        diets = diets.Where(d => d.Category == "Loose Weight");
                        break;
                    case "all":
                        diets = diets.Where(d => d.Category != " ");
                        break;
                    default:
                        diets = diets.Where(d => d.Name.Contains(value));
                        break;
                }

            }
            return View(await diets.ToListAsync());
        }

        // GET: DietPlans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = await db.DietPlans.FindAsync(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // GET: DietPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DietPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DietPlanId,Name,Category,Weight,Height,ImageName,Description,DurationInDays")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                db.DietPlans.Add(dietPlan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dietPlan);
        }

        // GET: DietPlans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = await db.DietPlans.FindAsync(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // POST: DietPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DietPlanId,Name,Category,Weight,Height,ImageName,Description,DurationInDays")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dietPlan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dietPlan);
        }

        // GET: DietPlans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = await db.DietPlans.FindAsync(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // POST: DietPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DietPlan dietPlan = await db.DietPlans.FindAsync(id);
            db.DietPlans.Remove(dietPlan);
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
