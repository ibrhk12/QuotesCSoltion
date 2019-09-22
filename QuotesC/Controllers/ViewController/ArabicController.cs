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
        APIHelper _api;
        public ArabicController()
        {
            _api = new APIHelper();
        }
        // GET: Arabic
        public async Task<ActionResult> Index()
        {
            IEnumerable<ArabicVM> arabicQuotes = null;
            try
            {
                
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
        public ActionResult Create(ArabicVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (model.Quote != null)
                {
                    //save the image
                    //_blobStorageServices = new BlobStorageServices();
                    //model.imageUrl = ImageUpload(model.image);
                    model.imageUrl = "https://i5.walmartimages.ca/images/Large/428/5_r/6000195494285_R.jpg";
                    //call the API Post
                    Arabic arabic = new Arabic()
                    {
                        imageName = model.imageName,
                        imageUrl = model.imageUrl,
                        Quote = model.Quote
                    };
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:61878/api/arabicquotes");
                        using (var postTask = client.PostAsJsonAsync<Arabic>("arabicquotes", arabic))
                        {
                            postTask.Wait();
                            var result = postTask.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                return RedirectToAction("Index");
                            }
                        }
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                //ViewBag.Exception = ex.Message;
                //return View(model);
                throw ex;
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