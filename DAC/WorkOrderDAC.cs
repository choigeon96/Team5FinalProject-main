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
    public class WorkOrderDAC : CommonDAC
    {
        public List<WorkOrderVO> GetWorkOrder()
        {
            string sql = @"SELECT wo_id,
                                    W.item_id,
                                    B.machine_id,
                                    machine_name,
                                    prod_id,
                                    wo_qty,
                                    wo_sdate,
                                    wo_people,
                                    wo_start,
                                    wo_end,
                                    W.ins_date,
                                    W.ins_emp,
                                    W.up_date,
                                    W.up_emp,
                                    c.name as wo_state
                                    
                    FROM TBL_WORK_ORDER W inner join TBL_BOR B on B.item_id=W.item_id
						inner join TBL_MACHINE M on M.machine_id=B.machine_id
                        inner join TBL_COMMON_CODE C on W.wo_state=C.code
                        where wo_state = 'WO002'";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<WorkOrderVO> temp = Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_WorkOrderDAC_GetWorkOrder() 오류", err);
                return new List<WorkOrderVO>();
            }
        }
        public List<WorkOrderVO> GetWorkOrder2()
        {
            string sql = @"SELECT wo_id,
                                    W.item_id,
                                    B.machine_id,
                                    machine_name,
                                    prod_id,
                                    wo_qty,
                                    wo_sdate,
                                    wo_people,
                                    wo_start,
                                    wo_end,
                                    W.ins_date,
                                    W.ins_emp,
                                    W.up_date,
                                    W.up_emp,
                                    c.name as wo_state
                                    
                    FROM TBL_WORK_ORDER W inner join TBL_BOR B on B.item_id=W.item_id
						inner join TBL_MACHINE M on M.machine_id=B.machine_id
                        inner join TBL_COMMON_CODE C on W.wo_state=C.code
                        where wo_state = 'WO003'";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<WorkOrderVO> temp = Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_WorkOrderDAC_GetWorkOrder() 오류", err);
                return new List<WorkOrderVO>();
            }
        }
        public List<WorkOrderVO> GetWorkOrder3()
        {
            string sql = @"SELECT wo_id,
                                    W.item_id,
                                    B.machine_id,
                                    machine_name,
                                    prod_id,
                                    wo_qty,
                                    wo_sdate,
                                    wo_people,
                                    wo_start,
                                    wo_end,
                                    W.ins_date,
                                    W.ins_emp,
                                    W.up_date,
                                    W.up_emp,
                                    c.name as wo_state
                                    
                    FROM TBL_WORK_ORDER W inner join TBL_BOR B on B.item_id=W.item_id
						inner join TBL_MACHINE M on M.machine_id=B.machine_id
                        inner join TBL_COMMON_CODE C on W.wo_state=C.code
                        where wo_state = 'WO004'";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<WorkOrderVO> temp = Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_WorkOrderDAC_GetWorkOrder() 오류", err);
                return new List<WorkOrderVO>();
            }
        }



        public DataTable GetUseInfo(int woID)
        {
            DataTable dt = new DataTable();
            string sql = @"select B.item_id,item_name,in_warehouse,warehouse_name,wo_qty*B.bom_use_qty use_qty
                            from TBL_WORK_ORDER WO JOIN TBL_BOM B ON B.bom_parent_id = WO.item_id
                            					   JOIN TBL_ITEM I ON I.item_id = B.item_id
                            					   LEFT JOIN TBL_WAREHOUSE W ON I.in_warehouse=w.warehouse_id
                            where wo_id = @wo_id";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql,conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@wo_id", woID);
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_WorkOrderDAC_GetUseInfo() 오류", err);
                return null;
            }
        }

        public bool DeleteWorkOrder(List<int> selectedRows)
        {
            string sql = @"delete TBL_WORK_ORDER where wo_id = @wo_id";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;
                    cmd.Parameters.Add("@wo_id", SqlDbType.Int);
                    foreach (int woID in selectedRows)
                    {
                        cmd.Parameters["@wo_id"].Value = woID;
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_WorkOrderDAC_GetWorkOrder() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }

        public bool UpdateWorkOrder(int wo_id, int woQty, DateTime startDate, DateTime endDate, string comment, int loginEmp)
        {
            string sql = @"update TBL_WORK_ORDER set wo_qty = @wo_qty,
						                             wo_sdate = @wo_sdate,
						                             wo_edate = @wo_edate,
						                             wo_comment = @wo_comment,
						                             up_emp = @up_emp,
						                             up_date = @up_date
                           where wo_id = @wo_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@wo_qty", woQty);
                    cmd.Parameters.AddWithValue("@wo_sdate", startDate);
                    cmd.Parameters.AddWithValue("@wo_edate", endDate);
                    cmd.Parameters.AddWithValue("@wo_comment", string.IsNullOrEmpty(comment) ? (object)DBNull.Value : comment);
                    cmd.Parameters.AddWithValue("@up_emp", loginEmp);
                    cmd.Parameters.AddWithValue("@up_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@wo_id", wo_id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_WorkOrderDAC_UpdateWorkOrder() 오류", err);
                    return false;
                }
            }
        }

        public bool InsertWorkOrder(string itemID, int woQty, DateTime startDate, DateTime endDate, string comment, int emp_id)
        {
            string sql = @"insert into TBL_WORK_ORDER(item_id, wo_qty, wo_sdate, ins_date, ins_emp, wo_state, wo_comment, wo_edate)
                                               values(@item_id, @wo_qty, @wo_sdate, @ins_date, @ins_emp, @wo_state, @wo_comment, @wo_edate)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@wo_edate", endDate);
                    cmd.Parameters.AddWithValue("@wo_sdate", startDate);
                    cmd.Parameters.AddWithValue("@wo_state", "WO002");
                    cmd.Parameters.AddWithValue("@wo_qty", woQty);
                    cmd.Parameters.AddWithValue("@item_id", itemID);
                    cmd.Parameters.AddWithValue("@wo_comment", string.IsNullOrEmpty(comment) ? (object)DBNull.Value : comment);
                    cmd.Parameters.AddWithValue("@ins_emp", emp_id);
                    cmd.Parameters.AddWithValue("@ins_date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_WorkOrderDAC_InsertWorkOrder() 오류", err);
                    return false;
                }
            }
        }

        public List<ItemTimeVO> GetAllItems()
        {
            List<ItemTimeVO> list = new List<ItemTimeVO>();
            string sql = @"select B.item_id, item_name ,tacktime, '080000' shift_stime,'230000' shift_etime
                           from TBL_ITEM I JOIN TBL_BOR B ON B.item_id = I.item_id
                           ";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    list = Helper.DataReaderMapToList<ItemTimeVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_WorkOrderDAC_GetAllItems() 오류", err);
                    return list;
                }
            }
        }

        public bool CommitWorkOrder(List<int> selectedRows, int emp_id)
        {
            string sql = @"update TBL_WORK_ORDER set up_date = @up_date,
                           						     up_emp = @up_emp,
                           						     wo_state = 'WO002'
                           where wo_id = @wo_id";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@up_emp", emp_id);
                    cmd.Parameters.AddWithValue("@up_date", DateTime.Now);
                    cmd.Parameters.Add("@wo_id", SqlDbType.Int);
                    foreach (int woID in selectedRows)
                    {
                        cmd.Parameters["@wo_id"].Value = woID;
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_WorkOrderDAC_GetWorkOrder() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }

        public List<CodeVO> GetCodes()
        {
            List<CodeVO> list = new List<CodeVO>();
            string sql = @"select code,name,category from TBL_COMMON_CODE where category = 'WO_STATE'
                           union all
                           select machine_id code, machine_name name ,'MACHINE' category from TBL_MACHINE
                           ";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    list = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_WorkOrderDAC_GetCodes() 오류", err);
                    return list;
                }
            }
        }

        public List<NewWorkOrderVO> GetNewWorkOrderList(string dateType, DateTime from, DateTime to, bool newWorkOrder = true)
        {
            List<NewWorkOrderVO> list = new List<NewWorkOrderVO>();
            string sql = "SP_GetWorkOrderList";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@date_type", dateType);
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    cmd.Parameters.AddWithValue("@newWorkOrder", newWorkOrder);
                    list = Helper.DataReaderMapToList<NewWorkOrderVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_WorkOrderDAC_GetWorkOrderList() 오류", err);
                    return list;
                }
            }
        }

        public bool StartWorkOrder(int wo_id,string up_emp)
        {

            string sql = @"update TBL_WORK_ORDER set wo_state = 'WO003',
						                             up_emp = @up_emp,
						                             up_date = @up_date
                           where wo_id = @wo_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@wo_id", wo_id);
                    cmd.Parameters.AddWithValue("@up_emp", up_emp);
                    cmd.Parameters.AddWithValue("@up_date", DateTime.Now);
                 
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_WorkOrderDAC_StartWorkOrder() 오류", err);
                    return false;
                }
            }
        }

        public bool EndWorkOrder(int wo_id, string up_emp)
        {

            string sql = @"update TBL_WORK_ORDER set wo_state = 'WO004',
						                             up_emp = @up_emp,
						                             up_date = @up_date,
                                                     wo_edate=@wo_edate   
                           where wo_id = @wo_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@wo_id", wo_id);
                    cmd.Parameters.AddWithValue("@up_emp", up_emp);
                    cmd.Parameters.AddWithValue("@up_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@wo_edate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_WorkOrderDAC_EndWorkOrder() 오류", err);
                    return false;
                }
            }
        }
    }
}
