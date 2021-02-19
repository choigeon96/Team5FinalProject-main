using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class PlanService
    {
        public DataTable GetProductionPlan(int plan_id, DateTime start, DateTime end)
        {
            DAC.PlanDAC dac = new DAC.PlanDAC();
            return dac.GetProductionPlan(plan_id, start, end);
        }
        public DataTable GetOutSourcingPlan(int plan_id, DateTime start, DateTime end)
        {
            DAC.PlanDAC dac = new DAC.PlanDAC();
            return dac.GetOutSourcingPlan(plan_id, start, end);
        }
        public int AddProductionPlan(int plan_id, int emp_id)
        {
            DAC.PlanDAC dac = new DAC.PlanDAC();
            return dac.AddProductionPlan(plan_id, emp_id);
        }

        public List<CodeVO> GetPlan_Id()
        {
            DAC.PlanDAC dac = new DAC.PlanDAC();
            return dac.GetPlan_Id();
        }

        public DataTable GetMeterialPlan(DateTime start, DateTime end)
        {
            DAC.PlanDAC dac = new DAC.PlanDAC();
            return dac.GetMeterialPlan(start, end);
        }
    }
}
