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

        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public HomeController(UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Music");
                    }
                }
                ModelState.AddModelError("", "hatalı kullanıcı adı ya da şifre girdiniz");
            }
            
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserName = model.UserName;
                user.Email = model.Email;
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    
                }
            }
            return View(model);
        }
    }
}
