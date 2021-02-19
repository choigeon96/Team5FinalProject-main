using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using VO;
namespace Service
{
    public class CodeService
    {
        public Dictionary<string, List<CodeVO>> GetCommonCode(string[] codes)
        {
            CodeDAC dac = new CodeDAC();
            return dac.GetCommonCode(codes);
        }

        public List<CodeVO> GetAllCommonCode()
        {
            CodeDAC dac = new CodeDAC();
            return dac.GetAllCommonCode();
        }

        public bool AddCommonCode(CodeVO codeVO)
        {
            CodeDAC dac = new CodeDAC();
            return dac.AddCommonCode(codeVO);
        }

        public bool EditCommonCode(CodeVO codeVO)
        {
            CodeDAC dac = new CodeDAC();
            return dac.EditCommonCode(codeVO);
        }

        public bool DeleteCommonCode(List<string> codeList)
        {
            CodeDAC dac = new CodeDAC();
            return dac.DeleteCommonCode(codeList);
        }

        public List<CodeVO> GetAllCodes()
        {
            throw new NotImplementedException();
        }
    }
}
