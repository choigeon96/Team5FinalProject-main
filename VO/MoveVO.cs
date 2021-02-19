using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class MoveVO
    {
        public int wo_id { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public int ok_warehouse_id { get; set; }
        public string ok_warehouse_name { get; set; }
        public int use_warehouse_id { get; set; }
        public string use_warehouse_name { get; set; }
        public string item_type { get; set; }
        public int Rqty { get; set; }
        public string item_unit { get; set; }
        public string item_comment { get; set; }
        public int wo_qty { get; set; }
        private DateTime moveDate;
        public DateTime MoveDate
        {
            get
            {
                return moveDate == default ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0) : moveDate;
            }
            set
            {
                moveDate = value;
            }
        }
    }
}
