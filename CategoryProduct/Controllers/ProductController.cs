using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryProduct.Controllers
{

    public class ProductController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }
        public IActionResult ProductDetails(int Id)
        {
            ViewBag.detail = Id;
            return View();
        }
    }
}
