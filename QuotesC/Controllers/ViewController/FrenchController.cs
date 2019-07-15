using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuotesC.Controllers.ViewController
{
    public class FrenchController : Controller
    {
        // GET: French
        public ActionResult Index()
        {
            return View();
        }

        // GET: French/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: French/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: French/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: French/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: French/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: French/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: French/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}