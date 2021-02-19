using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class StockService
    {
        public List<StockVO> GetStockList()
        {
            StockDAC dac = new StockDAC();
            return dac.GetStockList();
        }

        public List<CodeVO> GetCodes()
        {
            StockDAC dac = new StockDAC();
            return dac.GetCodes();
        }
    }
}
