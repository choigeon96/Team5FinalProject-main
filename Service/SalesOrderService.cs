using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class SalesOrderService
    {
        public bool CommitSO(List<SalesOrderVO> list)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.CommitSO(list);
        }

        public List<CodeVO> GetAllCodes()
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.GetAllCodes();
        }

        public List<SalesOrderVO> GetAllSO(DateTime from, DateTime to)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.GetAllSO(from,to);
        }

        public bool InsertSO(SalesOrderVO so)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.InsertSO(so);
        }

        public bool UpdateSO(SalesOrderVO so)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.UpdateSO(so);
        }

        public bool RegDemandPlan(List<SalesOrderVO> demandList)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.RegDemandPlan(demandList);
        }

        public List<SOVO> GetSOList()
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.GetSOList();
        }

        public bool MaGamProcess(List<SOVO> chklist)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.MaGamProcess(chklist);
        }

        public List<SOVO> GetSOClose()
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.GetSOClose();
        }

        public bool MaGamCencel(List<SOVO> chklist)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            return dac.MaGamCencel(chklist);
        }
    }
}
