using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class CheckVO
    {
        public int ch_id { get; set; }
        public DateTime ins_date { get ; set; }
        public string company_name { get; set; }
        public string item_id { get; set; }
        public string item_name{ get; set; }
        public string unit { get; set; }
        public int ch_qty { get; set; }
        public int good_qty{ get; set; }
        public int bad_qty{ get; set; }
        public string bad_comment { get; set; }

        public string emp { get; set; }
        public string emp_name { get; set; }
    }
}
