using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class MGradeVO
    {
        public int machine_grade { get; set; }
        public string mgrade_name { get; set; }
        public string mgrade_code { get; set; }
        public string mgrade_use { get; set; }
        public string mgrade_comment { get; set; }
        public string mgrade_parent { get; set; }
        public string up_emp { get; set; }
        public DateTime up_date { get; set; }

    }
}
