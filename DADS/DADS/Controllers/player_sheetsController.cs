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
    public class player_sheetsController : Controller
    {
        private ZeroHP_DBContainer db = new ZeroHP_DBContainer();

        // GET: player_sheets
        public async Task<ActionResult> Index()
        {
            var player_sheets = db.player_sheets;
            return View(await player_sheets.ToListAsync());
        }

        // GET: player_sheets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_sheets player_sheets = await db.player_sheets.FindAsync(id);
            if (player_sheets == null)
            {
                return HttpNotFound();
            }
            return View(player_sheets);
        }

        // GET: player_sheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: player_sheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,name,description,stats,spells,notes")] player_sheets player_sheets)
        {
            if (ModelState.IsValid)
            {
                //games game = db.games.Where(g => g.Id == id).Single();
                //player_sheets.games.Add(game);
                db.player_sheets.Add(player_sheets);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("../GamesLobby/Index");
        }

        // GET: player_sheets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_sheets player_sheets = await db.player_sheets.FindAsync(id);
            if (player_sheets == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Id = new SelectList(db.items, "Id", "name", player_sheets.Id);
            return View(player_sheets);
        }

        // POST: player_sheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Id,name,description,stats,spells,notes")] player_sheets player_sheets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player_sheets).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.Id = new SelectList(db.items, "Id", "name", player_sheets.Id);
            return View(player_sheets);
        }

        // GET: player_sheets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_sheets player_sheets = await db.player_sheets.FindAsync(id);
            if (player_sheets == null)
            {
                return HttpNotFound();
            }
            return View(player_sheets);
        }

        // POST: player_sheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            player_sheets player_sheets = await db.player_sheets.FindAsync(id);
            db.player_sheets.Remove(player_sheets);
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
