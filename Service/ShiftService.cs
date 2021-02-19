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
    public class ShiftService
    {
        public List<ShiftVO> GetShift()
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.GetShift();
        }

        public bool AddShift(ShiftVO item)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.AddShift(item);
        }
        public bool Delete(int id)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.DeleteShift(id);
        }

        public bool Update(ShiftVO item)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.UpdateShift(item);
        }
        public DataTable GetShiftInfo(string sday, string eday, string shift,string machine)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.GetShiftInfo(sday,eday,shift, machine);

        }

        }
}
