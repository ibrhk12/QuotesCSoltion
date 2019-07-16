using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesC.Helper;
using QuotesC.ViewModel;

namespace QuotesC.Controllers.ViewController
{
    public class SpanishController : Controller
    {
        // GET: Spanish
        public async Task<ActionResult> Index()
        {
            IEnumerable<SpanishVM> spanishQuotes = null;
            try
            {
                APIHelper _api = new APIHelper();
                using (HttpClient client = _api.initial())
                {
                    using (HttpResponseMessage response = await client.GetAsync("spanishquotes/getAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                spanishQuotes = await content.ReadAsAsync<IEnumerable<SpanishVM>>();
                            }
                        }
                    }
                }
                if (spanishQuotes == null)
                    return RedirectToAction("Index", "Home");
                return View(spanishQuotes);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
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