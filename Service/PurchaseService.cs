using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class PurchaseService
    {
        public DataTable GetDGVInfo(DateTime from, DateTime to)
        {
            PurchaseDAC dac = new PurchaseDAC();
            return dac.GetDGVInfo(from, to);
        }

        public List<PurchasesVO> GetPurchasesDemand()
        {
            PurchaseDAC dac = new PurchaseDAC();
            return dac.GetPurchasesDemand();
        }

        public bool NewPurchases(List<PurchasesVO> selectedRows)
        {
            PurchaseDAC dac = new PurchaseDAC();
            return dac.NewPurchases(selectedRows);
        }

        public List<PurchasesListVO> GetPurchasesList(DateTime from, DateTime to)
        {
            PurchaseDAC dac = new PurchaseDAC();
            return dac.GetPurchasesList(from,to);
        }

        public bool DeletePurchases(List<int> selectedRows)
        {
            PurchaseDAC dac = new PurchaseDAC();
            return dac.DeletePurchases(selectedRows);
        }

        public bool UpdateDueDate(int pdID, DateTime dueDate)
        {
            PurchaseDAC dac = new PurchaseDAC();
            return dac.UpdateDueDate(pdID,dueDate);
        }

        public List<CodeVO> GetAllCodes()
        {
            PurchaseDAC dac = new PurchaseDAC();
            return dac.GetAllCodes();
        }

        public (CompanyVO, DataTable) GetOrderDraftInfo(PurchasesListVO purchasesListVO)
        {
            PurchaseDAC dac = new PurchaseDAC();
            return dac.GetOrderDraftInfo(purchasesListVO);
        }
    }
}
