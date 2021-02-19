using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class PerformanceVO
    {
        public int performance_id { get; set; }
        public int wo_id { get; set; }
        public DateTime wo_sdate{ get; set; }
        public string machine_id { get; set; }
        public string machine_name { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string wo_state { get; set; }
        public string good_wh { get; set; }
        public string bad_wh { get; set; }
        public int wo_qty { get; set; }
        public int good_qty { get; set; }
        public int Rqty { get; set; }
	
        public int performance_qty { get; set; }
        public string ins_emp { get; set; }
        public string p_state { get; set; }

        public int ch_id { get; set; }
        public int bad_qty { get; set; }

        
            public string emp_name { get; set; }



    }
}
