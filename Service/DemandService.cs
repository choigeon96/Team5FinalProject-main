using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DemandService
    {
        public DataTable GetDemandPlan(DateTime start, DateTime end)
        {
            DAC.DemandDAC dac = new DAC.DemandDAC();
            return dac.GetDemandPlan(start, end);
        }
    }
}
