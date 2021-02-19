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
    public class InboundDAC : CommonDAC
    {
        public List<InboundVO> GetPurchasesList(DateTime from, DateTime to)
        {
            List<InboundVO> list = new List<InboundVO>();
            string sql = @"select purchase_id,pd_id,cast(PD.ins_date as date) PurchasesDate,PD.prod_id,item_unit,company_name,PD.item_id,item_name,CD.name unit,CD2.name UseCheck,pd_qty,isnull(rqty,0) InQty,
                           pd_qty-isnull(rqty,0) RQty, cast(due_date as date) due_date,cast(in_warehouse as int)warehouse_id
                           from TBL_PURCHASE_DETAIL PD JOIN TBL_ITEM I ON PD.item_id = I.item_id
                           							   JOIN TBL_COMPANY C ON I.supply_company = C.company_id
                           							   JOIN TBL_COMMON_CODE CD ON CD.code = I.item_unit
                           							   LEFT JOIN TBL_COMMON_CODE CD2 ON CD2.code = I.import_inspection
                           							   LEFT JOIN (select sum(in_rqty)-sum(in_cqty) rqty ,prod_id,item_id
                           							   	          from TBL_INBOUND
                           							   	          group by item_id,prod_id) B ON B.prod_id = PD.prod_id and B.item_id = PD.item_id
                          where purchase_state = 'PUR01' and cast(due_date as date)>=cast(@from as date) and cast(due_date as date)<= cast(@to as date)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    list = Helper.DataReaderMapToList<InboundVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetPurchasesList() 오류", err);
                    return null;
                }
            }
        }

        public bool GetInboundList(List<InboundVO> changedList)
        {
            string sql = @"
                           update TBL_INBOUND set in_cqty = @in_cqty,
                           					      up_emp = @up_emp,
                           					      up_date = getdate()
                           where in_id = @in_id";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@up_emp", 1);
                    cmd.Parameters.AddWithValue("@in_id", SqlDbType.Int);
                    cmd.Parameters.AddWithValue("@in_cqty", SqlDbType.Int);

                    foreach (InboundVO item in changedList)
                    {
                        cmd.Parameters["@in_id"].Value = item.in_id;
                        cmd.Parameters["@in_cqty"].Value = item.CQty;
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetInboundList() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }

        public (List<InboundVO>,List<CodeVO>) GetInboundList(DateTime from, DateTime to)
        {
            List<InboundVO> list = new List<InboundVO>();
            List<CodeVO> codes = new List<CodeVO>();
            string sql = @"select purchase_id,pd_id,cast(PD.ins_date as date) PurchasesDate,PD.prod_id,item_unit,company_name,PD.item_id,item_name,CD.name unit,CD2.name UseCheck,pd_qty,isnull(in_qty,0) InQty,
                           pd_qty-isnull(rqty,0) RQty, cast(due_date as date) due_date, cast(B.ins_date as date) ins_date,in_id,in_cqty Cqty,warehouse_name in_warehouse
                           from TBL_PURCHASE_DETAIL PD JOIN TBL_ITEM I ON PD.item_id = I.item_id
                           							   JOIN TBL_COMPANY C ON I.supply_company = C.company_id
                           							   JOIN TBL_COMMON_CODE CD ON CD.code = I.item_unit
                           							   LEFT JOIN TBL_COMMON_CODE CD2 ON CD2.code = I.import_inspection
                           							   JOIN (select sum(rqty) rqty,in_qty ,I.prod_id,I.item_id,I.ins_date,in_id,I.in_cqty
                           							   	     from TBL_INBOUND I JOIN (select in_rqty rqty,ins_date,prod_id,item_id
																					  from TBL_INBOUND) I2 ON I.item_id = I2.item_id and I.prod_id = I2.prod_id and I.ins_date >= I2.ins_date
															 group by I.prod_id,I.item_id,I.ins_date,in_qty,in_id,I.in_cqty
															 ) B ON B.prod_id = PD.prod_id and B.item_id = PD.item_id
													   JOIN TBL_WAREHOUSE W ON PD.warehouse_id = W.warehouse_id
where B.ins_date<=cast(@to as date) and B.ins_date>=cast(@from as date)
order by pd_id,B.ins_date desc
";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    SqlDataReader dr = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<InboundVO>(dr);
                    dr.Close();
                    cmd.CommandText = @"SELECT  cast(company_id AS varchar) code, cast(company_name AS varchar) name, 'COMPANY' AS category
                                        FROM TBL_COMPANY C JOIN TBL_ITEM I ON I.supply_company = C.company_id
                                        				   JOIN TBL_INBOUND B ON B.item_id = I.item_id
                                        where B.ins_date <@to and B.ins_date>@from
                                        group by company_id,company_name
                                        union all 
                                        select cast(warehouse_id as varchar) code, warehouse_name, 'WAREHOUSE' as category
                                        from TBL_WAREHOUSE W JOIN TBL_INBOUND B ON W.warehouse_id = B.wh_id
                                        where B.ins_date <@to and B.ins_date>@from
                                        group by warehouse_id,warehouse_name";
                    codes = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    return (list,codes);
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetPurchasesList() 오류", err);
                    return (null,null);
                }
            }
        }

        public List<CodeVO> GetInboundCodes()
        {
            string sql = @"select * from VW_INBOUND_CODE";
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
                    Log.WriteError("DAC_InboundDAC_GetInboundCodes() 오류", err);
                    return null;
                }
            }
        }

        public bool InboundCommit(List<int> selectedRows)
        {
            string sql = @"SP_INBOUND_COMMIT";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@up_emp", 1);
                    cmd.Parameters.AddWithValue("@up_date", DateTime.Now);
                    cmd.Parameters.Add("@in_id", SqlDbType.Int);

                    foreach (int item in selectedRows)
                    {
                        cmd.Parameters["@in_id"].Value = item;
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_InboundCommit() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }

        public List<InboundVO> GetWaitDetail(int pdID)
        {
            List<InboundVO> list = new List<InboundVO>();
            string sql = @"select in_id,purchase_id,cast(PD.ins_date as date) PurchasesDate,B.prod_id,pd_id,company_name,B.item_id,item_name,CD.name unit,CD2.name UseCheck,pd_qty,sum(B.in_rqty) RQty,due_date
from TBL_INBOUND B JOIN TBL_ITEM I ON I.item_id = B.item_id
				   JOIN TBL_PURCHASE_DETAIL PD ON PD.prod_id = B.prod_id and PD.item_id = B.item_id
				   JOIN TBL_COMPANY C ON C.company_id = I.supply_company
				   JOIN TBL_COMMON_CODE CD ON CD.code = I.item_unit
				   JOIN TBL_COMMON_CODE CD2 ON CD2.code = I.import_inspection
where pd_id = @pd_id
group by in_id,PD.purchase_id,PD.ins_date,B.prod_id,PD.pd_id,C.company_name,B.item_id,I.item_name,CD.name,CD2.name,PD.pd_qty,PD.due_date
";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@pd_id", pdID);
                    list = Helper.DataReaderMapToList<InboundVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetWaitDetail() 오류", err);
                    return null;
                }
            }
        }

        public List<InboundVO> GetWaitList(DateTime from, DateTime to)
        {
            List<InboundVO> list = new List<InboundVO>();
            string sql = @"select purchase_id,pd_id,cast(PD.ins_date as date) PurchasesDate,PD.prod_id,item_unit,company_name,PD.item_id,item_name,CD.name unit,CD2.name UseCheck,pd_qty,isnull(rqty,0) InQty,
                           pd_qty-isnull(rqty,0) RQty, cast(due_date as date) due_date
                           from TBL_PURCHASE_DETAIL PD JOIN TBL_ITEM I ON PD.item_id = I.item_id
                           							   JOIN TBL_COMPANY C ON I.supply_company = C.company_id
                           							   JOIN TBL_COMMON_CODE CD ON CD.code = I.item_unit
                           							   LEFT JOIN TBL_COMMON_CODE CD2 ON CD2.code = I.import_inspection
                           							   LEFT JOIN (select sum(in_rqty) rqty ,prod_id,item_id
                           							   	          from TBL_INBOUND
																  where in_state !=0
                           							   	          group by item_id,prod_id) B ON B.prod_id = PD.prod_id and B.item_id = PD.item_id
													   JOIN TBL_INBOUND B2 ON B2.prod_id = PD.prod_id and B2.item_id = PD.item_id and B2.in_state = 0
                          where purchase_state = 'PUR01'  and cast(due_date as date) >= cast(@from as date) and cast(due_date as date) <= cast(@to as date)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    list = Helper.DataReaderMapToList<InboundVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetWaitList() 오류", err);
                    return null;
                }
            }
        }

        public List<CodeVO> GetAllCodes()
        {
            List<CodeVO> list = new List<CodeVO>();
            string sql = @"select * from VW_INBOUNDCODE";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    list = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetAllCodes() 오류", err);
                    return null;
                }
            }
        }

        public bool NewInbound(List<InboundVO> selectedRows)
        {
            string sql = @"insert into TBL_INBOUND(prod_id, in_state,in_type, item_id, in_qty,in_rqty, wh_id, ins_emp)
				                             values(@prod_id, @in_state,'IN001', @item_id, @in_qty,@in_rqty, @wh_id, @ins_emp)";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;

                    cmd.Parameters.AddWithValue("@ins_emp", 1);

                    cmd.Parameters.Add("@prod_id", SqlDbType.Int);
                    cmd.Parameters.Add("@in_state", SqlDbType.Bit);
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@in_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@in_rqty", SqlDbType.Int);
                    cmd.Parameters.Add("@wh_id", SqlDbType.Int);

                    foreach (InboundVO item in selectedRows)
                    {
                        cmd.Parameters["@prod_id"].Value = item.prod_id;
                        cmd.Parameters["@in_state"].Value = false;
                        cmd.Parameters["@item_id"].Value = item.item_id;
                        cmd.Parameters["@in_qty"].Value = item.InQty;
                        cmd.Parameters["@in_rqty"].Value = item.InQty;
                        cmd.Parameters["@wh_id"].Value = item.warehouse_id;
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_NewInbound() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}
