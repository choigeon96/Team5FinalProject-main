using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class PurchasesVO
    {
        public int supply_company { get; set; }
        public string company_name { get; set; }
        public string item_name { get; set; }
        public string item_id { get; set; }
        public int p_qty { get; set; }
        public string in_warehouse { get; set; }
        public string warehouse_name { get; set; }
        public DateTime DueDate { get; set; }
        public int prod_id { get; set; }
    }
    public class PurchasesListVO
    {
        public int purchase_id { get; set; }
        public int pd_id { get; set; }
        public string company_name { get; set; }
        public string purchase_state { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string unit { get; set; }
        public DateTime due_date { get; set; }
        public int pd_qty { get; set; }
        public int in_qty { get; set; }
        public int in_cqty { get; set; }
        public int Cancellable { get; set; }
        public DateTime ins_date { get; set; }
        public string emp_name{ get; set; }
        public int company_id { get; set; }
    }
}
