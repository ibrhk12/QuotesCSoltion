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
    public class UrduController : Controller
    {
        // GET: Urdu
        public async Task<ActionResult> Index()
        {
            IEnumerable<UrduVM> urduQuotes = null;
            try
            {
                APIHelper _api = new APIHelper();
                using (HttpClient client = _api.initial())
                {
                    using (HttpResponseMessage response = await client.GetAsync("urduquotes/getAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                urduQuotes = await content.ReadAsAsync<IEnumerable<UrduVM>>();
                            }
                        }
                    }
                }
                if (urduQuotes == null)
                    return RedirectToAction("Index", "Home");
                return View(urduQuotes);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Urdu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Urdu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Urdu/Create
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

        // GET: Urdu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Urdu/Edit/5
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

        // GET: Urdu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Urdu/Delete/5
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