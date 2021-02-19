using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class MoveService
    {
        public List<MoveVO> GetMoveStockList()
        {
            MoveDAC dac = new MoveDAC();
            return dac.GetMoveStockList();
        }

        public bool ApplyMove(List<MoveVO> selectedRows, int empID)
        {
            MoveDAC dac = new MoveDAC();
            return dac.ApplyMove(selectedRows,empID);
        }

        public List<CodeVO> GetCodes()
        {
            MoveDAC dac = new MoveDAC();
            return dac.GetCodes();
        }
    }
}
