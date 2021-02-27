using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSupport.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Logout()
        {
           
            return View();
        }
    }
}
