using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class StockByOrderVO
    {
        public int so_id { get; set; }
        public string company_name { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string item_unit { get; set; }
        public DateTime so_date{ get; set; }
        public DateTime due_date{ get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int stock { get; set; }
        public string so_comment{ get; set; }
        public int MoveQty { get; set; }
    }
}
