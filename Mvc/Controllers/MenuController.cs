
using Mvc.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc
{
    public class MenuController : Controller
    {
        ProductDAC dac = new ProductDAC();

        // GET: Menu
        public PartialViewResult Menu(string category = "")
        {
            ViewBag.SelectedCategory = category;

            List<string> categories = dac.GetCategoryList();
            return PartialView(categories);
        }

    }
}