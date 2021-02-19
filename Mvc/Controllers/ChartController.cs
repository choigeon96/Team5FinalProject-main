using Mvc.DAC;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class ChartController : Controller
    {
       //  GET: Chart
        public ActionResult Index()
        {
            //주문데이터를 조회해서 제일 많이 팔리는 상품3개의 판매정보를 데이터로 바인딩
            OrderDAC dac = new OrderDAC();
            List<OrderStats> list = dac.GetOrderBestProduct();

            StringBuilder sb = new StringBuilder();

            var statGroup = from stat in list
                            orderby stat.MM
                            group stat by stat.ProductName;

            int k = 1;
            foreach (var prodGroup in statGroup)
            {
                List<int> qtys = new List<int>();
                foreach (var prodStat in prodGroup)
                {
                    qtys.Add(prodStat.Qty);

                    if (k == 1)
                        sb.Append(prodStat.MM + "월,");
                }

                if (k == 1)
                {
                    ViewBag.Label1 = prodGroup.Key;
                    ViewBag.data1 = "[" + string.Join(",", qtys.ToArray()) + "]";
                }
                else if (k == 2)
                {
                    ViewBag.Label2 = prodGroup.Key;
                    ViewBag.data2 = "[" + string.Join(",", qtys.ToArray()) + "]";
                }
                else if (k == 3)
                {
                    ViewBag.Label3 = prodGroup.Key;
                    ViewBag.data3 = "[" + string.Join(",", qtys.ToArray()) + "]";
                }

                k++;
            }

            ViewBag.Labels = sb.ToString().TrimEnd(','); //"1월,2월,3월,....12월"

            //Digital Goods
            //"[28, 48, 40, 19, 86, 27, 90]"
            return View();
        }
    }
}