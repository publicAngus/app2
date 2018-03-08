using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app2.Models;

namespace app2.Controllers
{
    public class HomeController : Controller
    {
        Models.Providers.IProvider ipro {get;set;}
        public HomeController(Models.Providers.IProvider provider){
            ipro = provider;
        }

        [app2.Filters.TestFilter]
        public IActionResult Index()
        {
            ViewData["Message"] = ipro.Name;

            ViewData["Message"] = ipro.GetTestData();

            return View();
        }

        public IActionResult Monitor(){
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
