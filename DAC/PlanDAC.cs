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
    public class PlanDAC : CommonDAC
    {
        public DataTable GetProductionPlan(int plan_id, DateTime start, DateTime end)
        {
            string sql = @"SP_GetProduction_Plan";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@plan_id", plan_id);
                    da.SelectCommand.Parameters.AddWithValue("@start_date", start.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@end_date", end.ToString("yyyy-MM-dd"));

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {

                conn.Close();
                Log.WriteError("DAC_PlanDAC_GetProductionPlan() 오류", err);
                return new DataTable();
            }
        }

        public DataTable GetMeterialPlan(DateTime start, DateTime end)
        {
            string sql = @"SP_GetMeterialReq_Plan";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@start_date", start.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@end_date", end.ToString("yyyy-MM-dd"));

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {

                conn.Close();
                Log.WriteError("DAC_PlanDAC_GetMeterialPlan() 오류", err);
                return new DataTable();
            }
        }

        public DataTable GetOutSourcingPlan(int plan_id, DateTime start, DateTime end)
        {
            string sql = @"SP_GetOutsourcing";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@plan_id", plan_id);
                    da.SelectCommand.Parameters.AddWithValue("@start_date", start.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@end_date", end.ToString("yyyy-MM-dd"));

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {

                conn.Close();
                Log.WriteError("DAC_PlanDAC_GetOutSourcingPlan() 오류", err);
                return new DataTable();
            }
        }

        public int AddProductionPlan(int plan_id, int emp_id)
        {
            string sql = @"SP_AddProductionPlan";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plan_id", plan_id);
                    cmd.Parameters.AddWithValue("@emp_id", emp_id);
                    cmd.Parameters.Add("@return",SqlDbType.Int);
                    cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    
                    conn.Close();
                    return Convert.ToInt32(cmd.Parameters["@return"].Value);
                }
            }
            catch (Exception err)
            {

                conn.Close();
                Log.WriteError("DAC_PlanDAC_GetProductionPlan() 오류", err);
                return -3;
            }
        }


        public List<CodeVO> GetPlan_Id()
        {
            string sql = @"select convert(nvarchar,plan_id) code from TBL_PRODUCTION_PLAN where prod_state = 'false'; ";

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

                conn.Close();
                Log.WriteError("DAC_PlanDAC_GetPlan_Id() 오류", err);
                return new List<CodeVO>();
            }
        }
    }
}
