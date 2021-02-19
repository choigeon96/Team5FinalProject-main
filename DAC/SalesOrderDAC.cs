using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using VO;

namespace DAC
{
    public class SalesOrderDAC : CommonDAC
    {
        public bool CommitSO(List<SalesOrderVO> list)
        {
            string sql = @"insert into TBL_SO_MASTER(plan_date, company_id, item_id, order_id, due_date, so_o_qty, so_comment, mkt, currency, so_state)
				                              values(@plan_date, @company_id, @item_id, @order_id, @due_date, @so_qty, @so_comment, @mkt, @currency, @so_state)";
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Transaction = trans;
                    cmd.Parameters.Add("@plan_date", SqlDbType.Date);
                    cmd.Parameters.Add("@company_id", SqlDbType.Int);
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@order_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@due_date", SqlDbType.Date);
                    cmd.Parameters.Add("@so_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@so_comment", SqlDbType.Text);
                    cmd.Parameters.Add("@mkt", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@currency", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@so_state", SqlDbType.NVarChar);
                    foreach (SalesOrderVO item in list)
                    {
                        cmd.Parameters["@plan_date"].Value = item.plan_date;
                        cmd.Parameters["@company_id"].Value = item.company_id;
                        cmd.Parameters["@item_id"].Value = item.item_id;
                        cmd.Parameters["@order_id"].Value = item.order_id;
                        cmd.Parameters["@due_date"].Value = item.due_date;
                        cmd.Parameters["@so_qty"].Value = item.so_o_qty;
                        cmd.Parameters["@so_comment"].Value = item.so_comment.Length < 1 ? (object)DBNull.Value : item.so_comment;
                        cmd.Parameters["@mkt"].Value = item.mkt;
                        cmd.Parameters["@currency"].Value = item.currency;
                        cmd.Parameters["@so_state"].Value = "SO001";
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
                Log.WriteError("DAC_SalesOrderDAC_CommitSO() 오류", err);
                return false;
            }
        }


        public bool RegDemandPlan(List<SalesOrderVO> demandList)
        {
            string sql = @"SP_RegDemandPlan";
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@so_id", SqlDbType.Int);
                    cmd.Parameters.Add("@plan_date", SqlDbType.Date);
                    cmd.Parameters.Add("@plan_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@plan_state", SqlDbType.Bit);
                    cmd.Parameters.Add("@ins_emp", SqlDbType.NVarChar);
                    foreach (SalesOrderVO item in demandList)
                    {
                        cmd.Parameters["@so_id"].Value = item.so_id;
                        cmd.Parameters["@plan_date"].Value = item.due_date;
                        cmd.Parameters["@plan_qty"].Value = item.so_o_qty;
                        cmd.Parameters["@plan_state"].Value = false;
                        cmd.Parameters["@ins_emp"].Value = "1";
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
                Log.WriteError("DAC_SalesOrderDAC_RegDemandPlan() 오류", err);
                return false;
            }
        }

        public bool UpdateSO(SalesOrderVO so)
        {
            SqlTransaction trans = conn.BeginTransaction();
            string sql = @"update TBL_SO_MASTER set order_id	 =@order_id		,
                            						 due_date	 =@due_date		,
                            						 so_comment	 =@so_comment	,
                            						 warehouse_id=@warehouse_id	,
                            						 so_o_qty	 =@so_o_qty		,
                            						 so_s_qty	 =@so_s_qty		,
                            						 so_c_qty	 =@so_c_qty		,
                            						 up_date	 =@up_date		,
                            						 up_emp		 =@up_emp		
                           where so_id = @so_id;

                           -- 수요계획에 납품수량 변경  @so_c_qty은 @so_o_qty  보다 클 수 없음
                            

                           -- 일단 수요계획과 영업마스터는 1대1관계라서 where절을 so_id로 설정했지만 후에 수요계획 취소시 데이터 삭제냐 아니면 deleted 컬럼을 추가하냐에 따라 수정필요!
                           update TBL_DEMAND_PLAN 
                              set plan_qty = @so_o_qty - @so_c_qty 
                            where so_id = @so_id;
";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Transaction = trans;
                try
                {
                    cmd.Parameters.AddWithValue("@so_id", so.so_id);
                    cmd.Parameters.AddWithValue("@order_id", so.order_id);
                    cmd.Parameters.AddWithValue("@due_date", so.due_date);
                    cmd.Parameters.AddWithValue("@so_comment", so.so_comment.Length < 1 ? (object)DBNull.Value : so.so_comment);
                    cmd.Parameters.AddWithValue("@warehouse_id", so.warehouse_id.Length < 1 ? (object)DBNull.Value : so.warehouse_id);
                    cmd.Parameters.AddWithValue("@so_o_qty", so.so_o_qty);
                    cmd.Parameters.AddWithValue("@so_s_qty", so.so_s_qty);
                    cmd.Parameters.AddWithValue("@so_c_qty", so.so_c_qty);
                    cmd.Parameters.AddWithValue("@up_emp", so.up_emp);
                    cmd.Parameters.AddWithValue("@up_date", so.up_date);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    Dispose();
                    return true;
                }
                catch (Exception err)
                {
                    trans.Rollback();
                    Dispose();
                    Log.WriteError("DAC_SalesOrderDAC_UpdateSO 오류", err);
                    return false;
                }
            }
        }

