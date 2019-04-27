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
    public class gamesController : Controller
    {
        private ZeroHP_DBContainer db = new ZeroHP_DBContainer();

        // GET: games
        public async Task<ActionResult> Index()
        {
            return View(await db.games.ToListAsync());
        }

        // GET: games/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games games = await db.games.FindAsync(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // GET: games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,name,description")] games games)
        {
            if (ModelState.IsValid)
            {
                db.games.Add(games);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(games);
        }

        // GET: games/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games games = await db.games.FindAsync(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // POST: games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,name,description")] games games)
        {
            if (ModelState.IsValid)
            {
                db.Entry(games).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(games);
        }

        // GET: games/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games games = await db.games.FindAsync(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // POST: games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            games games = await db.games.FindAsync(id);
            db.games.Remove(games);
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
