using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class PerformanceService
    {
        public List<PerformanceVO> GetPerformanceList(DateTime from, DateTime to)
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetPerformanceList(from, to);
        }

        public List<CodeVO> GetAllCodes()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetAllCodes();
        }

        public bool PerformanceCommit(List<int> selectedIDs,int empID)
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.PerformanceCommit(selectedIDs,empID);
        }
        public bool PerformanceCommit2(PerformanceVO vo)
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.PerformanceCommit2(vo);
        }
        public List<PerformanceVO> GetPerformance()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetPerformance();
        }
        public bool PerformanceCh_idUpdate(int per_id, int ch_id)
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.PerformanceCh_idUpdate(per_id, ch_id);
        }
        public bool BadQTY(int ch_id, string bad_type, int bad_qty, string ins_emp)
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.BadQTY(ch_id, bad_type, bad_qty, ins_emp);
        }

        }
}
