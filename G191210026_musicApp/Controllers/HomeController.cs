using G191210026_musicApp.Data;
using G191210026_musicApp.Entity;
using G191210026_musicApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Controllers
{
    public class HomeController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
