using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DADS;

namespace DADS.Controllers
{
    public class itemsController : Controller
    {
        private ZeroHP_DBContainer db = new ZeroHP_DBContainer();

        // GET: items
        public async Task<ActionResult> Index()
        {
            return View(await db.items.ToListAsync());
        }

        // GET: items/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items items = await db.items.FindAsync(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // GET: items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,name,damage,description,types")] items items)
        {
            if (ModelState.IsValid)
            {
                db.items.Add(items);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(items);
        }

        // GET: items/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items items = await db.items.FindAsync(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,name,damage,description,types")] items items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(items);
        }

        // GET: items/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items items = await db.items.FindAsync(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            items items = await db.items.FindAsync(id);
            db.items.Remove(items);
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
