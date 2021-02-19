using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class CodeDAC : CommonDAC
    {
        /// <summary>
        /// 공통코드를 불러오는 메서드
        /// </summary>
        /// <param name="categorys">불러올 카테고리명의 집합</param>
        /// <returns> Dictionary<[카테고리명],List<CodeVO>> </CodeVO> </returns>
        public Dictionary<string, List<CodeVO>> GetCommonCode(string[] categorys)
        {
            string sql = @"select code,name from TBL_COMMON_CODE where category = @category order by code";
            Dictionary<string, List<CodeVO>> codeList = new Dictionary<string, List<CodeVO>>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@category", SqlDbType.NVarChar);
                    foreach (string category in categorys)
                    {
                        cmd.Parameters["@category"].Value = category;
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<CodeVO> temp = Helper.DataReaderMapToList<CodeVO>(reader);
                        codeList.Add(category, temp);
                        reader.Close();
                    }
                    conn.Close();
                    return codeList;
                }
            }
            catch (Exception err)
            {
                Log.WriteError("코드 정보를 불러오는중 오류 발생" + err.Message);
                return null;
            }
        }

        /// <summary>
        /// 선택한 공통코드 삭제
        /// </summary>
        /// <param name="codeList">삭제할 코드 목록</param>
        /// <returns></returns>
        public bool DeleteCommonCode(List<string> codeList)
        {
            string sql = @"delete from TBL_COMMON_CODE where code = @code";
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Transaction = trans;
                    cmd.Parameters.Add("@code",SqlDbType.NVarChar);
                    foreach (string item in codeList)
                    {
                        cmd.Parameters["@code"].Value = item;
                        cmd.ExecuteNonQuery();
                    }
                    
                    trans.Commit();
                    conn.Close();

                    return true;
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Log.WriteError("DAC_CodeDAC_DeleteCommonCode() 오류", err);
                return false;
            }
        }

        /// <summary>
        /// 공통코드 수정
        /// </summary>
        /// <param name="codeVO">수정할 공통코드 정보</param>
        /// <returns></returns>
        public bool EditCommonCode(CodeVO codeVO)
        {
            string sql = @"Update TBL_COMMON_CODE set category = @category, name = @name, pcode = @pcode where code = @code";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@code", codeVO.code);
                    cmd.Parameters.AddWithValue("@category", codeVO.category);
                    cmd.Parameters.AddWithValue("@name", codeVO.name);
                    cmd.Parameters.AddWithValue("@pcode", string.IsNullOrEmpty(codeVO.pcode) ? (object)DBNull.Value : codeVO.pcode);


                    int result = cmd.ExecuteNonQuery();
                    conn.Close();

                    return result > 0 ? true : false;
                }
            }
            catch (Exception err)
            {
                Log.WriteError("DAC_CodeDAC_EditCommonCode() 오류", err);
                return false;
            }
        }

        /// <summary>
        /// 공통코드 등록
        /// </summary>
        /// <param name="codeVO"></param>
        public bool AddCommonCode(CodeVO codeVO)
        {
            string sql = @"insert into TBL_COMMON_CODE([code], [category], [name], [pcode]) values (@code,@category,@name,@pcode) ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@code", codeVO.code);
                    cmd.Parameters.AddWithValue("@category", codeVO.category);
                    cmd.Parameters.AddWithValue("@name", codeVO.name);
                    cmd.Parameters.AddWithValue("@pcode", string.IsNullOrEmpty(codeVO.pcode) ? (object)DBNull.Value: codeVO.pcode);
                    

                    int result = cmd.ExecuteNonQuery();
                    conn.Close();

                    return result > 0 ? true : false;
                }
            }
            catch (Exception err)
            {
                Log.WriteError("DAC_CodeDAC_AddCommonCode() 오류", err);
                return false;
            }
        }



        /// <summary>
        /// 모든 공통코드 리스트를 불러옴
        /// </summary>
        /// <returns></returns>
        public List<CodeVO> GetAllCommonCode()
        {
            string sql = @"select code, category ,name, pcode  from TBL_COMMON_CODE order by category, code";
           
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<CodeVO> temp = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                Log.WriteError("DAC_CodeDAC_GetAllCommonCode() 오류", err);
                return new List<CodeVO>();
            }
        }
    }
}
