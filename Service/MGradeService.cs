using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class MGradeService
    {
        public List<MGradeVO> GetMGrade()
        {
            MGradeDAC dac = new MGradeDAC();
            return dac.GetMGrade();
        }
        public bool InsertMGrade(MGradeVO vo)
        {
            MGradeDAC dac = new MGradeDAC();
            return dac.InsertMGrade(vo);
        }

        public bool UpdateMGrade(MGradeVO vo)
        {
            MGradeDAC dac = new MGradeDAC();
            return dac.UpdateMGrade(vo);
        }

        public bool DeleteMGrade(int machine_grade)
        {
            MGradeDAC dac = new MGradeDAC();
            return dac.DeleteMGrade(machine_grade);
        }

        public bool ExcelImportMGrade(List<MGradeVO> temp)
        {
            MGradeDAC dac = new MGradeDAC();
            return dac.ExcelImportMGrade(temp);
        }

        //public List<MachineVO> GetMachine()
        //{
        //    MachineDAC dac = new MachineDAC();
        //    return dac.GetMachine();
        //}
        //public List<MachineVO> GetMachine()
        //{
        //    MachineDAC dac = new MachineDAC();
        //    return dac.GetMachine();
        //}
        //public List<MachineVO> GetMachine()
        //{
        //    MachineDAC dac = new MachineDAC();
        //    return dac.GetMachine();
        //}
        //public List<MachineVO> GetMachine()
        //{
        //    MachineDAC dac = new MachineDAC();
        //    return dac.GetMachine();
        //}
    }
}
