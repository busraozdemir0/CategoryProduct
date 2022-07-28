using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryProduct.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult ProductAdd()
        {
            List<SelectListItem> categoryList = (from x in context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.v1 = categoryList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(Product product)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.imageUrl.FileName);
                string extension = Path.GetExtension(product.imageUrl.FileName);
                product.imagePath = fileName = fileName + extension;
                string path = Path.Combine("wwwroot/images/", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await product.imageUrl.CopyToAsync(filestream);
                }
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index", "Admin", "Product");
            }
            else
            {
                return View();
            }
        }
        public IActionResult ProductDelete(int Id)
        {
            var productDelete = context.Products.Find(Id);
            context.Remove(productDelete);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin","Product");
        }
        [HttpGet]
        public IActionResult ProductUpdate(int Id)
        {
            var productUpdate = context.Products.Find(Id);
            List<SelectListItem> categoryList = (from y in context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = y.CategoryName,
                                                     Value = y.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.v2 = categoryList;
            return View(productUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(Product product)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.imageUrl.FileName);
                string extension = Path.GetExtension(product.imageUrl.FileName);
                product.imagePath = fileName = fileName + extension;
                string path = Path.Combine("wwwroot/images/", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await product.imageUrl.CopyToAsync(filestream);
                }
                context.Products.Update(product);
                context.SaveChanges();
                return RedirectToAction("Index", "Admin","Product");
            }
            else
            {
                return View();
            }
        }
    }
}
