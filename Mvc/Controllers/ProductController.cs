using Mvc.DAC;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class ProductController : Controller
    {
        ProductDAC dac = new ProductDAC();
        int pageSize = 5;

        // / 
        // GET: Product/Index?category=레노버&page=2 
        //      Product/Index?category=&page=2
        //      Product/Index?page=1
        public ActionResult Index(string category="", int page=1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                 Products = dac.GetProducts(page, pageSize, category),
                 PagingInfo = new PagingInfo
                 {
                     TotalItems = dac.GetProductTotalCount(category),
                     ItemsPerPage = pageSize,
                     CurrentPage = page
                 },
                 CurrentCategory = category
            };
            return View(model);
        }
    }
}