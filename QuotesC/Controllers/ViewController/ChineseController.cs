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
    public class ChineseController : Controller
    {
        // GET: Chinese
        public async Task<ActionResult> Index()
        {
            IEnumerable<ChineseVM> chineseQuotes = null;
            try
            {
                APIHelper _api = new APIHelper();
                using (HttpClient client = _api.initial())
                {
                    using (HttpResponseMessage response = await client.GetAsync("chinesequotes/getAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                chineseQuotes = await content.ReadAsAsync<IEnumerable<ChineseVM>>();
                            }
                        }
                    }
                }
                if (chineseQuotes == null)
                    return RedirectToAction("Index", "Home");
                return View(chineseQuotes);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Chinese/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chinese/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chinese/Create
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

        // GET: Chinese/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chinese/Edit/5
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

        // GET: Chinese/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chinese/Delete/5
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