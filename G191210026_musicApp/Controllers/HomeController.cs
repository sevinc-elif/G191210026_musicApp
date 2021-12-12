using G191210026_musicApp.Data;
using G191210026_musicApp.Entity;
using G191210026_musicApp.Models;
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
        private readonly MusicContext _context;
        public HomeController(MusicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            var model = new HomePageViewModel()
            {
                Email = user.Email,
                Password = user.Password
            };

            var bilgi = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (bilgi != null)
            {
                
                return RedirectToAction("Index", "Music");
            }
            else
            {
                ModelState.AddModelError("", "Email veya şifre hatalı!");
            }
            return View();
        }


    }
}
