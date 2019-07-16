using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuotesC.Helper;
using QuotesC.ViewModel;

namespace QuotesC.Controllers.ViewController
{
    public class ArabicController : Controller
    {
        // GET: Arabic
        public async Task<ActionResult> Index()
        {
            IEnumerable<ArabicVM> arabicQuotes = null;
            try
            {
                APIHelper _api = new APIHelper();
                using (HttpClient client = _api.initial())
                {
                    using (HttpResponseMessage response = await client.GetAsync("arabicquotes/getAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using(HttpContent content =  response.Content)
                            {
                                arabicQuotes = await content.ReadAsAsync<IEnumerable<ArabicVM>>();
                            }
                        }
                    }
                }
                if(arabicQuotes == null)
                    return RedirectToAction("Index", "Home");
                return View(arabicQuotes);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index","Home");
            }
        }

        // GET: Arabic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Arabic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arabic/Create
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

        // GET: Arabic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Arabic/Edit/5
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

        // GET: Arabic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Arabic/Delete/5
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