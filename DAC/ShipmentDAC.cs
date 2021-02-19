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
    public class ShipmentDAC : CommonDAC
    {
        public List<ShipmentVO> GetTargetList(DateTime from, DateTime to)
        {
            string sql = @"select SO.so_id,SO.order_id,due_date, D.plan_id,cast(I.out_warehouse as int) out_warehouse ,SO.company_id, company_name,cast(isnull(SO.warehouse_id,-1) as int) DestinationID,isnull(W.warehouse_name,company_name) DestinationName,SO.item_id,I.
                            	   item_name,(SO.so_o_qty-SO.so_c_qty) - (isnull(SQty,0)-isnull(CQty,0)) Qty,(isnull(SQty,0)-isnull(CQty,0)) SQty,RQty
                            from TBL_SO_MASTER SO JOIN TBL_DEMAND_PLAN D ON SO.so_id = D.so_id
                            					  JOIN TBL_COMPANY C ON C.company_id = SO.company_id
                            					  LEFT JOIN TBL_WAREHOUSE W ON SO.warehouse_id = W.warehouse_id
                            					  JOIN TBL_ITEM I ON I.item_id = SO.item_id
                            					  LEFT JOIN (select plan_id,isnull(sum(ship_qty),0) SQty ,isnull(sum(ship_cqty),0) CQty 
                            								 from TBL_SHIPMENT
                            								 group by plan_id) S ON S.plan_id= D.plan_id
												  JOIN TBL_WAREHOUSE W2 ON W2.warehouse_id = I.out_warehouse
												  LEFT JOIN (select item_id,sum(in_rqty)RQty,wh_id from TBL_INBOUND group by item_id,wh_id) Q ON Q.item_id = SO.item_id and Q.wh_id = W2.warehouse_id
                            where D.plan_state= 1 and (SO.so_o_qty-SO.so_c_qty) - (isnull(SQty,0)-isnull(CQty,0))>0 and due_date>=@from and due_date<=@to";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);

                    List<ShipmentVO> list = Helper.DataReaderMapToList<ShipmentVO>(cmd.ExecuteReader());

                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_ShipmentDAC_GetTargetList() 오류", err);
                    return new List<ShipmentVO>();
                }
            }
        }

        public List<ShipmentVO> GetShipmentList(object from, object to)
        {
            string sql = @"select SO.order_id, SO.so_id,company_name,isnull(W.warehouse_name,company_name) DestinationName,SO.item_id,item_name,SO.due_date,cast(ship_date as date) ship_date,
                            	   SO.so_o_qty Qty,S.ship_qty SQty,ship_cqty CQty
                            from TBL_SO_MASTER SO JOIN TBL_DEMAND_PLAN D ON D.so_id = SO.so_id
                            					  JOIN TBL_COMPANY C ON C.company_id = SO.company_id
                            					  JOIN TBL_ITEM I ON I.item_id = SO.item_id
                            					  LEFT JOIN TBL_WAREHOUSE W ON SO.warehouse_id = W.warehouse_id
                            					  JOIN TBL_SHIPMENT S ON S.plan_id = D.plan_id
                            where ship_date>=@from and ship_date<=@to";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);

                    List<ShipmentVO> list = Helper.DataReaderMapToList<ShipmentVO>(cmd.ExecuteReader());

                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_ShipmentDAC_GetShipmentList() 오류", err);
                    return new List<ShipmentVO>();
                }
            }
        }

        public bool RegShipment(List<ShipmentVO> selectedRows,int empID)
        {
            string sql = @"SP_Shipment";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql,conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;
                try
                {
                    cmd.Parameters.AddWithValue("@ship_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@empID", empID);

                    cmd.Parameters.Add("@plan_id", SqlDbType.Int);
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@ship_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@from", SqlDbType.Int);
                    cmd.Parameters.Add("@to", SqlDbType.Int);

                    foreach (ShipmentVO vO in selectedRows)
                    {
                        cmd.Parameters["@plan_id"].Value = vO.plan_id;
                        cmd.Parameters["@item_id"].Value = vO.item_id;
                        cmd.Parameters["@ship_qty"].Value = vO.Qty;
                        cmd.Parameters["@from"].Value = vO.out_warehouse;
                        cmd.Parameters["@to"].Value = vO.DestinationID;
                        
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
                    Log.WriteError("DAC_ShipmentDAC_RegShipment() 오류", err);
                    return false;
                }
            }
        }

        public List<CodeVO> GetShipmentCodes()
        {
            string sql = @"select '' code, '전체' name, 'ALL' category 
                           union all 
                           select company_id,company_name,'COMPANY' from TBL_COMPANY
                           union all
                           select warehouse_id,warehouse_name,'TO' from TBL_WAREHOUSE where warehouse_type='FAC700'
                           union all
                           select warehouse_id,warehouse_name,'FROM' from TBL_WAREHOUSE where warehouse_type='FAC400'";
            using (SqlCommand cmd = new SqlCommand(sql,conn))
            {
                try
                {
                    List<CodeVO> codes = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    conn.Close();
                    return codes;
                }
                catch (Exception err)
                {
                    conn.Close();
                    Log.WriteError("DAC_ShipmentDAC_GetShipmentCodes() 오류", err);
                    return new List<CodeVO>();
                }
            }
        }
    }
}
