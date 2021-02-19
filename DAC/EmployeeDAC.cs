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
    public class EmployeeDAC : CommonDAC
    {
        public (bool, EmployeeVO) GetLogin(string id, string pwd)
        {
            try
            {
                string sql = @"SELECT emp_id, emp_password, emp_name, dept_no, hire_date, up_date, up_emp
                                        FROM TBL_Employee
                                        where emp_id = @id and emp_password = @pwd";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pwd", pwd);

                    SqlDataReader reader = cmd.ExecuteReader();
                    EmployeeVO emp = Helper.DataReaderMapToList<EmployeeVO>(reader)[0];

                    Dispose();

                    return emp == null ? (false, null) : (true, emp);

                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("FrmLogin : 로그인 실패", err);

                return (false, null);
            }


        }

        

        public List<EmployeeVO> GetAllEmployee()
        {
            try
            {
                string sql = @"SELECT emp_id, emp_password, emp_name, dept_name, hire_date, up_date, up_emp
                               FROM VW_EMPLOYEE";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<EmployeeVO> list = Helper.DataReaderMapToList<EmployeeVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;

                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC : GetAllEmployee", err);

                return new List<EmployeeVO>();
            }

        }


        public List<DeptVO> GetDept()
        {
            try
            {
                string sql = @"SELECT dept_id, dept_name
                               FROM TBL_DEPT
                               ORDER BY dept_name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<DeptVO> list = Helper.DataReaderMapToList<DeptVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;

                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("EmployeeDAC : GetDept", err);

                return new List<DeptVO>();
            }

        }

        public bool UpdateDept(List<DeptVO> list)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                int cnt = 0;

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "delete from TBL_DEPT";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "insert into TBL_DEPT values(@dept_id, @dept_name)";
                    cmd.Parameters.Add("@dept_id", SqlDbType.Int);
                    cmd.Parameters.Add("@dept_name", SqlDbType.NVarChar);
                    for (int i = 0; i < list.Count; i++)
                    {
                        cmd.Parameters["@dept_id"].Value = list[i].dept_id;
                        cmd.Parameters["@dept_name"].Value = list[i].dept_name;
                        cmd.ExecuteNonQuery();
                        cnt++;
                    }
                    trans.Commit();

                    Dispose();
                    if (cnt == list.Count)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();
                //로그 오류
                Log.WriteError("EmployeeDAC : UpdateDept", err);

                return false;
            }
        }

        public bool AddEmployee(EmployeeVO evo)
        {
            try
            {
                string sql = @"insert into TBL_Employee (emp_id, emp_password, emp_name, dept_no, hire_date,  ins_emp, up_date, up_emp)
                               values(@emp_id, @emp_password, @emp_name, @dept_no, @hire_date,  @ins_emp, @up_date,  @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_id", evo.emp_id);
                    cmd.Parameters.AddWithValue("@emp_password", evo.emp_password);
                    cmd.Parameters.AddWithValue("@emp_name", evo.emp_name);
                    cmd.Parameters.AddWithValue("@dept_no", evo.dept_no);
                    cmd.Parameters.AddWithValue("@hire_date", evo.hire_date);
                    cmd.Parameters.AddWithValue("@ins_emp", evo.up_emp);
                    cmd.Parameters.AddWithValue("@up_emp", evo.up_emp);
                    cmd.Parameters.AddWithValue("@up_date", evo.up_date);

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
                Log.WriteError("EmployeeDAC : AddEmployee", err);

                return false;
            }
        }

        public bool UpdateEmployee(EmployeeVO evo)
        {
            try
            {
                string sql = @"update TBL_Employee set emp_password = @emp_password, emp_name = @emp_name, 
                                                       dept_no = @dept_no, hire_date = @hire_date, up_emp = @up_emp, up_date = @up_date
                               where emp_id = @emp_id";
                                
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_id", evo.emp_id);
                    cmd.Parameters.AddWithValue("@emp_password", evo.emp_password);
                    cmd.Parameters.AddWithValue("@emp_name", evo.emp_name);
                    cmd.Parameters.AddWithValue("@dept_no", evo.dept_no);
                    cmd.Parameters.AddWithValue("@hire_date", evo.hire_date);
                    cmd.Parameters.AddWithValue("@up_emp", evo.up_emp);
                    cmd.Parameters.AddWithValue("@up_date", evo.up_date);

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
                Log.WriteError("EmployeeDAC : UpdateEmployee", err);

                return false;
            }
        }

        public bool DeleteEmployee(int emp_id)
        {
            try
            {
                string sql = @"Delete From TBL_Employee 
                               where emp_id = @emp_id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_id", emp_id);

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
                Log.WriteError("EmployeeDAC : DeleteEmployee", err);

                return false;
            }
        }

        public bool ExcelImportEmployee(List<EmployeeVO> temp)
        {
            try
            {
                string sql = @"insert into TBL_Employee (emp_id, emp_password, emp_name, dept_no, hire_date,  ins_emp, up_date, up_emp)
                               values(@emp_id, @emp_password, @emp_name, @dept_no, @hire_date,  @ins_emp, @up_date,  @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int cnt = 0;
                    cmd.Parameters.Add("@emp_id", SqlDbType.Int);
                    cmd.Parameters.Add("@emp_password", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@emp_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@dept_no", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@ins_emp", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@up_date", SqlDbType.DateTime);
                    cmd.Parameters.Add("@up_emp", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@hire_date", SqlDbType.NVarChar);

                    for (int i = 0; i < temp.Count; i++)
                    {
                        cmd.Parameters["@emp_id"].Value = temp[i].emp_id;
                        cmd.Parameters["@emp_password"].Value = temp[i].emp_password;
                        cmd.Parameters["@emp_name"].Value = temp[i].emp_name;
                        cmd.Parameters["@dept_no"].Value = temp[i].dept_no;
                        cmd.Parameters["@ins_emp"].Value = temp[i].up_emp;
                        cmd.Parameters["@up_date"].Value = temp[i].up_date;
                        cmd.Parameters["@up_emp"].Value = temp[i].up_emp;
                        cmd.Parameters["@hire_date"].Value = temp[i].hire_date;
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
                Log.WriteError("EmployeeDAC : ExcelImportEmployee", err);

                return false;
            }
        }

    }
}
