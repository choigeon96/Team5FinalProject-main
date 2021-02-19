using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class BORService
    {
        public List<CodeVO> GetBORCode()
        {
            DAC.BORDAC dac = new DAC.BORDAC();
            return dac.GetBORCode();
        }

        public bool AddBORList(List<BORVO> insertList)
        {
            DAC.BORDAC dac = new DAC.BORDAC();
            return dac.AddBORList(insertList);
        }

        public List<BORVO> GetBORList()
        {
            DAC.BORDAC dac = new DAC.BORDAC();
            return dac.GetBORList();
        }

        public bool EditBOR(BORVO insertInfo)
        {
            DAC.BORDAC dac = new DAC.BORDAC();
            return dac.EditBOR(insertInfo);
        }
    }
}
