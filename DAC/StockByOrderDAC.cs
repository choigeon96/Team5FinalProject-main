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
    public class StockByOrderDAC : CommonDAC
    {
        public List<StockByOrderVO> GetMoveList(DateTime from, DateTime to)
        {
            string sql = @"select * from VW_StockByOrder
                           where due_date>=@from and due_date<= @to";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    List<StockByOrderVO> list = Helper.DataReaderMapToList<StockByOrderVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_StockByOrderDAC_GetMoveList() 오류", err);                                                              
                    return new List<StockByOrderVO>();
                }

            }
        }

        public bool MoveToSalesWH(List<StockByOrderVO> selectedVOs, int empID)
        {
            string sql = @"SP_MoveSalesWH";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Transaction = trans;
                try
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.Add("@so_id", SqlDbType.Int);
                    cmd.Parameters.Add("@from", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@to", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar);

                    foreach (StockByOrderVO item in selectedVOs)
                    {
                        cmd.Parameters["@so_id"].Value = item.so_id;
                        cmd.Parameters["@from"].Value = item.From;
                        cmd.Parameters["@to"].Value = item.To;
                        cmd.Parameters["@item_id"].Value = item.item_id;

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
                    Log.WriteError("DAC_StockByOrderDAC_MoveToSalesWH() 오류", err);
                    return false;
                }
            }
        }

        public List<CodeVO> GetCodes()
        {
            string sql = @"select '' code, '전체' name, 'ALL' category
                           union all
                           select item_id, item_name,'ITEM' as category 
                           from TBL_ITEM
                           where item_type in ('GI','FP','SP')
                           union all
                           select cast(warehouse_id as varchar),warehouse_name,'FROM_WAREHOUSE' as category 
                           from TBL_WAREHOUSE
                           where warehouse_type NOT IN ('FAC400','FAC700')
                           union all
                           select cast(warehouse_id as varchar),warehouse_name,'TO_WAREHOUSE' as category 
                           from TBL_WAREHOUSE
                           where warehouse_type = 'FAC400'";
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
                    conn.Close();
                    Log.WriteError("DAC_StockByOrderDAC_GetCodes() 오류", err);
                    return new List<CodeVO>();
                }
            }
        }
    }
}
