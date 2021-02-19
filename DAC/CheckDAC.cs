using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class CheckDAC : CommonDAC
    {
        public List<CodeVO> GetCompanyList()
        {
            string sql = @"select company_name name, company_id code 
                            from TBL_CHECK_HISTORY CH JOIN TBL_ITEM I ON CH.item_id = I.item_id 
						                              JOIN TBL_COMPANY C ON C.company_id = I.supply_company";
            List<CodeVO> codes = new List<CodeVO>();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    codes = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    return codes;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_CheckDAC_GetCompanyList() 오류", err);
                    return null;
                }
            }

        }

        public List<CheckVO> GetCheckList(DateTime from, DateTime to)
        {
            string sql = @"select CH.ch_id,cast(CH.ins_date as date) ins_date,emp_name,CH.item_id,I.item_name,CD.name unit,ch_qty,good_qty,CH.bad_qty,CD2.name bad_comment
from TBL_CHECK_HISTORY CH JOIN TBL_ITEM I ON CH.item_id = I.item_id
						  LEFT JOIN TBL_BAD B ON CH.ch_id = B.ch_id
						  JOIN TBL_COMMON_CODE CD ON CD.code = I.item_unit
						  JOIN TBL_COMMON_CODE CD2 ON CD2.code = B.bad_type
						  LEFT JOIN TBL_Employee E ON E.emp_id = CH.ins_emp
where CH.ins_date>=@from and CH.ins_date<=@to";
            List<CheckVO> list = new List<CheckVO>();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    list = Helper.DataReaderMapToList<CheckVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_CheckDAC_GetCheckList() 오류", err);
                    return null;
                }
            }

        }


        public int GetChID(CheckVO vo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"insert into TBL_CHECK_HISTORY (item_id,ch_qty,good_qty,bad_qty,ins_date,ins_emp)
                                        values (@item_id,@ch_qty,@good_qty,@bad_qty,@ins_date,@ins_emp);
                                        select @@IDENTITY; ";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@item_id", vo.item_id);
                    cmd.Parameters.AddWithValue("@ch_qty", vo.ch_qty);
                    cmd.Parameters.AddWithValue("@good_qty", vo.good_qty);
                    cmd.Parameters.AddWithValue("@bad_qty", vo.bad_qty);
                    cmd.Parameters.AddWithValue("@ins_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ins_emp", vo.emp);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    Dispose();

                    return id;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_CheckDAC_GetChID() 오류", err);

                return -1;
            }
        }
    }
}
