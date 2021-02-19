using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class CompanyVO
    {
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string company_type { get; set; }
        public string company_ceo { get; set; }
        public string company_bnum { get; set; }
        public string company_btype { get; set; }
        public string company_manager { get; set; }
        public string company_email { get; set; }
        public string company_phone { get; set; }
        public string company_faxnum { get; set; }
        public string company_use { get; set; }
        public string company_comment { get; set; }
        public DateTime ins_date { get; set; }
        public string ins_emp { get; set; }
        public DateTime up_date { get; set; }
        public string up_emp { get; set; }
        
    }
    public class CompanyCodeVO
    {
        public int company_id { get; set; }
        public string company_name { get; set; }
    }
}
