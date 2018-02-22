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

        public IActionResult Index()
        {
            ViewData["Message"] = ipro.Name;

            using(var db = new jumpmanjiContext()){
                var ret = db.Users.Where(t=>t.Id==1).GroupJoin(db.UsersItems,t=>t.Id,i=>i.Userid,(t,i)=>new{
                        t.Id,
                        items = i
                }).Take(2).ToList();

                 ViewData["Message"] = Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }

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
