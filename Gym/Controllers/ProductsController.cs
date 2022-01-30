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
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        [Route("Products/Fshi/{id}")]
        public JsonResult Fshi(int? id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            int result = db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);

        }



        // GET: Products
        public async Task<ActionResult> Index(string value)
        {
            IQueryable<Product> products = db.Products;
            if (!String.IsNullOrEmpty(value))
            {
                switch (value)
                {
                    case "Suplements":
                        products = products.Where(p => p.Category.Contains(value));
                        break;
                    case "Clothes":
                        products = products.Where(p => p.Category.Contains(value));
                        break;
                    case "low":
                        products = products.Where(p => p.Price <= 50);
                        break;
                    case "medium":
                        products = products.Where(p => p.Price > 50 && p.Price <= 150);
                        break;
                    case "high":
                        products = products.Where(p => p.Price > 150);
                        break;
                    case "all":
                        products = products.Where(p => p.Price > 0);
                        break;
                    default:
                        products = products.Where(p => p.Name.Contains(value));
                        break;
                }

            }
            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,Name,Category,Price,ImageName")] Product product, HttpPostedFileBase ImageName)
        {
            if (ModelState.IsValid)
            {
                WebImage img = new WebImage(ImageName.InputStream);
                img.Save(Konstante.PathImazh + ImageName.FileName);
                db.Products.Add(new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category,
                    ImageName = ImageName.FileName
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,Name,Category,Price,ImageName")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
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
