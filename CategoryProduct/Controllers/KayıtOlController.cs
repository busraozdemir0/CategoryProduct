using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryProduct.Controllers
{  
    public class KayıtOlController : Controller
    {
        Context context = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login log)
        {
            if (ModelState.IsValid)
            {
                context.Logins.Add(log);
                context.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }
        }

    }
}
