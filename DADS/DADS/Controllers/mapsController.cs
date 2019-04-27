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
    public class mapsController : Controller
    {
        private ZeroHP_DBContainer db = new ZeroHP_DBContainer();

        // GET: maps
        public async Task<ActionResult> Index()
        {
            var maps = db.maps.Include(m => m.game);
            return View(await maps.ToListAsync());
        }

        // GET: maps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maps maps = await db.maps.FindAsync(id);
            if (maps == null)
            {
                return HttpNotFound();
            }
            return View(maps);
        }

        // GET: maps/Create
        public ActionResult Create()
        {
            ViewBag.gamesId = new SelectList(db.games, "Id", "name");
            return View();
        }

        // POST: maps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,image,drawings,gamesId,name")] maps maps)
        {
            if (ModelState.IsValid)
            {
                db.maps.Add(maps);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.gamesId = new SelectList(db.games, "Id", "name", maps.gamesId);
            return View(maps);
        }

        // GET: maps/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maps maps = await db.maps.FindAsync(id);
            if (maps == null)
            {
                return HttpNotFound();
            }
            ViewBag.gamesId = new SelectList(db.games, "Id", "name", maps.gamesId);
            return View(maps);
        }

        // POST: maps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,image,drawings,gamesId,name")] maps maps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maps).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.gamesId = new SelectList(db.games, "Id", "name", maps.gamesId);
            return View(maps);
        }

        // GET: maps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maps maps = await db.maps.FindAsync(id);
            if (maps == null)
            {
                return HttpNotFound();
            }
            return View(maps);
        }

        // POST: maps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            maps maps = await db.maps.FindAsync(id);
            db.maps.Remove(maps);
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
