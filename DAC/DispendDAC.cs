using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using VO;
namespace DAC
{
    public class DispendDAC : CommonDAC
    {
        public List<CodeVO> GetMachineCodes()
        {
            string sql = @"select machine_id code,machine_name name,'MACHINE' category from TBL_MACHINE";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    List<CodeVO> list = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_DispendDAC_GetMachineCode() 오류", err);
                    return null;
                }
            }
        }

        public bool InsertMetarialRelease(List<DispendVO> list, int empID)
        {
            string sql = @"SP_InsertMeterialRelease";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@ins_emp", empID);

                    cmd.Parameters.Add("@wo_id", SqlDbType.Int);
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@mr_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@from_wh", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@to_wh", SqlDbType.NVarChar);

                    foreach (DispendVO dispendVO in list)
                    {
                        cmd.Parameters["@wo_id"].Value = dispendVO.wo_id;
                        cmd.Parameters["@item_id"].Value = dispendVO.item_id;
                        cmd.Parameters["@mr_qty"].Value = dispendVO.required_qty;
                        cmd.Parameters["@from_wh"].Value = dispendVO.in_warehouse;
                        cmd.Parameters["@to_wh"].Value = dispendVO.use_warehouse_id;
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_DispendDAC_InsertMetarialRelease() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }

        public bool MetarialRelease(List<int> selectedRows, int emp_id)
        {
            string sql = @"SP_ReleaseCommit";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@ins_emp", emp_id);
                    cmd.Parameters.Add("@mr_id",SqlDbType.Int);


                    foreach (int mrID in selectedRows)
                    {
                        cmd.Parameters["@mr_id"].Value = mrID;
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_DispendDAC_MetarialRelease() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }

        public List<CodeVO> GetDispendCode()
        {
            string sql = @"select '' code, '전체' name, 'ALL' category
                           union all
                           select '' code, '불출요청' name, 'MR_STATE' category
                           union all
                           select '' code, '완료' name, 'MR_STATE' category
                           union all
                           select cast(warehouse_id as varchar) code,warehouse_name,'WAREHOUSE' category  from TBL_WAREHOUSE
                           union all 
                           select machine_id,machine_name,'MACHINE' category from TBL_MACHINE
                           ";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    List<CodeVO> codes = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    conn.Close();
                    return codes;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_DispendDAC_GetDispendCode() 오류", err);
                    return new List<CodeVO>();
                }
            }
        }

        public List<DispendVO> GetDispendList(DateTime from, DateTime to)
        {
            List<DispendVO> list = new List<DispendVO>();
            string sql = @"select * from VW_MeterialReleaseList
                        where ins_date>=cast(@from as date) and ins_date<=cast(@to as date)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);

                    list = Helper.DataReaderMapToList<DispendVO>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_DispendDAC_GetDispendList() 오류", err);
                    return list;
                }
            }
        }

        public List<DispendVO> GetDispendInfo(int selectedRow)
        {
            List<DispendVO> list;
            string sql = @"select * from VW_DispendDetail where wo_id = @wo_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@wo_id", selectedRow);
                    list = Helper.DataReaderMapToList<DispendVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_DispendDAC_GetDispendInfo() 오류", err);
                    return new List<DispendVO>();
                }
            }
        }


        public List<DispendWOVO> GetWorkOrderList(DateTime from, DateTime to)
        {
            string sql = @"select * from VW_DISPENDORDERS
                           where wo_sdate >= cast(@from as date) and wo_sdate <= cast(@to as date)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    List<DispendWOVO> list = Helper.DataReaderMapToList<DispendWOVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_DispendDAC_GetWorkOrderList() 오류", err);
                    return null;
                }
            }
        }
    }
}
