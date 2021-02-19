using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class OrderDraftVO
    {
        public string item_name { get; set; }
        public int pd_qty { get; set; }
        public string item_unit { get; set; }
        public decimal price { get; set; }
        public DateTime due_date { get; set; }
        public string item_comment { get; set; }
    }
}
