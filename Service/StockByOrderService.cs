using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class StockByOrderService
    {
        public List<StockByOrderVO> GetMoveList(DateTime from, DateTime to)
        {
            StockByOrderDAC dac = new StockByOrderDAC();
            return dac.GetMoveList(from, to);
        }

        public List<CodeVO> GetCodes()
        {
            StockByOrderDAC dac = new StockByOrderDAC();
            return dac.GetCodes();
        }

        public bool MoveToSalesWH(List<StockByOrderVO> selectedVOs,int empID)
        {

            StockByOrderDAC dac = new StockByOrderDAC();
            return dac.MoveToSalesWH(selectedVOs,empID);
        }
    }
}
