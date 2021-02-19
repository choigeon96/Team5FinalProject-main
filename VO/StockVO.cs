using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class StockVO
    {
        public int warehouse_id { get; set; }
        public string warehouse_name { get; set; }
        public string item_id { get; set; }
        public string item_name{ get; set; }
        public string item_type{ get; set; }
        public string item_unit{ get; set; }
        public int stock { get; set; }
        public string item_grade { get; set; }
        public string item_comment{ get; set; }
    }
}
