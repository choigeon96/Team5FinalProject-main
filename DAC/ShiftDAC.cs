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
    public class ShiftDAC : CommonDAC
    {


        public List<ShiftVO> GetShift()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select 
                                        shift_id,
										S.machine_id,
                                        machine_name,
                                        shift_type,
                                        shift_stime,
                                        shift_etime,
                                        shift_sdate,
                                        shift_edate,
                                        shift_use,
                                        shift_comment,
                                        Directly_Input_Person,
                                        Indirect_Input_Person,
                                        Nomal_Direct_WorkTime,
                                        Nomal_indirect_WorkTime,
                                        Overtime_Directly_WorkTime,
                                        Overtime_Indirect_WorkTime,
                                        Overtime_Directly_Input_Person,
                                        Overtime_Indirect_Input_Person,
                                        Directly_Accident_WorkTime,
                                        Indirect_Accident_WorkTime,
                                        Overtime_Directly_Accident_Time,
                                        Overtime_Indirect_Accident_Time
                        from TBL_SHIFT S inner join TBL_MACHINE M on S.machine_id=M.machine_id";
                    cmd.Connection = conn;
                    List<ShiftVO> temp = Helper.DataReaderMapToList<ShiftVO>(cmd.ExecuteReader());
                    Dispose();

                    return temp;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_ShiftDAC_GetShift() 오류", err);

                return new List<ShiftVO>();
            }


        }

        public bool AddShift(ShiftVO item)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into TBL_SHIFT (
machine_id,shift_type,shift_stime,shift_etime,shift_sdate,shift_edate,shift_use,shift_comment,ins_date,ins_emp,
Directly_Input_Person,Indirect_Input_Person,Nomal_Direct_WorkTime,Nomal_indirect_WorkTime,Overtime_Directly_WorkTime,Overtime_Indirect_WorkTime,
Overtime_Directly_Input_Person,Overtime_Indirect_Input_Person,Directly_Accident_WorkTime,Indirect_Accident_WorkTime,Overtime_Directly_Accident_Time,Overtime_Indirect_Accident_Time)

