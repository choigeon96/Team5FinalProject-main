using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class ShipmentVO
    {
        public int so_id { get; set; }
        public string order_id { get; set; }
        public DateTime due_date { get; set; }
        public int plan_id { get; set; }
        public int out_warehouse { get; set; }
        public int company_id{ get; set; }
        public string company_name { get; set; }
        public int DestinationID { get; set; }
        public string DestinationName { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public int Qty { get; set; }
        public int NewQty { get; set; }
        public int SQty { get; set; }
        public int CQty { get; set; }
        public int RQty { get; set; }
        public DateTime ship_date { get; set; }
    }
}
