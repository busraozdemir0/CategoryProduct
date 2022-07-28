using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryProduct.ViewComponents
{
    public class ProductDetailPage : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke(int id)
        {
            var productList = context.Products.ToList().Where(x => x.ProductId == id);
            return View(productList);
        }
    }
}
