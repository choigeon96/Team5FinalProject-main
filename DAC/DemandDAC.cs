using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    public class DemandDAC : CommonDAC
    {
        public DataTable GetDemandPlan(DateTime start, DateTime end)
        {
            string sql = @"SP_GetDemandPlan";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@start_date",start.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@end_date", end.ToString("yyyy-MM-dd"));

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    Dispose();
                    return dt;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_DemandDAC_GetDemandPlan() 오류", err);
                return new DataTable();
            }
        }
    }
}
