using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class SalesOrderVO
    {
        public int so_id { get; set; }
        public DateTime plan_date { get; set; }
        public string order_id { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string warehouse_id { get; set; }
        public string warehouse_name { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string so_comment { get; set; }
        public int so_o_qty { get; set; }
        public int so_c_qty { get; set; }
        public int so_s_qty { get; set; }
        public DateTime due_date { get; set; }
        public string mkt { get; set; }
        public string currency { get; set; }
        public string so_state { get; set; }
        public DateTime ins_date { get; set; }
        public string ins_emp { get; set; }
        public DateTime up_date { get; set; }
        public string up_emp { get; set; }

    }

    public class SOVO
    {
        public int so_id { get; set; }
        public DateTime plan_date { get; set; }
        public int po_id { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string warehouse_id { get; set; }
        public string warehouse_name { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string so_comment { get; set; }
        public int so_o_qty { get; set; }
        public int so_c_qty { get; set; }
        public int so_s_qty { get; set; }
        public DateTime due_date { get; set; }
        public string mkt { get; set; }
        public int s_cf_qty { get; set; }
        public int s_cf_price { get; set; }
        public string so_state { get; set; }
        public DateTime up_date { get; set; }
        public string up_emp { get; set; }

        public int SQty { get; set; }
        public int SalesPrice { get; set; }
        public DateTime CloseDate { get; set; }
        public string destination { get; set; }
        public int plan_id { get; set; }

    }
}
