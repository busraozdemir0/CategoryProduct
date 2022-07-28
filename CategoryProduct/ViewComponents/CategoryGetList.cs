using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryProduct.ViewComponents
{
    public class CategoryGetList:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
    }
}
