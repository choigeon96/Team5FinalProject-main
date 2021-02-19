using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class ShipmentService
    {
        public List<ShipmentVO> GetTargetList(DateTime from, DateTime to)
        {
            ShipmentDAC dac = new ShipmentDAC();
            return dac.GetTargetList(from, to);
        }

        public List<CodeVO> GetShipmentCodes()
        {
            ShipmentDAC dac = new ShipmentDAC();
            return dac.GetShipmentCodes();
        }

        public bool RegShipment(List<ShipmentVO> selectedRows,int empID)
        {
            ShipmentDAC dac = new ShipmentDAC();
            return dac.RegShipment(selectedRows,empID);
        }

        public List<ShipmentVO> GetShipmentList(DateTime from, DateTime to)
        {
            ShipmentDAC dac = new ShipmentDAC();
            return dac.GetShipmentList(from, to);
        }
    }
}
