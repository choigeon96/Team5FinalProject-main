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
    public class PerformanceDAC : CommonDAC
    {
        public List<PerformanceVO> GetPerformanceList(DateTime from, DateTime to)
        {

            string sql = @"select P.performance_id,WO.wo_id,cast(WO.wo_sdate as date) wo_sdate,M.machine_id,M.machine_name,WO.item_id,I.item_name,CD.name wo_state,W.warehouse_name good_wh, W2.warehouse_name bad_wh,
       WO.wo_qty,isnull(performance_qty,0) performance_qty,E.emp_name ins_emp,
	   CASE WHEN wo_qty-isnull(sum_qty,0) > 0
			THEN wo_qty-isnull(sum_qty,0)
       ELSE 0
       END Rqty,
	   CASE WHEN P.state =0
			THEN '대기'
       ELSE '확정'
       END p_state

FROM TBL_WORK_ORDER WO JOIN TBL_BOR BOR ON WO.item_id = BOR.item_id
					   JOIN TBL_MACHINE M ON M.machine_id = BOR.machine_id
					   JOIN TBL_ITEM I ON I.item_id = WO.item_id
					   JOIN TBL_COMMON_CODE CD ON CD.code = WO.wo_state
					   JOIN TBL_WAREHOUSE W ON M.ok_warehouse_id = W.warehouse_id
					   JOIN TBL_WAREHOUSE W2 ON M.ng_warehouse_id = W2.warehouse_id
					   JOIN TBL_PERFORMANCE P ON P.wo_id = WO.wo_id
					   LEFT JOIN (select wo_id,CH.ch_id,good_qty,sum(good_qty) sum_qty
								  from TBL_CHECK_HISTORY CH JOIN TBL_PERFORMANCE P ON P.ch_id = CH.ch_id
								  group by wo_id,CH.ch_id,good_qty) CH ON CH.ch_id = P.ch_id
					   left JOIN TBL_Employee E ON P.ins_emp = E.emp_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    List<PerformanceVO> list = Helper.DataReaderMapToList<PerformanceVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_PerformanceDAC_GetPerformanceList() 오류", err);
                    return new List<PerformanceVO>();
                }
            }
        }

        public bool PerformanceCommit(List<int> selectedIDs, int empID)
        {
            string sql = @"SP_PerformanceCommit";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emp_id", empID);
                    cmd.Parameters.Add("@performance_id", SqlDbType.Int);
                    foreach (int item in selectedIDs)
                    {
                        cmd.Parameters["@performance_id"].Value = item;
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_PerformanceDAC_PerformanceCommit() 오류", err);
                    trans.Rollback();
                    conn.Close();
                    return false;
                }
            }
        }

        public List<CodeVO> GetAllCodes()
        {
            string sql = @"select '' as code, '전체' as name, 'ALL' as category 
                           union all 
                           select code,name,category from TBL_COMMON_CODE where category = 'WO_STATE'
                           union all
                           select cast(emp_id as varchar) as code, emp_name as name, 'EMPLOYEE' as category from TBL_Employee
                           union all
                           select machine_id as code, machine_name as name, 'MACHINE' as category from TBL_MACHINE";
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
                    return new List<CodeVO>();
                }
            }
        }

        public bool PerformanceCommit2(PerformanceVO vo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"insert into TBL_PERFORMANCE (wo_id,item_id,ch_id,performance_qty,ins_date,ins_emp,bad_qty)
                                                             values (@wo_id,@item_id,@ch_id,@performance_qty,@ins_date,@ins_emp,@bad_qty)";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@wo_id", vo.wo_id);
                    cmd.Parameters.AddWithValue("@item_id", vo.item_id);
                    cmd.Parameters.AddWithValue("@ch_id", vo.ch_id);
                    cmd.Parameters.AddWithValue("@performance_qty", vo.performance_qty);
                    cmd.Parameters.AddWithValue("@ins_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ins_emp", vo.ins_emp);
                    cmd.Parameters.AddWithValue("@bad_qty", vo.bad_qty);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    Dispose();

                    return id>0;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_PerformanceDAC_PerformanceCommit2() 오류", err);

                return false;
            }
        }
        public bool PerformanceCh_idUpdate(int per_id, int ch_id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @" update TBL_PERFORMANCE set  ch_id=@ch_id
                                                            where performance_id=@performance_id;";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@ch_id", ch_id);
                    cmd.Parameters.AddWithValue("@performance_id", per_id);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    Dispose();

                    return iRowAffect > 0;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_PerformanceDAC_PerformanceCh_idUpdate() 오류", err);

                return false;
            }
        }
        
        public List<PerformanceVO> GetPerformance()
        {

            string sql = @"    select performance_id,W.wo_qty AS wo_id,P.item_id,performance_qty,P.ins_date as wo_sdate,E.emp_name,P.bad_qty
 from TBL_PERFORMANCE  P inner join TBL_WORK_ORDER W on P.wo_id=W.wo_id
						inner join TBL_Employee E on P.ins_emp=E.emp_id
 where ch_id=0;";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    List<PerformanceVO> list = Helper.DataReaderMapToList<PerformanceVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_PerformanceDAC_GetPerformance() 오류", err);
                    return new List<PerformanceVO>();
                }
            }
        }



        public bool BadQTY(int ch_id,string bad_type,int bad_qty,string ins_emp)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"insert into TBL_BAD (ch_id,bad_type,bad_qty,ins_date,ins_emp)
                                                    values  (@ch_id,@bad_type,@bad_qty,@ins_date,@ins_emp)";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@ch_id", ch_id);
                    cmd.Parameters.AddWithValue("@bad_type", bad_type);
                    cmd.Parameters.AddWithValue("@bad_qty", bad_qty);
                    cmd.Parameters.AddWithValue("@ins_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ins_emp", ins_emp);
                    

                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    Dispose();

                    return id > 0;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_PerformanceDAC_PerformanceCommit2() 오류", err);

                return false;
            }
        }
    }
}
