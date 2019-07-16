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
    public class FrenchController : Controller
    {
        // GET: French
        public async Task<ActionResult> Index()
        {
            IEnumerable<FrenchVM> frenchQuotes = null;
            try
            {
                APIHelper _api = new APIHelper();
                using (HttpClient client = _api.initial())
                {
                    using (HttpResponseMessage response = await client.GetAsync("frenchquotes/getAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                frenchQuotes = await content.ReadAsAsync<IEnumerable<FrenchVM>>();
                            }
                        }
                    }
                }
                if (frenchQuotes == null)
                    return RedirectToAction("Index", "Home");
                return View(frenchQuotes);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
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