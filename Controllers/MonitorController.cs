using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app2.Models;

namespace app2.Controllers
{
    public class MonitorController : Controller
    {
        public IActionResult Screen1(){
            return View();
        }
    }
}
