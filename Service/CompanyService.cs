using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class CompanyService
    {
        public List<CompanyVO> GetCompany()
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.GetCompany();
        }

        public bool UpdateCompany(CompanyVO vo)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.UpdateCompany(vo);
        }

        public bool InsertCompany(CompanyVO vo)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.InsertCompany(vo);
        }

        public bool DeleteCompany(int company_id)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.DeleteCompany(company_id);
        }

        public bool ExcelImportCompany(List<CompanyVO> temp)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.ExcelImportCompany(temp);
        }
    }
}
