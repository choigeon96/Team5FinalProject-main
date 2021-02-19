using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAC;  
namespace Service
{
    public class DispendService
    {
        public List<CodeVO> GetMachineCodes()
        {
            DispendDAC dac = new DispendDAC();
            return dac.GetMachineCodes();
        }

        public List<DispendWOVO> GetWorkOrderList(DateTime from, DateTime to)
        {
            DispendDAC dac = new DispendDAC();
            return dac.GetWorkOrderList(from,to);
        }

        public List<DispendVO> GetDispendInfo(int selectedRow)
        {
            DispendDAC dac = new DispendDAC();
            return dac.GetDispendInfo(selectedRow);
        }

        public bool InsertMetarialRelease(List<DispendVO> list,int empID)
        {
            DispendDAC dac = new DispendDAC();
            return dac.InsertMetarialRelease(list,empID);
        }

        public List<DispendVO> GetDispendList(DateTime from, DateTime to)
        {
            DispendDAC dac = new DispendDAC();
            return dac.GetDispendList(from,to);
        }

        public List<CodeVO> GetDispendCode()
        {
            DispendDAC dac = new DispendDAC();
            return dac.GetDispendCode();
        }

        public bool MetarialRelease(List<int> selectedRows, int emp_id)
        {
            DispendDAC dac = new DispendDAC();
            return dac.MetarialRelease(selectedRows,emp_id);
        }
    }
}
