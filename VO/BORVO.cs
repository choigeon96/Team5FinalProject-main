using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class BORVO
    {
        public int Bor_id { get; set; }
        public string Item_id { get; set; }
        public string Item_name { get; set; }
        public string Bor_route { get; set; }
        public string Bor_route_name { get; set; }
        public string Machine_id { get; set; }
        public string Machine_name { get; set; }
        public int? Priority { get; set; }
        public int Tacktime { get; set; }
        public int? preceding_days { get; set; }
        public decimal? Completion_rate { get; set; }
        public string Bor_use { get; set; }
        public string Bor_comment { get; set; }
        public DateTime Ins_date { get; set; }
        public int? Ins_emp { get; set; }
        public string emp_name { get; set; }
    }
}
