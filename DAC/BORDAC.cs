using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class BORDAC : CommonDAC
    {
        public List<CodeVO> GetBORCode()
        {
            string sql = @"select code, category ,name from VW_BORCODE";

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
                Log.WriteError("DAC_BORDAC_GetBORCode() 오류", err);
                return new List<CodeVO>();
            }

        }

        public bool EditBOR(BORVO insertInfo)
        {
            try
            {
                string sql = @"update TBL_BOR           
                                  set item_id           =@item_id,
                                      bor_route         =@bor_route,
                                      machine_id        =@machine_id,
                                      priority          =@priority,
                                      tacktime          =@tacktime,
                                      preceding_days    =@preceding_days,
                                      completion_rate   =@completion_rate,
                                      bor_use           =@bor_use,
                                      bor_comment       =@bor_comment,
                                      ins_date          =@ins_date,
                                      ins_emp           =@ins_emp
                                where bor_id = @bor_id";
                              
                                          
                                          




                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                   

                    cmd.Parameters.Add("@bor_id", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@item_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bor_route", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@machine_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@priority", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@tacktime", System.Data.SqlDbType.SmallInt);
                    cmd.Parameters.Add("@preceding_days", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@completion_rate", System.Data.SqlDbType.Decimal);
                    cmd.Parameters.Add("@bor_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bor_comment", System.Data.SqlDbType.Text);
                    cmd.Parameters.Add("@ins_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@ins_emp", System.Data.SqlDbType.NVarChar);



                    cmd.Parameters["@bor_id"].Value = insertInfo.Bor_id; //bor아이디
                    cmd.Parameters["@item_id"].Value = insertInfo.Item_id; //품목아이디
                    cmd.Parameters["@bor_route"].Value = insertInfo.Bor_route; //공정아이디
                    cmd.Parameters["@machine_id"].Value = insertInfo.Machine_id; //설비아이디
                    cmd.Parameters["@priority"].Value = insertInfo.Priority; //우선순위
                    cmd.Parameters["@tacktime"].Value = insertInfo.Tacktime; //tacktime
                    cmd.Parameters["@preceding_days"].Value = insertInfo.preceding_days == 0 ? (object)DBNull.Value : insertInfo.preceding_days; //공정선행일
                    cmd.Parameters["@completion_rate"].Value = insertInfo.Completion_rate == 0 ? (object)DBNull.Value : insertInfo.Completion_rate;  //수율
                    cmd.Parameters["@bor_use"].Value = insertInfo.Bor_use; //사용유무
                    cmd.Parameters["@bor_comment"].Value = insertInfo.Bor_comment == "" ? (object)DBNull.Value : insertInfo.Bor_comment; //비고
                    cmd.Parameters["@ins_date"].Value = insertInfo.Ins_date; //등록일
                    cmd.Parameters["@ins_emp"].Value = insertInfo.Ins_emp; //등록자

                    int result = cmd.ExecuteNonQuery();


                    return result > 0 ? true : false;


                }
            }
            catch (Exception err)
            {
               
                conn.Close();
                Log.WriteError("DAC_BORDAC_EditBOR() 오류", err);
                return false;
            }
        }

        /// <summary>
        /// BOR정보를 불러옵니다.
        /// </summary>
        /// <returns></returns>
        public List<BORVO> GetBORList()
        {
            string sql = @"select bor_id,
                                  I.item_id item_id,
                                  I.item_name item_name,
                                  bor_route,
                                  dbo.GetCodeName(bor_route) bor_route_name,
                                  M.machine_id machine_id,
                                  M.machine_name machine_name,
                                  priority,
                                  tacktime,
                                  preceding_days,
                                  completion_rate,
                                  dbo.GetCodeName(bor_use) bor_use,
                                  bor_comment,
                                  R.ins_date,
                                  E.emp_name emp_name
                               from TBL_BOR R join TBL_ITEM I on R.item_id = I.item_id
                                              join TBL_MACHINE M on R.machine_id = M.machine_id
                                              join TBL_Employee E on R.ins_emp = E.emp_id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<BORVO> temp = Helper.DataReaderMapToList<BORVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_SubjectDAC_GetSubjectList() 오류", err);
                return new List<BORVO>();
            }
        }

        /// <summary>
        /// BOR정보를 등록합니다.
        /// </summary>
        /// <param name="insertList"></param>
        /// <returns></returns>
        public bool AddBORList(List<BORVO> insertList)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"insert into 
                                  TBL_BOR(
                                          item_id,
                                          bor_route,
                                          machine_id,
                                          priority,
                                          tacktime,
                                          preceding_days,
                                          completion_rate,
                                          bor_use,
                                          bor_comment,
                                          ins_date,
                                          ins_emp
                                          )
                                   values(
                                          @item_id,
                                          @bor_route,
                                          @machine_id,
                                          @priority,
                                          @tacktime,
                                          @preceding_days,
                                          @completion_rate,
                                          @bor_use,
                                          @bor_comment,
                                          @ins_date,
                                          @ins_emp
                                          )";




                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Transaction = trans;

                    cmd.Parameters.Add("@item_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bor_route", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@machine_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@priority", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@tacktime", System.Data.SqlDbType.SmallInt);
                    cmd.Parameters.Add("@preceding_days", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@completion_rate", System.Data.SqlDbType.Decimal);
                    cmd.Parameters.Add("@bor_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bor_comment", System.Data.SqlDbType.Text);
                    cmd.Parameters.Add("@ins_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@ins_emp", System.Data.SqlDbType.NVarChar);

                    int result = 0;
                    foreach (BORVO vo in insertList)
                    {
                        cmd.Parameters["@item_id"].Value = vo.Item_id; //품목아이디
                        cmd.Parameters["@bor_route"].Value = vo.Bor_route; //공정아이디
                        cmd.Parameters["@machine_id"].Value = vo.Machine_id; //설비아이디
                        cmd.Parameters["@priority"].Value = vo.Priority; //우선순위
                        cmd.Parameters["@tacktime"].Value = vo.Tacktime; //tacktime
                        cmd.Parameters["@preceding_days"].Value = vo.preceding_days == 0 ? (object)DBNull.Value : (vo.preceding_days); //공정선행일
                        cmd.Parameters["@completion_rate"].Value = vo.Completion_rate == 0 ? (object)DBNull.Value : vo.Completion_rate;  //수율
                        cmd.Parameters["@bor_use"].Value = vo.Bor_use; //사용유무
                        cmd.Parameters["@bor_comment"].Value = vo.Bor_comment == "" ? (object)DBNull.Value : vo.Bor_comment; //비고
                        cmd.Parameters["@ins_date"].Value = vo.Ins_date; //등록일
                        cmd.Parameters["@ins_emp"].Value = vo.Ins_emp.ToString(); //등록자
                        
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
