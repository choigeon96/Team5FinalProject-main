using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class BOMDAC : CommonDAC
    {

        /// <summary>
        /// BOM정보를 
        /// </summary>
        /// <returns></returns>
        public List<CodeVO> GetBOMCode()
        {
            string sql = @"select code, category ,name from VW_BOMCBO";

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
                Log.WriteError("DAC_BOMDAC_GetBOMCode() 오류", err);
                return new List<CodeVO>();
            }
        }

        public bool EditBOM(List<BOMVO> insertinfo)
        {
            string sql = @"Update TBL_BOM 
                             set  bom_parent_id   = @bom_parent_id,
						          item_id         = @item_id,
						          bom_use_qty     = @bom_use_qty,
						          start_date      = @start_date,
						          end_date        = @end_date,
						          bom_use         = @bom_use,
						          plan_use        = @plan_use,
						          auto_deduction  = @auto_deduction,
						          bom_comment     = @bom_comment,
						          up_date         = @up_date,
						          up_emp          = @up_emp
                           where bom_id = @bom_id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@bom_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bom_parent_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bom_use_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@start_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@end_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@bom_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@plan_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@auto_deduction", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bom_comment", System.Data.SqlDbType.Text);
                   
                    cmd.Parameters.Add("@up_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@up_emp", System.Data.SqlDbType.Int);

                    foreach (var vo in insertinfo)
                    {
                        cmd.Parameters["@bom_id"].Value = vo.bom_id;
                        cmd.Parameters["@bom_parent_id"].Value = vo.bom_parent_id;
                        cmd.Parameters["@item_id"].Value = vo.item_id;
                        cmd.Parameters["@bom_use_qty"].Value = vo.bom_use_qty;
                        cmd.Parameters["@start_date"].Value = vo.start_date;
                        cmd.Parameters["@end_date"].Value = vo.end_date;
                        cmd.Parameters["@bom_use"].Value = vo.bom_use;
                        cmd.Parameters["@auto_deduction"].Value = vo.auto_deduction;
                        cmd.Parameters["@plan_use"].Value = vo.plan_use;
                        cmd.Parameters["@bom_comment"].Value = vo.bom_comment == "" ? (object)DBNull.Value : vo.bom_comment;
                        cmd.Parameters["@up_emp"].Value = vo.ins_emp;
                        cmd.Parameters["@up_date"].Value = vo.ins_date;
                    }
                    int result = cmd.ExecuteNonQuery();



                    
                    conn.Close();
                    return result > 0 ? true : false;
                }
            }
            catch (Exception err)
             {
                conn.Close();
                Log.WriteError("DAC_BOMDAC_EditBOM() 오류", err);
                return false;
            }
        }

        /// <summary>
        /// BOM 역전개 정보를 가져옵니다.
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<BOMVO> GetBOMReverse(object itemid, object date)
        {
            string sql = @"SP_Reverse";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Item_id", itemid);
                    cmd.Parameters.AddWithValue("@standarddate", date);

                    List<BOMVO> temp = Helper.DataReaderMapToList<BOMVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_BOMDAC_ GetBOMReverse() 오류", err);
                return new List<BOMVO>();
            }
        }

        /// <summary>
        /// BOM 정전개 정보를 가져옵니다.
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public List<BOMVO> GetBOMForward(string itemid, DateTime date)
        {
            string sql = @"SP_Forward";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Item_id", itemid);
                    cmd.Parameters.AddWithValue("@standarddate", date);

                    List<BOMVO> temp = Helper.DataReaderMapToList<BOMVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_BOMDAC_GetBOMForward() 오류", err);
                return new List<BOMVO>();
            }
        }

        

        /// <summary>
        /// BOM정보를 추가합니다.
        /// </summary>
        /// <param name="insertList"></param>
        /// <returns></returns>
        public bool AddBOM(List<BOMVO> insertList)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"SP_ADDBOM";




                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@bom_parent_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bom_use_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@start_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@end_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@bom_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@plan_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@auto_deduction", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bom_comment", System.Data.SqlDbType.Text);
                    cmd.Parameters.Add("@ins_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@ins_emp", System.Data.SqlDbType.Int);
                   
                   

                    int result = 0;
                    foreach (BOMVO vo in insertList)
                    {
                        cmd.Parameters["@bom_parent_id"].Value = vo.bom_parent_id;
                        cmd.Parameters["@item_id"].Value = vo.item_id;
                        cmd.Parameters["@bom_use_qty"].Value = vo.bom_use_qty;
                        cmd.Parameters["@start_date"].Value = vo.start_date;
                        cmd.Parameters["@end_date"].Value = vo.end_date;
                        cmd.Parameters["@bom_use"].Value = vo.bom_use;
                        cmd.Parameters["@auto_deduction"].Value = vo.auto_deduction;
                        cmd.Parameters["@plan_use"].Value = vo.plan_use;
                        cmd.Parameters["@bom_comment"].Value = vo.bom_comment == "" ? (object)DBNull.Value : vo.bom_comment;
                        cmd.Parameters["@ins_emp"].Value = vo.ins_emp;
                        cmd.Parameters["@ins_date"].Value = vo.ins_date;

                        result += cmd.ExecuteNonQuery();
                    }

                    if (result == insertList.Count)
                    {
                        trans.Commit();
                        Dispose();
                        return true;
                    }
                    else
                    {
                        trans.Rollback();
                        Dispose();
                        return false;
                    }


                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                conn.Close();
                Log.WriteError("DAC_BORDAC_AddBORList() 오류", err);
                return false;
            }
        }
    }
}
