using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class InboundVO
    {
        public int purchase_id { get; set; }
        public int pd_id { get; set; }
        public int prod_id { get; set; }
        public int item_unit_qty { get; set; }
        public DateTime PurchasesDate { get; set; }
        public string company_name { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string unit { get; set; }
        public string UseCheck { get; set; }
        public int pd_qty { get; set; }
        public int InQty { get; set; }
        public int CQty { get; set; }
        public int RQty { get; set; }
        public string in_warehouse { get; set; }
        public int warehouse_id { get; set; }
        public DateTime due_date { get; set; }
        public DateTime ins_date { get; set; }
        public DateTime InboundDate{ get=> new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);}
        public int in_id { get; set; }
    }
}
