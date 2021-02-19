using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class FactoryVO
    {
        public string factory_grade { get; set; }
        public string factory_type { get; set; }
        public string factory_name { get; set; }
        public string factory_parent { get; set; }
        public string factory_comment { get; set; }
        public string factory_use { get; set; }
        public int up_emp { get; set; }
        public DateTime up_date { get; set; }
        public int factory_id { get; set; }
        public string codename { get; set; }
        public int warehouse_id { get; set; }

    }

    public class WareHouseVO
    {
        public string warehouse_type { get; set; }
        public string warehouse_name { get; set; }
        public string factory_use { get; set; }
        public int up_emp { get; set; }
        public DateTime up_date { get; set; }
        public int factory_id { get; set; }
        public int warehouse_id { get; set; }
        public string factory_comment { get; set; }

    }
}
