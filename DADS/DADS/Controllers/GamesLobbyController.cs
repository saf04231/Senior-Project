using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DADS.Controllers
{
    public class GamesLobbyController : Controller
    {
        // GET: GamesLobby
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddChar()
        {
            return View();
        }

        public ActionResult AddGame()
        {
            return View();
        }

        // GET: GamesLobby/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GamesLobby/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GamesLobby/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GamesLobby/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GamesLobby/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GamesLobby/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GamesLobby/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
