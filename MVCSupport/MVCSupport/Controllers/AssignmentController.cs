using Microsoft.AspNetCore.Mvc;
using MVCSupport.Models;
using MVCSupport.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCSupport.Controllers
{
    public class AssignmentController : Controller
    {

        [HttpPost]
        public int Post([FromBody] Assignments assignments)
        {


            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44385/api/assignments/");

                HttpResponseMessage result = client.PostAsJsonAsync("Post", assignments).Result;


                if (result.IsSuccessStatusCode)
                {

                    int readTask = Int32.Parse(result.Content.ReadAsStringAsync().Result);

                    return readTask;

                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            return 0;




        }
        public IActionResult Index()
        {
            return View();
        }
    }

}
