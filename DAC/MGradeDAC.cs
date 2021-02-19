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
    public class MGradeDAC : CommonDAC
    {
        public List<MGradeVO> GetMGrade()
        {
            try
            {
                string sql = @"SELECT machine_grade, mgrade_name, mgrade_code, c.name as mgrade_use, mgrade_comment, m.up_date, e.emp_name as up_emp, f.factory_name as mgrade_parent
                                      FROM TBL_MACHINE_GRADE m inner join TBL_COMMON_CODE c on m.mgrade_use = c.code
                                                               inner join TBL_FACTORY f on m.mgrade_parent = f.factory_id
                                                               inner join TBL_Employee e on m.up_emp = e.emp_id
                                      ORDER BY machine_grade";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<MGradeVO> list = Helper.DataReaderMapToList<MGradeVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;

                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("MGradeDAC : GetMGrade()", err);

                return new List<MGradeVO>();
            }
        }


        public bool DeleteMGrade(int machine_grade)
        {
            try
            {
                string sql = @"Delete from TBL_MACHINE_GRADE where machine_grade = @machine_grade";
                
                               
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@machine_grade", machine_grade);
                    int iRows = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRows > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("MGradeDAC : DeleteMGrade", err);

                return false;
            }
        }

        public bool UpdateMGrade(MGradeVO vo)
        {
            try
            {
                string sql = @"update TBL_MACHINE_GRADE set mgrade_name = @mgrade_name, mgrade_code = @mgrade_code, mgrade_use = @mgrade_use, 
                                                            mgrade_comment = @mgrade_comment, mgrade_parent = @mgrade_parent, up_emp = @up_emp,
                                                            up_date = @up_date
                               where machine_grade = @machine_grade";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@machine_grade", vo.machine_grade);
                    cmd.Parameters.AddWithValue("@mgrade_name", vo.mgrade_name);
                    cmd.Parameters.AddWithValue("@mgrade_code", vo.mgrade_code);
                    cmd.Parameters.AddWithValue("@mgrade_parent", vo.mgrade_parent);
                    cmd.Parameters.AddWithValue("@mgrade_use", vo.mgrade_use);
                    cmd.Parameters.AddWithValue("@mgrade_comment", vo.mgrade_comment);
                    cmd.Parameters.AddWithValue("@up_date", vo.up_date);
                    cmd.Parameters.AddWithValue("@up_emp", vo.up_emp);

                    int iRows = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRows > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("MGradeDAC : UpdateMGrade", err);

                return false;
            }
        }

        public bool InsertMGrade(MGradeVO vo)
        {
            try
            {
                string sql = @"insert into TBL_MACHINE_GRADE (mgrade_name, mgrade_code, mgrade_use, mgrade_comment, mgrade_parent,
                                                              ins_emp, up_emp)
                               values(@mgrade_name, @mgrade_code, @mgrade_use, @mgrade_comment, @mgrade_parent,
                                      @ins_emp, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mgrade_name", vo.mgrade_name);
                    cmd.Parameters.AddWithValue("@mgrade_code", vo.mgrade_code);
                    cmd.Parameters.AddWithValue("@mgrade_use", vo.mgrade_use);
                    cmd.Parameters.AddWithValue("@mgrade_parent", vo.mgrade_parent);
                    cmd.Parameters.AddWithValue("@mgrade_comment", vo.mgrade_comment);
                    cmd.Parameters.AddWithValue("@ins_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@up_emp", vo.up_emp);

                    int iRows = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRows > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("MGradeDAC : InsertMGrade", err);

                return false;
            }
        }

        public bool ExcelImportMGrade(List<MGradeVO> temp)
        {
            try
            {
                string sql = @"insert into TBL_MACHINE_GRADE (mgrade_name, mgrade_code, mgrade_use, mgrade_comment, mgrade_parent,
                                                              ins_emp, up_emp)
                               values(@mgrade_name, @mgrade_code, @mgrade_use, @mgrade_comment, @mgrade_parent,
                                      @ins_emp, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int cnt = 0;
                    cmd.Parameters.Add("@mgrade_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@mgrade_code", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@mgrade_use", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@mgrade_comment", SqlDbType.Text);
                    cmd.Parameters.Add("@mgrade_parent", SqlDbType.Int);
                    cmd.Parameters.Add("@ins_emp", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@up_emp", SqlDbType.NVarChar);

                    for (int i = 0; i < temp.Count; i++)
                    {
                        cmd.Parameters["@mgrade_name"].Value = temp[i].mgrade_name;
                        cmd.Parameters["@mgrade_code"].Value = temp[i].mgrade_code;
                        cmd.Parameters["@mgrade_use"].Value = temp[i].mgrade_use;
                        cmd.Parameters["@mgrade_comment"].Value = temp[i].mgrade_comment;
                        cmd.Parameters["@mgrade_parent"].Value = temp[i].mgrade_parent;
                        cmd.Parameters["@ins_emp"].Value = temp[i].up_emp;
                        cmd.Parameters["@up_emp"].Value = temp[i].up_emp;
                        cmd.ExecuteNonQuery();
                        cnt++;
                    }
                    Dispose();
                    if (cnt == temp.Count)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("MGradeDAC : ExcelImportMGrade()", err);

                return false;
            }
        }

    }
}
