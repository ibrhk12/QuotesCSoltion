using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuotesC.Controllers.ViewController
{
    public class SpanishController : Controller
    {
        // GET: Spanish
        public ActionResult Index()
        {
            return View();
        }

        // GET: Spanish/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Spanish/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spanish/Create
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

        // GET: Spanish/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Spanish/Edit/5
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

        // GET: Spanish/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Spanish/Delete/5
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