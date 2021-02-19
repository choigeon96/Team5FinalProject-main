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
    public class MoveDAC : CommonDAC
    {
        public List<MoveVO> GetMoveStockList()
        {
            string sql = @"select * from VW_NeedMoveList
                           order by wo_id";
            using (SqlCommand cmd = new SqlCommand(sql,conn))
            {
                try
                {
                    List<MoveVO> list = Helper.DataReaderMapToList<MoveVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_MoveDAC_GetMoveStockList() 오류", err);
                    return new List<MoveVO>();
                }
            }
        }

        public List<CodeVO> GetCodes()
        {
            string sql = @"select * from VW_MoveCodes";
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
                    conn.Close();
                    Log.WriteError("DAC_MoveDAC_GetCodes() 오류", err);
                    return new List<CodeVO>();
                }
            }
        }

        public bool ApplyMove(List<MoveVO> selectedRows, int empID)
        {
            string sql = @"SP_ApplyMove";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql,conn))
            {
                cmd.Transaction = trans;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.AddWithValue("@ins_emp", empID);

                    cmd.Parameters.Add("@wo_id", SqlDbType.Int);
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@wo_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@from", SqlDbType.Int);
                    cmd.Parameters.Add("@to", SqlDbType.Int);

                    foreach (MoveVO move in selectedRows)
                    {
                        cmd.Parameters["@wo_id"].Value = move.wo_id;
                        cmd.Parameters["@item_id"].Value = move.item_id;
                        cmd.Parameters["@wo_qty"].Value = move.wo_qty;
                        cmd.Parameters["@from"].Value = move.ok_warehouse_id;
                        cmd.Parameters["@to"].Value = move.use_warehouse_id;

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception err)
                {
                    trans.Rollback();
                    conn.Close();
                    Log.WriteError("DAC_MoveDAC_GetMoveStockList() 오류", err);
                    return false;
                }
                
            }
        }
    }
}
