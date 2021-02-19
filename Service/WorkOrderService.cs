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
    public class WorkOrderService
    {

        public List<WorkOrderVO> GetWorkOrder()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetWorkOrder();
        }
        public List<WorkOrderVO> GetWorkOrder2()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetWorkOrder2();
        }
        public List<WorkOrderVO> GetWorkOrder3()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetWorkOrder3();
        }

        public List<NewWorkOrderVO> GetNewWorkOrderList(string dateType, DateTime from, DateTime to, bool newWorkOrder = true)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetNewWorkOrderList(dateType, from, to,newWorkOrder);
        }

        public DataTable GetUseInfo(int woID)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetUseInfo(woID);
        }

        public List<CodeVO> GetCodes()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetCodes();
        }

        public List<ItemTimeVO> GetAllItems()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetAllItems();
        }

        public bool CommitWorkOrder(List<int> selectedRows, int emp_id)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.CommitWorkOrder(selectedRows, emp_id);
        }

        public bool InsertWorkOrder(string itemID, int woQty, DateTime startDate, DateTime endDate, string comment, int emp_id)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.InsertWorkOrder(itemID, woQty, startDate, endDate, comment, emp_id);
        }

        public bool DeleteWorkOrder(List<int> selectedRows)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.DeleteWorkOrder(selectedRows);
        }

        public bool UpdateWorkOrder(int wo_id, int woQty, DateTime startDate, DateTime endDate, string comment, int loginEmp)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.UpdateWorkOrder(wo_id, woQty, startDate, endDate, comment, loginEmp);
        }
        public bool StartWorkOrder(int wo_id, string up_emp)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.StartWorkOrder(wo_id, up_emp);
        }
        public bool EndWorkOrder(int wo_id, string up_emp)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.EndWorkOrder(wo_id, up_emp);
        }
    }
}