values (@machine_id,@shift_type,@shift_stime,@shift_etime,@shift_sdate,@shift_edate,@shift_use,@shift_comment,@ins_date,@ins_emp,@Directly_Input_Person,@Indirect_Input_Person,@Nomal_Direct_WorkTime,
@Nomal_indirect_WorkTime,@Overtime_Directly_WorkTime,@Overtime_Indirect_WorkTime,@Overtime_Directly_Input_Person,@Overtime_Indirect_Input_Person,@Directly_Accident_WorkTime,@Indirect_Accident_WorkTime,
@Overtime_Directly_Accident_Time,@Overtime_Indirect_Accident_Time)";
                  



                    cmd.Parameters.AddWithValue("@machine_id", item.machine_id);
                    cmd.Parameters.AddWithValue("@shift_type", item.shift_type);
                    cmd.Parameters.AddWithValue("@shift_stime", item.shift_stime);
                    cmd.Parameters.AddWithValue("@shift_etime", item.shift_etime);
                    cmd.Parameters.AddWithValue("@shift_sdate", item.shift_sdate);
                    cmd.Parameters.AddWithValue("@shift_edate", item.shift_edate);
                    cmd.Parameters.AddWithValue("@shift_use", item.shift_use);
                    cmd.Parameters.AddWithValue("@shift_comment", (item.shift_comment == "") ? DBNull.Value : (object)item.shift_comment);

                    cmd.Parameters.AddWithValue("@ins_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ins_emp", item.ins_emp);
                   

                    cmd.Parameters.AddWithValue("@Directly_Input_Person", (item.Directly_Input_Person=="")?DBNull.Value:(object)item.Directly_Input_Person);
                    cmd.Parameters.AddWithValue("@Indirect_Input_Person", (item.Indirect_Input_Person == "") ? DBNull.Value : (object)item.Indirect_Input_Person);
                    cmd.Parameters.AddWithValue("@Nomal_Direct_WorkTime", (item.Nomal_Direct_WorkTime == "") ? DBNull.Value : (object)item.Nomal_Direct_WorkTime);
                    cmd.Parameters.AddWithValue("@Nomal_indirect_WorkTime", (item.Nomal_indirect_WorkTime == "") ? DBNull.Value : (object)item.Nomal_indirect_WorkTime);
                    cmd.Parameters.AddWithValue("@Overtime_Directly_WorkTime", (item.Overtime_Directly_WorkTime == "") ? DBNull.Value : (object)item.Overtime_Directly_WorkTime);
                    cmd.Parameters.AddWithValue("@Overtime_Indirect_WorkTime", (item.Overtime_Indirect_WorkTime == "") ? DBNull.Value : (object)item.Overtime_Indirect_WorkTime);
                    cmd.Parameters.AddWithValue("@Overtime_Directly_Input_Person", (item.Overtime_Directly_Input_Person == "") ? DBNull.Value : (object)item.Overtime_Directly_Input_Person);
                    cmd.Parameters.AddWithValue("@Overtime_Indirect_Input_Person", (item.Overtime_Indirect_Input_Person == "") ? DBNull.Value : (object)item.Overtime_Indirect_Input_Person);
                    cmd.Parameters.AddWithValue("@Directly_Accident_WorkTime", (item.Directly_Accident_WorkTime == "") ? DBNull.Value : (object)item.Directly_Accident_WorkTime);
                    cmd.Parameters.AddWithValue("@Indirect_Accident_WorkTime", (item.Indirect_Accident_WorkTime == "") ? DBNull.Value : (object)item.Indirect_Accident_WorkTime);
                    cmd.Parameters.AddWithValue("@Overtime_Directly_Accident_Time", (item.Overtime_Directly_Accident_Time == "") ? DBNull.Value : (object)item.Overtime_Directly_Accident_Time);
                    cmd.Parameters.AddWithValue("@Overtime_Indirect_Accident_Time", (item.Overtime_Indirect_Accident_Time == "") ? DBNull.Value : (object)item.Overtime_Indirect_Accident_Time);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    conn.Close();


                    return iRowAffect > 0;
                }
            }
            catch (Exception err)
            {
                Dispose();
                //로그 오류
                Log.WriteError("DAC_ShiftDAC_AddShift() 오류", err);

                return false;
            }


        }

        public bool DeleteShift(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"delete from TBL_SHIFT where shift_id=@shift_id";

                    cmd.Parameters.AddWithValue("@shift_id", id);
               
                    int iRowAffect = cmd.ExecuteNonQuery();
                    conn.Close();

                    return iRowAffect > 0;
                }
            }
            catch (Exception err)
            {
                Dispose();
                //로그 오류
                Log.WriteError("DAC_ShiftDAC_DeleteShift() 오류", err);

                return false;
            }
        }

        public bool UpdateShift(ShiftVO item)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"update TBL_SHIFT set 
					                                        	machine_id=@machine_id,
					                                        	shift_type=@shift_type,
					                                        	shift_stime=@shift_stime,
					                                        	shift_etime=@shift_etime,
					                                        	shift_sdate=@shift_sdate,
					                                        	shift_edate=@shift_edate,
					                                        	shift_use=@shift_use,
					                                        	shift_comment=@shift_comment,
					                                            up_date=@up_date,
					                                        	up_emp=@up_emp,
					                                        	Directly_Input_Person=@Directly_Input_Person,
					                                        	Indirect_Input_Person=@Indirect_Input_Person,
					                                        	Nomal_Direct_WorkTime=@Nomal_Direct_WorkTime,
					                                        	Nomal_indirect_WorkTime=@Nomal_indirect_WorkTime,
					                                        	Overtime_Directly_WorkTime=@Overtime_Directly_WorkTime,
					                                        	Overtime_Indirect_WorkTime=@Overtime_Indirect_WorkTime,
					                                        	Overtime_Directly_Input_Person=@Overtime_Directly_Input_Person,
					                                        	Overtime_Indirect_Input_Person=@Overtime_Indirect_Input_Person,
					                                        	Directly_Accident_WorkTime=@Directly_Accident_WorkTime,
					                                        	Indirect_Accident_WorkTime=@Indirect_Accident_WorkTime,
					                                        	Overtime_Directly_Accident_Time=@Overtime_Directly_Accident_Time,
					                                        	Overtime_Indirect_Accident_Time=@Overtime_Indirect_Accident_Time
                                                              
                                                where shift_id=@shift_id";

                    cmd.Parameters.AddWithValue("@shift_id", item.shift_id);
                    cmd.Parameters.AddWithValue("@machine_id", item.machine_id);
                    cmd.Parameters.AddWithValue("@shift_type", item.shift_type);
                    cmd.Parameters.AddWithValue("@shift_stime", item.shift_stime);
                    cmd.Parameters.AddWithValue("@shift_etime", item.shift_etime);
                    cmd.Parameters.AddWithValue("@shift_sdate", item.shift_sdate);
                    cmd.Parameters.AddWithValue("@shift_edate", item.shift_edate);
                    cmd.Parameters.AddWithValue("@shift_use", item.shift_use);
                    cmd.Parameters.AddWithValue("@shift_comment", (item.shift_comment=="") ? DBNull.Value : (object)item.shift_comment);

                    cmd.Parameters.AddWithValue("@up_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@up_emp", item.ins_emp);

              

                    cmd.Parameters.AddWithValue("@Directly_Input_Person", (item.Directly_Input_Person == "") ? DBNull.Value : (object)item.Directly_Input_Person);
                    cmd.Parameters.AddWithValue("@Indirect_Input_Person", (item.Indirect_Input_Person == "") ? DBNull.Value : (object)item.Indirect_Input_Person);
                    cmd.Parameters.AddWithValue("@Nomal_Direct_WorkTime", (item.Nomal_Direct_WorkTime == "") ? DBNull.Value : (object)item.Nomal_Direct_WorkTime);
                    cmd.Parameters.AddWithValue("@Nomal_indirect_WorkTime", (item.Nomal_indirect_WorkTime == "") ? DBNull.Value : (object)item.Nomal_indirect_WorkTime);
                    cmd.Parameters.AddWithValue("@Overtime_Directly_WorkTime", (item.Overtime_Directly_WorkTime == "") ? DBNull.Value : (object)item.Overtime_Directly_WorkTime);
                    cmd.Parameters.AddWithValue("@Overtime_Indirect_WorkTime", (item.Overtime_Indirect_WorkTime == "") ? DBNull.Value : (object)item.Overtime_Indirect_WorkTime);
                    cmd.Parameters.AddWithValue("@Overtime_Directly_Input_Person", (item.Overtime_Directly_Input_Person == "") ? DBNull.Value : (object)item.Overtime_Directly_Input_Person);
                    cmd.Parameters.AddWithValue("@Overtime_Indirect_Input_Person", (item.Overtime_Indirect_Input_Person == "") ? DBNull.Value : (object)item.Overtime_Indirect_Input_Person);
                    cmd.Parameters.AddWithValue("@Directly_Accident_WorkTime", (item.Directly_Accident_WorkTime == "") ? DBNull.Value : (object)item.Directly_Accident_WorkTime);
                    cmd.Parameters.AddWithValue("@Indirect_Accident_WorkTime", (item.Indirect_Accident_WorkTime == "") ? DBNull.Value : (object)item.Indirect_Accident_WorkTime);
                    cmd.Parameters.AddWithValue("@Overtime_Directly_Accident_Time", (item.Overtime_Directly_Accident_Time == "") ? DBNull.Value : (object)item.Overtime_Directly_Accident_Time);
                    cmd.Parameters.AddWithValue("@Overtime_Indirect_Accident_Time", (item.Overtime_Indirect_Accident_Time == "") ? DBNull.Value : (object)item.Overtime_Indirect_Accident_Time);


                    int iRowAffect = cmd.ExecuteNonQuery();
                    conn.Close();

                    return iRowAffect > 0;
                }
            }
            catch (Exception err)
            {
                Dispose();
                //로그 오류
                Log.WriteError("DAC_ShiftDAC_UpdateShift() 오류", err);

                return false;
            }
        }

        public DataTable GetShiftInfo(string sday, string eday,string shift, string machine)
        {
           
                string sql = "SP_Shift_TEST2";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Start_DT", sday);
                da.SelectCommand.Parameters.AddWithValue("@End_DT",eday);
                da.SelectCommand.Parameters.AddWithValue("@Shift_type", shift);
                da.SelectCommand.Parameters.AddWithValue("@Machine_name", machine);


            DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            

        }

    }
}
