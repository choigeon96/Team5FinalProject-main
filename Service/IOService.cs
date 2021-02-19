using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class IOService
    {
        public List<IOVO> GetIOList(DateTime from, DateTime to)
        {
            IODAC dac = new IODAC();
            return dac.GetIOList(from, to);
        }

        public List<CodeVO> GetCodes()
        {
            IODAC dac = new IODAC();
            return dac.GetCodes();
        }
    }
}

