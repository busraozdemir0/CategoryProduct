using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryProduct.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return View();
        }
        public IActionResult CategoryDelete(int Id)
        {
            var categoryDelete = context.Categories.Find(Id);
            context.Remove(categoryDelete);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin", "Category");
        }
        [HttpGet]
        public IActionResult CategoryUpdate(int Id)
        {
            var categoryUpdate = context.Categories.Find(Id);
            return View(categoryUpdate);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin" , "Category");
        }
    }
}
