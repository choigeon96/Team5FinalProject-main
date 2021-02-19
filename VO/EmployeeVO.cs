using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class EmployeeVO
    {
        public int emp_id { get; set; }
        public string emp_password { get; set; }
        public string emp_name { get; set; }
        public string dept_no { get; set; }
        public DateTime hire_date { get; set; }
        public DateTime up_date { get; set; }
        public string up_emp { get; set; }
        public string dept_name { get; set; }
    }

    public class DeptVO
    {
        public int dept_id { get; set; }
        public string dept_name { get; set; }
    }
}
