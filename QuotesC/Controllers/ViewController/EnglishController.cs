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
    public class EnglishController : Controller
    {
        // GET: English
        public async Task<ActionResult> Index()
        {
            IEnumerable<EnglishVM> englishQuotes = null;
            try
            {
                APIHelper _api = new APIHelper();
                using (HttpClient client = _api.initial())
                {
                    using (HttpResponseMessage response = await client.GetAsync("englishquotes/getAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                englishQuotes = await content.ReadAsAsync<IEnumerable<EnglishVM>>();
                            }
                        }
                    }
                }
                if (englishQuotes == null)
                    return RedirectToAction("Index", "Home");
                return View(englishQuotes);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: English/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: English/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: English/Create
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

        // GET: English/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: English/Edit/5
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

        // GET: English/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: English/Delete/5
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