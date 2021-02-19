using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class PriceVO
    {
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string item_unit { get; set; }
        public int item_unit_qty { get; set; }
        public string price_currency { get; set; }
        public decimal now { get; set; }
        public decimal before { get; set; }
        private DateTime _price_sdate;
        public DateTime price_sdate
        {
            get => _price_sdate;
            set => _price_sdate = (Convert.ToDateTime(value.ToShortDateString()));
        }
        private DateTime _price_edate;
        public DateTime price_edate
        {
            get => _price_edate;
            set => _price_edate = (Convert.ToDateTime(value.ToShortDateString()));
        }
        public string price_comment { get; set; }
        public string price_type { get; set; }
    }
    public class ItemCodeVO
    {
        public string item_id { get; set; }
        public string item_name { get; set; }
        public int supply_company { get; set; }
    }

    public class PriceExcelVO
    {
        public string item_id { get; set; }
        public string item_name { get; set; }
        public decimal Price { get; set; }
    }
}
