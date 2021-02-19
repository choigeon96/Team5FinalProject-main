using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class BOMService
    {
        public List<CodeVO> GetBOMCode()
        {
            DAC.BOMDAC dac = new DAC.BOMDAC();
            return dac.GetBOMCode();
        }

        public bool AddBOM(List<BOMVO> insertList)
        {
            DAC.BOMDAC dac = new DAC.BOMDAC();
            return dac.AddBOM(insertList);
        }

        public List<BOMVO> GetBOMForward(string itemid, DateTime date)
        {
            DAC.BOMDAC dac = new DAC.BOMDAC();
            return dac.GetBOMForward(itemid, date);
        }

        public bool EditBOM(List<BOMVO> insertInfo)
        {
            DAC.BOMDAC dac = new DAC.BOMDAC();
            return dac.EditBOM(insertInfo);
        }

        public List<BOMVO> GetBOMReverse(string itemid, DateTime date)
        {
            DAC.BOMDAC dac = new DAC.BOMDAC();
            return dac.GetBOMReverse(itemid, date);
        }
    }
}
