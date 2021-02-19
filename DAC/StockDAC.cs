using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class StockDAC : CommonDAC
    {
        public List<StockVO> GetStockList()
        {
            string sql = @"select * from VW_StockList
                           order by warehouse_id";
            using (SqlCommand cmd = new SqlCommand(sql,conn))
            {
                try
                {
                    List<StockVO> list = Helper.DataReaderMapToList<StockVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_StockDAC_GetStockList() 오류", err);
                    return new List<StockVO>();
                }
            }
        }

        public List<CodeVO> GetCodes()
        {
            string sql = @"select '' code, '전체' name, 'ALL' category
                           union all
                           select code,name,category from TBL_COMMON_CODE where category='item_type'
                           union all
                           select cast(warehouse_id as nvarchar) code,warehouse_name name, 'WAREHOUSE' category from TBL_WAREHOUSE";
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
                    Log.WriteError("DAC_StockDAC_GetCodes() 오류", err);
                    return new List<CodeVO>();
                }
            }
        }
    }
}
