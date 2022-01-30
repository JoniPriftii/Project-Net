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
using Microsoft.AspNet.Identity;
using Gym.Models.ViewModels;

namespace Gym.Controllers
{
    public class DietPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DietPlans
        public async Task<ActionResult> Index()
        {
            return View(await db.DietPlans.ToListAsync());
        }

        // GET: DietPlans/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DietPlan dietPlan = await db.DietPlans.FindAsync(id);
        //    if (dietPlan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dietPlan);
        //}


        [HttpGet]
        public ActionResult Details(int id)
        {
            var dietPlan = db.DietPlans.FirstOrDefault(i=>i.DietPlanId == id);
            var dietPlanModel = new DietPlanViewModel();
            if (dietPlan != null)
            {
                dietPlanModel.Name = dietPlan.Name;
                dietPlanModel.DietPlanId = dietPlan.DietPlanId;
                dietPlanModel.Category = dietPlan.Category;
                dietPlanModel.Description = dietPlan.Description;
                dietPlanModel.ImageName = dietPlan.ImageName;
                dietPlanModel.Height = dietPlan.Height;
                dietPlanModel.Weight = dietPlan.Weight;
                dietPlanModel.DurationInDays = dietPlan.DurationInDays;

                var userId = User.Identity.GetUserId();

                var userDietPlan = db.UserDietPlans.FirstOrDefault(i => i.DietPlanId == id && i.IsActive == true && i.Id == userId);
                if (userDietPlan != null)
                {
                    dietPlanModel.IsActive = true;
                }
                else
                {
                    dietPlanModel.IsActive = false;
                }
            }

            return View(dietPlanModel);
        }

        [HttpPost]
        public ActionResult AddUserDietPlan(int id)
        {
            var userId = User.Identity.GetUserId();
            var dietPlan = db.DietPlans.FirstOrDefault(i => i.DietPlanId == id);

            if(dietPlan != null)
            {
                var userDietPlans = db.UserDietPlans.Where(i => i.Id == userId && i.IsActive != false);
                foreach (var userDietPlan in userDietPlans)
                {
                    userDietPlan.IsActive = false;
                    userDietPlan.EndDate = DateTime.Now;
                }
                db.UserDietPlans.Add(new UserDietPlan { DietPlanId = id, Id = userId, StartDate = DateTime.Now, IsActive = true });
                db.SaveChanges();
                return RedirectToAction("UserInformation", "Account");
            }
            else
            {
                return View("");
            }
                
            
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
