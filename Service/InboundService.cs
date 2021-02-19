using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using VO;
namespace Service
{
    public class InboundService
    {
        public List<InboundVO> GetPurchasesList(DateTime from, DateTime to)
        {
            InboundDAC dac = new InboundDAC();
            return dac.GetPurchasesList(from, to);
        }

        public bool NewInbound(List<InboundVO> selectedRows)
        {
            InboundDAC dac = new InboundDAC();
            return dac.NewInbound(selectedRows);
        }

        public List<CodeVO> GetAllCodes()
        {
            InboundDAC dac = new InboundDAC();
            return dac.GetAllCodes();
        }

        public List<InboundVO> GetWaitList(DateTime from, DateTime to)
        {
            InboundDAC dac = new InboundDAC();
            return dac.GetWaitList(from, to);
        }

        public List<InboundVO> GetWaitDetail(int pdID)
        {
            InboundDAC dac = new InboundDAC();
            return dac.GetWaitDetail(pdID);

        }

        public bool InboundCommit(List<int> selectedRows)
        {
            InboundDAC dac = new InboundDAC();
            return dac.InboundCommit(selectedRows);
        }

        public List<CodeVO> GetInboundCodes()
        {
            InboundDAC dac = new InboundDAC();
            return dac.GetInboundCodes();
        }

        public (List<InboundVO>, List<CodeVO>) GetInboundList(DateTime from, DateTime to)
        {
            InboundDAC dac = new InboundDAC();
            return dac.GetInboundList(from, to);
        }

        public bool InboundCancel(List<InboundVO> changedList)
        {
            InboundDAC dac = new InboundDAC();
            return dac.GetInboundList(changedList);
        }
    }
}
