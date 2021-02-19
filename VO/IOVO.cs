using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class IOVO
    {
        public DateTime IODate{ get; set; }
        public string Gubun { get; set; }
        public string IOType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string item_type { get; set; }
        public string item_unit { get; set; }
        public string item_grade { get; set; }
        public int IOQty { get; set; }
    }
}
