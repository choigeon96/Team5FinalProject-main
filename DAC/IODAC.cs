using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class IODAC : CommonDAC
    {
        public List<IOVO> GetIOList(DateTime from, DateTime to)
        {
            string sql = @"select cast(IODate as date) IODate,Gubun,IOType,[From],[To],item_id,item_name,item_type,item_unit,item_grade,IOQty from VW_IOList IO
                           where IODate >= cast(@from as date) and IODate <= cast(@to as date)
                           order by IO.IODate desc";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    List<IOVO> list = Helper.DataReaderMapToList<IOVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_IODAC_GetIOList() 오류", err);
                    return new List<IOVO>();
                }
            }
        }

        public List<CodeVO> GetCodes()
        {
            string sql = @"select * from VW_IOCodes";
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
                    Log.WriteError("DAC_IODAC_GetCodes 오류", err);
                    return new List<CodeVO>();
                }
            }
        }
    }
}
