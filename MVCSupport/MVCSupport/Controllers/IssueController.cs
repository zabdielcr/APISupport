using Microsoft.AspNetCore.Mvc;
using MVCSupport.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCSupport.Controllers
{
    public class IssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {

            IEnumerable<Issue> issue = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44385/api/issue/");
                var responseTask = client.GetAsync("Get");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Issue>>();
                    readTask.Wait();

                    issue = readTask.Result;
                }
                else
                {
                    issue = Enumerable.Empty<Issue>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return Json(issue);
        }

    }
}
