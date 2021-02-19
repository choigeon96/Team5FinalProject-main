using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class MachineVO
    {
            public string machine_id                   {get; set;}
            public int machine_grade                {get; set;}
            public string machine_name                 {get; set;}
            public string use_warehouse_id             {get; set;}
            public string ok_warehouse_id              {get; set;}
            public string ng_warehouse_id              {get; set;}
            public int m_os_use                     {get; set;}
            public string mcachine_comment             {get; set;}
            public string machine_use                  {get; set;}
            public DateTime ins_date                     {get; set;}
            public string ins_emp                      {get; set;}
            public DateTime up_date                      {get; set;}
            public string up_emp                       {get; set;}
    }

    public class MachinesVO
    {
        public string machine_id { get; set; }
        public int machine_grade { get; set; }
        public string machine_name { get; set; }
        public string use_warehouse_id { get; set; }
        public string ok_warehouse_id { get; set; }
        public string ng_warehouse_id { get; set; }
        public string m_os_use { get; set; }
        public string machine_comment { get; set; }
        public string machine_use { get; set; }
        public DateTime up_date { get; set; }
        public string up_emp { get; set; }

    }
}
