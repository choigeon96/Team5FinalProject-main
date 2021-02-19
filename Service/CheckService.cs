using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAC;
namespace Service
{
    public class CheckService
    {
        public List<CodeVO> GetCompanyList()
        {
            CheckDAC dac = new CheckDAC();
            return dac.GetCompanyList();
        }

        public List<CheckVO> GetCheckList(DateTime from ,DateTime to)
        {
            CheckDAC dac = new CheckDAC();
            return dac.GetCheckList(from,to);
        }
        public int GetChID(CheckVO vo)
        {
            CheckDAC dac = new CheckDAC();
            return dac.GetChID(vo);
        }
        }
}

