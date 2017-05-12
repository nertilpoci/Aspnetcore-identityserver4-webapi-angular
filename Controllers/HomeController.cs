using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationBasic.Controllers
{
   
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = HttpContext.User.Identity.Name;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