        public bool InsertSO(SalesOrderVO so)
        {
            string sql = @"INSERT INTO TBL_SO_MASTER(plan_date,company_id,item_id,order_id,due_date,so_comment,warehouse_id,so_o_qty,so_s_qty,so_c_qty,mkt,currency,so_state,ins_emp)
                                             VALUES(@plan_date,@company_id,@item_id,@order_id,@due_date,@so_comment,@warehouse_id,@so_o_qty,@so_s_qty,@so_c_qty,@mkt,@currency,@so_state,@ins_emp)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@plan_date", so.plan_date);
                    cmd.Parameters.AddWithValue("@company_id", so.company_id);
                    cmd.Parameters.AddWithValue("@item_id", so.item_id);
                    cmd.Parameters.AddWithValue("@order_id", so.order_id);
                    cmd.Parameters.AddWithValue("@due_date", so.due_date);
                    cmd.Parameters.AddWithValue("@so_comment", so.so_comment.Length < 1 ? (object)DBNull.Value : so.so_comment);
                    cmd.Parameters.AddWithValue("@warehouse_id", so.warehouse_id.Length < 1 ? (object)DBNull.Value : so.warehouse_id);
                    cmd.Parameters.AddWithValue("@so_o_qty", so.so_o_qty);
                    cmd.Parameters.AddWithValue("@so_s_qty", so.so_s_qty);
                    cmd.Parameters.AddWithValue("@so_c_qty", so.so_c_qty);
                    cmd.Parameters.AddWithValue("@mkt", so.mkt);
                    cmd.Parameters.AddWithValue("@currency", so.currency);
                    cmd.Parameters.AddWithValue("@so_state", "SO001");
                    cmd.Parameters.AddWithValue("@ins_emp", 1);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_SalesOrderDAC_InsertSO() 오류", err);
                    return false;
                }
            }
        }

        public List<SalesOrderVO> GetAllSO(DateTime from,DateTime to)
        {
            string sql = @"select * from VW_SOLIST where due_date between @from and @to";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from",from.AddDays(-1));
                    cmd.Parameters.AddWithValue("@to",to);
                    List<SalesOrderVO> list = Helper.DataReaderMapToList<SalesOrderVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_SalesOrderDAC_GetAllSO 오류", err);
                    return null;
                }
            }
        }

        public List<CodeVO> GetAllCodes()
        {
            string sql = @"select * from VW_SOCODE";
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
                    Log.WriteError("DAC_SalesOrderDAC_GetAllCodes 오류", err);
                    return null;
                }
            }

        }

        public List<SOVO> GetSOList()
        {
            string sql = @"select * from VW_GETSO";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    List<SOVO> list = Helper.DataReaderMapToList<SOVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_SalesOrderDAC_GetSOList 오류", err);
                    return null;
                }
            }
        }

        public bool MaGamProcess(List<SOVO> chklist)
        {
            string sql = @"update TBL_SO_MASTER set so_state = @so_state, up_date = @up_date, up_emp = @up_emp where so_id = @so_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    int cnt = 0;
                    cmd.Parameters.AddWithValue("@so_state", "SO003");
                    cmd.Parameters.Add("@so_id", SqlDbType.Int);
                    cmd.Parameters.Add("@up_date", SqlDbType.DateTime);
                    cmd.Parameters.Add("@up_emp", SqlDbType.NVarChar);
                    for (int i = 0; i < chklist.Count; i++)
                    {
                        cmd.Parameters["@so_id"].Value = chklist[i].so_id;
                        cmd.Parameters["@up_date"].Value = chklist[i].up_date;
                        cmd.Parameters["@up_emp"].Value = chklist[i].up_emp;

                        cmd.ExecuteNonQuery();
                        cnt++;
                    }
                    Dispose();
                    if (chklist.Count == cnt)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_SalesOrderDAC_MaGamProcess 오류", err);
                    return false;
                }
            }
        }

        public List<SOVO> GetSOClose()
        {
            string sql = @"select * from VW_SALESCLOSELIST";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    List<SOVO> list = Helper.DataReaderMapToList<SOVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_SalesOrderDAC_VW_SALESCLOSELIST() 오류", err);
                    return null;
                }
            }
        }
        public bool MaGamCencel(List<SOVO> chklist)
        {
            string sql = @"update TBL_SO_MASTER set so_state = @so_state, up_date = @up_date, up_emp = @up_emp where so_id = @so_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    int cnt = 0;
                    cmd.Parameters.AddWithValue("@so_state", "SO005");
                    cmd.Parameters.Add("@so_id", SqlDbType.Int);
                    cmd.Parameters.Add("@up_date", SqlDbType.DateTime);
                    cmd.Parameters.Add("@up_emp", SqlDbType.NVarChar);
                    for (int i = 0; i < chklist.Count; i++)
                    {
                        cmd.Parameters["@so_id"].Value = chklist[i].so_id;
                        cmd.Parameters["@up_date"].Value = chklist[i].up_date;
                        cmd.Parameters["@up_emp"].Value = chklist[i].up_emp;

                        cmd.ExecuteNonQuery();
                        cnt++;
                    }
                    Dispose();
                    if (chklist.Count == cnt)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_SalesOrderDAC_MaGamCencel() 오류", err);
                    return false;
                }
            }
        }

    }
}
