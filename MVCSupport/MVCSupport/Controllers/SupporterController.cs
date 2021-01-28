using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCSupport.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCSupport.Controllers
{
    public class SupporterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Supporter supporter)
        {

            if (GetToAuthenticate(supporter.Email, supporter.Password) != null)
            {

                HttpContext.Session.SetString("email", supporter.Email);

            }

            return RedirectToAction("Index", "Home");

        }

        public JsonResult Get()
        {

            IEnumerable<Supporter> supporter = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44343/api/supporter/");
                var responseTask = client.GetAsync("GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Supporter>>();
                    readTask.Wait();

                    supporter = readTask.Result;
                }
                else
                {
                    supporter = Enumerable.Empty<Supporter>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(supporter);
        }

        public JsonResult Exists()
        {

            IEnumerable<Supporter> supporter = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44343/api/supporter/");
                var responseTask = client.GetAsync("Exists");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Supporter>>();
                    readTask.Wait();

                    supporter = readTask.Result;
                }
                else
                {
                    supporter = Enumerable.Empty<Supporter>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(supporter);
        }

        public JsonResult Put()
        {

            IEnumerable<Supporter> supporter = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44343/api/supporter/");
                var responseTask = client.GetAsync("Put");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Supporter>>();
                    readTask.Wait();

                    supporter = readTask.Result;
                }
                else
                {
                    supporter = Enumerable.Empty<Supporter>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(supporter);
        }

        public JsonResult Post()
        {

            IEnumerable<Supporter> supporter = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44343/api/supporter/");
                var responseTask = client.GetAsync("Post");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Supporter>>();
                    readTask.Wait();

                    supporter = readTask.Result;
                }
                else
                {
                    supporter = Enumerable.Empty<Supporter>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(supporter);
        }

        public JsonResult Delete(Supporter supporter, int id)
        {

         

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44343/api/supporter/");
                var responseTask = client.GetAsync("Delete" +id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Supporter>>();
                    readTask.Wait();

                    
                }
                else
                {
                   
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(supporter);
        }



        public Supporter GetToAuthenticate(string email, string password)
        {

            Supporter supporter = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44343/api/supporter/");
                try
                {
                    var responseTask = client.GetAsync("GetToAuthenticate?email=" + email + "&password=" + password);
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Supporter>();
                        readTask.Wait();

                        supporter = readTask.Result;
                    }
                }
                catch (AggregateException agg_ex)
                {
                    var ex = agg_ex.InnerExceptions[0];
                }

            }

            return supporter;
        }
    }
}
