using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CategoryProduct.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Login log)
        {
            var bilgiler = context.Logins.FirstOrDefault(x => x.UserName == log.UserName && x.Password == log.Password);
            if (bilgiler != null)
            {
                var claims = new List<Claim>

                {
                    new Claim(ClaimTypes.Name, log.UserName)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal); 
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
