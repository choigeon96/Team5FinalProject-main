using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class EmployeeService
    {
        public (bool, EmployeeVO) GetLogin(string id, string pwd)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.GetLogin(id,pwd);
        }

        public List<EmployeeVO> GetAllEmployee()
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.GetAllEmployee();
        }

        public List<DeptVO> GetDept()
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.GetDept();
        }

        public bool AddEmployee(EmployeeVO evo)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.AddEmployee(evo);
        }

        public bool UpdateEmployee(EmployeeVO evo)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.UpdateEmployee(evo);
        }

        public bool DeleteEmployee(int emp_id)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.DeleteEmployee(emp_id);
        }

        public bool UpdateDept(List<DeptVO> list)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.UpdateDept(list);
        }

        public bool ExcelImportEmployee(List<EmployeeVO> temp)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.ExcelImportEmployee(temp);
        }

    }
}
