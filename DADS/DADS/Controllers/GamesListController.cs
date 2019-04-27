using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DADS.Controllers
{
    public class GamesListController : Controller
    {

        public ActionResult AddChar()
        {
            return View();
        }

        public ActionResult AddGame()
        {
            return View();
        }

        // GET: GamesList
        public ActionResult Index()
        {
            return View();
        }

        // GET: GamesList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GamesList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GamesList/Create
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

        // GET: GamesList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GamesList/Edit/5
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

        // GET: GamesList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GamesList/Delete/5
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
