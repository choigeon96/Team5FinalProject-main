using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class MenuDAC : CommonDAC
    {

        /// <summary>
        /// 모든 메뉴 불러오기
        /// </summary>
        /// <returns></returns>
        public List<MenuVO> GetMenus(int emp_id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SP_GetMenu";
                    cmd.Parameters.AddWithValue("@emp_id", emp_id);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    List<MenuVO> temp = Helper.DataReaderMapToList<MenuVO>(cmd.ExecuteReader());
                    Dispose();

                    return temp;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return new List<MenuVO>();
            }


        }

        public bool MenuUpOrder(string menuName)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "SP_MenuUpOrder";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MenuName", menuName);
                    cmd.Parameters.Add("@return", System.Data.SqlDbType.Int);


                    cmd.Parameters["@return"].Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Connection = conn;

                    int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    trans.Commit();
                    Dispose();


                    return Convert.ToInt32(cmd.Parameters["@return"].Value) > 0 ? true : false;

                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return false;
            }
        }

        //메뉴접근권한정보를 등록한다.
        public bool AddMenuAccess(string menuName, List<int> deptlist)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                



                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from TBL_MENU_ACCESS where Menu_id = (select MenuID from Menu where Name = @menuName);";
                    cmd.Parameters.Add("@menuName", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters["@menuName"].Value = menuName;
                    cmd.ExecuteNonQuery();


                    cmd.CommandText = "SP_AddMenuAccess";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@dept_id",System.Data.SqlDbType.Int);
                   
                    

                    

                    int result = 0;
                    foreach (int deptid in deptlist)
                    {
                        cmd.Parameters["@dept_id"].Value = deptid;
                        result += cmd.ExecuteNonQuery();
                    }


                    trans.Commit();
                    Dispose();


                    return true;

                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_AddMenuAccess() 오류", err);

                return false;
            }
        }

        public List<int> GetMenuAccess(string menuName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Dept_id from TBL_MENU_ACCESS where Menu_id = (select MenuID from Menu where Name = @menuName)";
                    cmd.Parameters.AddWithValue("@menuName", menuName);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    List<int> temp = new List<int>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        temp.Add(Convert.ToInt32(dr[0]));
                    }
                    Dispose();



                    return temp;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenuAccess() 오류", err);

                return new List<int>();
            }
        }

        public bool MenuDownOrder(string menuName)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "SP_MenuDownOrder";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MenuName", menuName);
                    cmd.Parameters.Add("@return", System.Data.SqlDbType.Int);


                    cmd.Parameters["@return"].Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Connection = conn;

                    int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    trans.Commit();
                    Dispose();


                    return Convert.ToInt32(cmd.Parameters["@return"].Value) > 0 ? true : false;

                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return false;
            }
        }
        /// <summary>
        /// 추가한 메뉴에 폼을 링크
        /// </summary>
        /// <param name="menuName"></param>
        /// <param name="formName"></param>
        /// <returns></returns>
        public bool LinkMenuToForm(string menuName, string formName)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    
                    cmd.CommandText = "update menu set FormName = @formName where Name = @MenuName";
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@MenuName", menuName);
                    cmd.Parameters.AddWithValue("@formName", formName);
                   
                    cmd.Connection = conn;

                    int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    trans.Commit();
                    Dispose();


                    return result > 0 ? true : false;

                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return false;
            }

        }

        /// <summary>
        /// 메뉴 삭제
        /// </summary>
        /// <param name="menuName">삭제할 메뉴 이름</param>
        /// <returns></returns>
        public bool DeleteMenu(string menuName)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "SP_DeleteMenu";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MenuName",menuName);
                    cmd.Parameters.Add("@return", System.Data.SqlDbType.Int);


                    cmd.Parameters["@return"].Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Connection = conn;

                    int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    trans.Commit();
                    Dispose();


                    return Convert.ToInt32(cmd.Parameters["@return"].Value) == 0 ? true : false;

                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return false;
            }

        }

        /// <summary>
        /// 소메뉴 추가
        /// </summary>
        /// <param name="menuName">추가할 메뉴명</param>
        /// <param name="parentName">부모메뉴명</param>
        /// <returns></returns>
        public bool AddSmallMenu(string menuName, string parentName)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "SP_AddSmallMenu";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@return", System.Data.SqlDbType.Int);
                    cmd.Parameters.AddWithValue("@MenuName", menuName);
                    cmd.Parameters.AddWithValue("@ParentName", parentName);
                    cmd.Parameters["@return"].Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Connection = conn;

                    int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    trans.Commit();
                    Dispose();


                    return Convert.ToInt32(cmd.Parameters["@return"].Value) > 0 ? false : true;


                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return false;
            }
        }

        /// <summary>
        /// 대메뉴 추가
        /// </summary>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public bool AddLargeMenu(string menuName)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "SP_AddLargeMenu";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MenuName", menuName);
                    cmd.Parameters.Add("@return", System.Data.SqlDbType.Int);
                    cmd.Parameters["@return"].Direction = System.Data.ParameterDirection.ReturnValue;

                    cmd.Connection = conn;

                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    Dispose();

                    return Convert.ToInt32(cmd.Parameters["@return"].Value) > 0 ? false : true;
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return false;
            }

        }
    }
}
