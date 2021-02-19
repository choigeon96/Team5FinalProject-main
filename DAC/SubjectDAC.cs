using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class SubjectDAC : CommonDAC
    {
        /// <summary>
        /// 품목관리에서 사용하는 공통코드를 불러옵니다.
        /// </summary>
        /// VW_SUBJECTCBO
        /// <returns></returns>
        public List<CodeVO> GetSubjectCode()
        {
            string sql = @"select code, category ,name from VW_Subjectcbo";

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
                Log.WriteError("DAC_SubjectDAC_GetSubjectCod() 오류", err);
                return new List<CodeVO>();
            }


        }

        public bool EditSubject(SubjectVO vo)
        {
            try
            {
                string sql = @"update TBL_ITEM              
                                  set item_id              =@item_id,
                                      item_type            =@item_type,
                                      item_name            =@item_name,
                                      item_unit            =@item_unit,
                                      item_unit_qty        =@item_unit_qty,
                                      import_inspection    =@import_inspection,
                                      process_inspection   =@process_inspection,
                                      shipment_inspection  =@shipment_inspection,
                                      free_of_charge       =@free_of_charge,
                                      order_company        =@order_company,
                                      supply_company       =@supply_company,
                                      item_leadtime        =@item_leadtime,
                                      item_lorder_qty      =@item_lorder_qty,
                                      item_delivery_qty    =@item_delivery_qty,
                                      item_safety_qty      =@item_safety_qty,
                                      item_grade           =@item_grade,
                                      item_manager         =@item_manager,
                                      item_use             =@item_use,
                                      item_comment         =@item_comment,
                                      up_date              =@up_date,
                                      up_emp               =@up_emp,
                                      in_warehouse         =@in_warehouse,
                                      out_warehouse        =@out_warehouse,
                                      extinction           =@extinction
                                where item_id = @item_id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.Add("@item_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_type", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_name", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_unit", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_unit_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@import_inspection", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@process_inspection", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@shipment_inspection", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@free_of_charge", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@order_company", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@supply_company", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_leadtime", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@item_lorder_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@item_delivery_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@item_safety_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@item_grade", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_manager", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_comment", System.Data.SqlDbType.Text);
                    cmd.Parameters.Add("@up_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@up_emp", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@in_warehouse", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@out_warehouse", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@extinction", System.Data.SqlDbType.NVarChar);



                    cmd.Parameters["@item_id"].Value = vo.Item_id; //품목
                    cmd.Parameters["@item_type"].Value = vo.Item_type; //품목타입
                    cmd.Parameters["@item_name"].Value = vo.Item_name; //품명
                    cmd.Parameters["@item_unit"].Value = vo.Item_unit; //단위
                    cmd.Parameters["@item_unit_qty"].Value = vo.Item_unit_qty == 0 ? (object)DBNull.Value : vo.Item_unit_qty; //단위수량
                    cmd.Parameters["@import_inspection"].Value = vo.Import_inspection;
                    cmd.Parameters["@process_inspection"].Value = vo.Process_inspection;
                    cmd.Parameters["@shipment_inspection"].Value = vo.Shipment_inspection;
                    cmd.Parameters["@free_of_charge"].Value = vo.Free_of_charge == "" ? (object)DBNull.Value : vo.Free_of_charge;
                    cmd.Parameters["@order_company"].Value = vo.Order_company == "" ? (object)DBNull.Value : vo.Order_company;
                    cmd.Parameters["@supply_company"].Value = vo.Supply_company == "" ? (object)DBNull.Value : vo.Supply_company;
                    cmd.Parameters["@item_leadtime"].Value = vo.Item_leadtime == 0 ? (object)DBNull.Value : vo.Item_leadtime;
                    cmd.Parameters["@item_lorder_qty"].Value = vo.Item_lorder_qty == 0 ? (object)DBNull.Value : vo.Item_lorder_qty;
                    cmd.Parameters["@item_delivery_qty"].Value = vo.Item_delivery_qty == 0 ? (object)DBNull.Value : vo.Item_delivery_qty;
                    cmd.Parameters["@item_safety_qty"].Value = vo.Item_safety_qty == 0 ? (object)DBNull.Value : vo.Item_safety_qty;
                    cmd.Parameters["@item_grade"].Value = vo.Item_grade == "" ? (object)DBNull.Value : vo.Item_grade;
                    cmd.Parameters["@item_manager"].Value = vo.Item_manager;
                    cmd.Parameters["@item_use"].Value = vo.Item_use;
                    cmd.Parameters["@item_comment"].Value = vo.Item_comment == "" ? (object)DBNull.Value : vo.Item_comment;
                    cmd.Parameters["@up_date"].Value = vo.Up_date;
                    cmd.Parameters["@up_emp"].Value = vo.Up_emp;
                    cmd.Parameters["@in_warehouse"].Value = vo.In_warehouse == "" ? (object)DBNull.Value : vo.In_warehouse;
                    cmd.Parameters["@out_warehouse"].Value = vo.Out_warehouse == "" ? (object)DBNull.Value : vo.Out_warehouse;
                    cmd.Parameters["@extinction"].Value = vo.Extinction;

                    int result = cmd.ExecuteNonQuery();

                    return result > 0 ? true : false;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_SubjectDAC_EditSubject() 오류", err);
                return false;
            }
        }

        /// <summary>
        /// 품목정보를 등록합니다.
        /// </summary>
        /// <param name="insertList"></param>
        /// <returns></returns>
        public bool AddSubject(List<SubjectVO> insertList)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"insert into 
                                  TBL_ITEM(
                                           item_id,
                                           item_type,
                                           item_name,
                                           item_unit,
                                           item_unit_qty,
                                           import_inspection,
                                           process_inspection,
                                           shipment_inspection,
                                           free_of_charge,
                                           order_company,
                                           supply_company,
                                           item_leadtime,
                                           item_lorder_qty,
                                           item_delivery_qty,
                                           item_safety_qty,
                                           item_grade,
                                           item_manager,
                                           item_use,
                                           item_comment,
                                           up_date,
                                           up_emp,
                                           in_warehouse,
                                           out_warehouse,
                                           extinction
                                          )
                                   values (
                                           @item_id,
                                           @item_type,
                                           @item_name,
                                           @item_unit,
                                           @item_unit_qty,
                                           @import_inspection,
                                           @process_inspection,
                                           @shipment_inspection,
                                           @free_of_charge,
                                           @order_company,
                                           @supply_company,
                                           @item_leadtime,
                                           @item_lorder_qty,
                                           @item_delivery_qty,
                                           @item_safety_qty,
                                           @item_grade,
                                           @item_manager,
                                           @item_use,
                                           @item_comment,
                                           @up_date,
                                           @up_emp,
                                           @in_warehouse,
                                           @out_warehouse,
                                           @extinction
                                          )";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Transaction = trans;

                    cmd.Parameters.Add("@item_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_type", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_name", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_unit", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_unit_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@import_inspection", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@process_inspection", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@shipment_inspection", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@free_of_charge", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@order_company", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@supply_company", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_leadtime", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@item_lorder_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@item_delivery_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@item_safety_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@item_grade", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_manager", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_comment", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@up_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@up_emp", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@in_warehouse", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@out_warehouse", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@extinction", System.Data.SqlDbType.NVarChar);

                    int result = 0;
                    foreach (SubjectVO vo in insertList)
                    {
                        cmd.Parameters["@item_id"].Value = vo.Item_id; //품목
                        cmd.Parameters["@item_type"].Value = vo.Item_type; //품목타입
                        cmd.Parameters["@item_name"].Value = vo.Item_name; //품명
                        cmd.Parameters["@item_unit"].Value = vo.Item_unit; //단위
                        cmd.Parameters["@item_unit_qty"].Value = vo.Item_unit_qty == 0 ? (object)DBNull.Value : vo.Item_unit_qty; //단위수량
                        cmd.Parameters["@import_inspection"].Value = vo.Import_inspection;
                        cmd.Parameters["@process_inspection"].Value = vo.Process_inspection;
                        cmd.Parameters["@shipment_inspection"].Value = vo.Shipment_inspection;
                        cmd.Parameters["@free_of_charge"].Value = vo.Free_of_charge == "" ? (object)DBNull.Value : vo.Free_of_charge;
                        cmd.Parameters["@order_company"].Value = vo.Order_company == "" ? (object)DBNull.Value : vo.Order_company;
                        cmd.Parameters["@supply_company"].Value = vo.Supply_company == "" ? (object)DBNull.Value : vo.Supply_company;
                        cmd.Parameters["@item_leadtime"].Value = vo.Item_leadtime == 0 ? (object)DBNull.Value : vo.Item_leadtime;
                        cmd.Parameters["@item_lorder_qty"].Value = vo.Item_lorder_qty == 0 ? (object)DBNull.Value : vo.Item_lorder_qty;
                        cmd.Parameters["@item_delivery_qty"].Value = vo.Item_delivery_qty == 0 ? (object)DBNull.Value : vo.Item_delivery_qty;
                        cmd.Parameters["@item_safety_qty"].Value = vo.Item_safety_qty == 0 ? (object)DBNull.Value : vo.Item_safety_qty;
                        cmd.Parameters["@item_grade"].Value = vo.Item_grade == "" ? (object)DBNull.Value : vo.Item_grade;
                        cmd.Parameters["@item_manager"].Value = vo.Item_manager;
                        cmd.Parameters["@item_use"].Value = vo.Item_use;
                        cmd.Parameters["@item_comment"].Value = vo.Item_comment == "" ? (object)DBNull.Value : vo.Item_comment;
                        cmd.Parameters["@up_date"].Value = vo.Up_date;
                        cmd.Parameters["@up_emp"].Value = vo.Up_emp;
                        cmd.Parameters["@in_warehouse"].Value = vo.In_warehouse == "" ? (object)DBNull.Value : vo.In_warehouse;
                        cmd.Parameters["@out_warehouse"].Value = vo.Out_warehouse == "" ? (object)DBNull.Value : vo.Out_warehouse;
                        cmd.Parameters["@extinction"].Value = vo.Extinction;

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
                Log.WriteError("DAC_SubjectDAC_AddSubject() 오류", err);
                return false;
            }
        }

        /// <summary>
        /// 품목 데이터 리스트를 불러옵니다.
        /// </summary>
        /// <returns></returns>
        public List<SubjectVO> GetSubjectList()
        {
            string sql = @"select item_id,
                                  dbo.GetCodeName(item_type) item_type,
                                  item_name,
                                  dbo.GetCodeName(item_unit) item_unit,
                                  item_unit_qty,
                                  dbo.GetCodeName(import_inspection) import_inspection,
                                  dbo.GetCodeName(process_inspection) process_inspection,
                                  dbo.GetCodeName(shipment_inspection) shipment_inspection,
                                  dbo.GetCodeName(free_of_charge) free_of_charge,
                                  Ca.company_name order_company,
                                  Cb.company_name supply_company,
                                  item_leadtime,
                                  item_lorder_qty,
                                  item_delivery_qty,
                                  item_safety_qty,
                                  dbo.GetCodeName(item_grade) item_grade,
                                  Ea.emp_name item_manager,
                                  dbo.GetCodeName(item_use) item_use,
                                  item_comment,
                                  I.up_date,
                                  Eb.emp_name up_emp,
                                  Wa.warehouse_name in_warehouse,
                                  Wb.warehouse_name out_warehouse,
                                  dbo.GetCodeName(extinction) extinction
                             from TBL_ITEM I left outer join TBL_COMPANY Ca on I.order_company = Ca.company_id
                                             left outer join TBL_COMPANY Cb on I.supply_company = Cb.company_id
                                             left outer join TBL_Employee Ea on I.item_manager = Ea.emp_id
                                             join TBL_Employee Eb on I.up_emp = Eb.emp_id
                                             left outer join TBL_WAREHOUSE Wa on I.in_warehouse = Wa.warehouse_id
                                             left outer join TBL_WAREHOUSE Wb on I.in_warehouse = Wb.warehouse_id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<SubjectVO> temp = Helper.DataReaderMapToList<SubjectVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_SubjectDAC_GetSubjectList() 오류", err);
                return new List<SubjectVO>();
            }
        }
    }
}
