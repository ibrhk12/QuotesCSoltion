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
    public class HindiController : Controller
    {
        // GET: Hindi
        public async Task<ActionResult> Index()
        {
            IEnumerable<HindiVM> hindiQuotes = null;
            try
            {
                APIHelper _api = new APIHelper();
                using (HttpClient client = _api.initial())
                {
                    using (HttpResponseMessage response = await client.GetAsync("hindiquotes/getAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                hindiQuotes = await content.ReadAsAsync<IEnumerable<HindiVM>>();
                            }
                        }
                    }
                }
                if (hindiQuotes == null)
                    return RedirectToAction("Index", "Home");
                return View(hindiQuotes);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Hindi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Hindi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hindi/Create
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

        // GET: Hindi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hindi/Edit/5
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

        // GET: Hindi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hindi/Delete/5
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