using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class DispendWOVO
    {
        public DateTime wo_sdate { get; set; }
        public int wo_id { get; set; }
        public string machine_id { get; set; }
        public string machine_name { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public int wo_qty { get; set; }
        public string unit { get; set; }
        public string wo_state { get; set; }
    }
    public  class DispendVO
    {
        public DateTime wo_sdate{ get; set; }
        public int wo_id { get; set; }
        public string machine_name { get; set; }
        public string in_warehouse { get; set; }
        public string use_warehouse_id { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string item_unit { get; set; }
        public int stock { get; set; }
        public int required_qty { get; set; }
        public string wo_state { get; set; }
        public DateTime requestDate { get; set; }
        public DateTime ins_date{ get; set; }
        public string item_type { get; set; }
        public string to_warehouse_id { get; set; }
        public string from_warehouse_id { get; set; }
        public int mr_qty { get; set; }
        public string mr_state { get; set; }
        public int mr_id { get; set; }

    }
}
