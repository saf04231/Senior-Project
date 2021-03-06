﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DADS;

namespace DADS.Controllers
{
    public class GameLobbyController : Controller
    {
        private ZeroHP_DBContainer db = new ZeroHP_DBContainer();

        // GET: GameLobby
        public ActionResult Index()
        {
            return View(db.games.ToList());
        }

        // GET: GameLobby/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games games = db.games.Find(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // GET: GameLobby/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameLobby/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,name,description")] games games)
        {
            if (ModelState.IsValid)
            {
                games.dm = userController.LoggedInUser;
                System.Diagnostics.Debug.WriteLine("DM in GameLobbyController =" + games.dm);
                db.games.Add(games);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(games);
        }

        public users GetLoggedInUser()
        {
            try
            {
                var ctx = Request.GetOwinContext();
                var identity = ctx.Authentication.User.Identity;
                users user = db.users.Where(u => u.username == identity.Name).Single();

                return user;
            }
            catch (Exception e)
            {
                ViewBag.LoginError = "User is not logged in." + e;
                return null;
            }
        }

        // GET: GameLobby/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games game = db.games.Find(id);
            player_sheets player = game.player_sheets.Single();
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: GameLobby/GameView/5
        public ActionResult GameView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games game = db.games.Find(id);
            player_sheets player = game.player_sheets.Single();
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: GameLobby/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,name,description")] games games)
        {
            if (ModelState.IsValid)
            {
                db.Entry(games).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(games);
        }

        // GET: GameLobby/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games games = db.games.Find(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // POST: GameLobby/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            games games = db.games.Find(id);
            db.games.Remove(games);
            db.SaveChanges();
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
