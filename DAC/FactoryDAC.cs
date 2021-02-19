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
    public class FactoryDAC : CommonDAC
    {
        public List<FactoryVO> GetFactory()
        {
            try
            {
                string sql = @"select * from (select factory_id, factory_grade,factory_type, factory_name, factory_parent, c.name as factory_use, 
                                                     convert(nvarchar(max),factory_comment) as factory_comment, up_date, up_emp, '공장'as codename
                                              from TBL_FACTORY f join TBL_COMMON_CODE c on f.factory_use = c.code

                                              UNION
                                              select warehouse_id, '창고'as code, c.name as factory_type, warehouse_name, f.factory_name, o.name as factory_use, 
                                                     convert(nvarchar(max),w.factory_comment) as factory_comment, w.up_date, w.up_emp, '창고'as codename
                                              from TBL_WAREHOUSE w inner join TBL_FACTORY f on w.factory_id = f.factory_id
					                                               inner join TBL_COMMON_CODE c on w.warehouse_type = c.code
                                                                   inner join TBL_COMMON_CODE o on w.factory_use = o.code) as a 		 
                               order by a.codename";
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    List<FactoryVO> list = Helper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_GetFactory 오류", err);

                return new List<FactoryVO>();
            }
        }


        public bool DeleteFactory(List<FactoryVO> chklist)
        {
            try
            {
                int cnt = 0;
                string sql = @"delete from TBL_FACTORY
                               where factory_id = @factory_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@factory_id", SqlDbType.Int);

                    for (int i = 0; i < chklist.Count; i++)
                    {
                        cmd.Parameters["@factory_id"].Value = chklist[i].factory_id;

                        cmd.ExecuteNonQuery();
                        cnt++;
                    }

                    Dispose();
                    if (cnt == chklist.Count)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_UpdateFactory 오류", err);

                return false;
            }
        }

        public bool UpdateFactory(FactoryVO vo)
        {
            try
            {
                string sql = @"update TBL_FACTORY set factory_grade = @factory_grade, factory_type = @factory_type, 
                                                      factory_name = @factory_name, factory_parent = @factory_parent, factory_use = @factory_use, 
                                                      factory_comment = @factory_comment, up_date = @up_date, up_emp = @up_emp
                               where factory_id = @factory_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@factory_grade", vo.factory_grade);
                    cmd.Parameters.AddWithValue("@factory_type", vo.factory_type);
                    cmd.Parameters.AddWithValue("@factory_name", vo.factory_name);
                    cmd.Parameters.AddWithValue("@factory_parent", vo.factory_parent);
                    cmd.Parameters.AddWithValue("@factory_use", vo.factory_use);
                    cmd.Parameters.AddWithValue("@factory_comment", vo.factory_comment);
                    cmd.Parameters.AddWithValue("@up_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@up_date", vo.up_date);
                    cmd.Parameters.AddWithValue("@factory_id", vo.factory_id);

                    int iRows = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRows > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch(Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_UpdateFactory 오류", err);

                return false;
            }
        }

        public bool AddFactory(FactoryVO vo)
        {
            try
            {
                string sql = @"insert into TBL_FACTORY (factory_grade, factory_type, factory_name, factory_parent, factory_use,
                                                        factory_comment,  ins_emp, up_date,  up_emp)
                               values(@factory_grade, @factory_type, @factory_name, @factory_parent, 
                                      @factory_use, @factory_comment, @ins_emp, @up_date, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@factory_grade", vo.factory_grade);
                    cmd.Parameters.AddWithValue("@factory_type", vo.factory_type);
                    cmd.Parameters.AddWithValue("@factory_name", vo.factory_name);
                    cmd.Parameters.AddWithValue("@factory_parent", vo.factory_parent);
                    cmd.Parameters.AddWithValue("@factory_use", vo.factory_use);
                    cmd.Parameters.AddWithValue("@factory_comment", vo.factory_comment);
                    cmd.Parameters.AddWithValue("@ins_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@up_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@up_date", vo.up_date);

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
                Log.WriteError("DAC_AddFactory() 오류", err);

                return false;
            }

        }
        public List<FactoryVO> GetFactory(string str, string str2)
        {
            try
            {
                string sql = @"select factory_grade, factory_type, factory_name, factory_parent, factory_use,
                                      factory_comment, up_date, up_emp
                               from TBL_FACTORY
                               where factory_grade = @factory_grade and factory_name like '%@factory_name%'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@factory_grade", str);
                    cmd.Parameters.AddWithValue("@factory_name", str2);
                    List<FactoryVO> list = Helper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_GetFactory(str,str) 오류", err);

                return new List<FactoryVO>();
            }

        }

        public List<WareHouseVO> GetWarehouse()
        {
            try
            {
                string sql = @"select warehouse_id, warehouse_type, warehouse_name
                               from TBL_WAREHOUSE
                               where factory_use = @factory_use";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@factory_use", "U0001");
                    List<WareHouseVO> list = Helper.DataReaderMapToList<WareHouseVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("FactoryDAC_GetWarehouse() 오류", err);

                return new List<WareHouseVO>();
            }

        }

        public bool AddWarehouse(FactoryVO vo)
        {
            try
            {
                string sql = @"insert into TBL_WAREHOUSE (warehouse_type, warehouse_name, factory_id, factory_use, 
                                                          factory_comment, ins_emp, up_emp)
                               values(@warehouse_type, @warehouse_name, @factory_id, @factory_use, 
                                      @factory_comment, @ins_emp, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@warehouse_type", vo.factory_type);
                    cmd.Parameters.AddWithValue("@warehouse_name", vo.factory_name);
                    cmd.Parameters.AddWithValue("@factory_id", vo.factory_parent);
                    cmd.Parameters.AddWithValue("@factory_use", vo.factory_use);
                    cmd.Parameters.AddWithValue("@factory_comment", vo.factory_comment);
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
                Log.WriteError("DAC_AddWarehouse() 오류", err);

                return false;
            }
        }

        public bool UpdateWarehouse(FactoryVO vo)
        {
            try
            {
                string sql = @"update TBL_WAREHOUSE set warehouse_type = @warehouse_type, warehouse_name = @warehouse_name, factory_id = @factory_id, 
                                                      factory_use = @factory_use, factory_comment = @factory_comment, up_date = @up_date, up_emp = @up_emp
                               where warehouse_id = @warehouse_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@warehouse_type", vo.factory_type);
                    cmd.Parameters.AddWithValue("@warehouse_name", vo.factory_name);
                    cmd.Parameters.AddWithValue("@factory_id", vo.factory_parent);
                    cmd.Parameters.AddWithValue("@factory_use", vo.factory_use);
                    cmd.Parameters.AddWithValue("@factory_comment", vo.factory_comment);
                    cmd.Parameters.AddWithValue("@up_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@up_date", vo.up_date);
                    cmd.Parameters.AddWithValue("@warehouse_id", vo.factory_id);

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
                Log.WriteError("DAC_UpdateFactory 오류", err);

                return false;
            }
        }

        public bool DeleteWareHouse(List<FactoryVO> chklist)
        {
            try
            {
                int cnt = 0;
                string sql = @"delete from TBL_WAREHOUSE
                               where warehouse_id = @warehouse_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@warehouse_id", SqlDbType.Int);

                    for (int i = 0; i < chklist.Count; i++)
                    {
                        cmd.Parameters["@warehouse_id"].Value = chklist[i].factory_id;

                        cmd.ExecuteNonQuery();
                        cnt++;
                    }
                    Dispose();
                    if (cnt == chklist.Count)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("FactoryDAC_DeleteWareHouse() 오류", err);

                return false;
            }
        }
        public bool ExcelImportFactory(List<FactoryVO> temp)
        {
            try
            {
                string sql = @"insert into TBL_FACTORY (factory_grade, factory_type, factory_name, factory_parent, factory_use,
                                                        factory_comment,  ins_emp, up_date,  up_emp)
                               values(@factory_grade, @factory_type, @factory_name, @factory_parent, 
                                      @factory_use, @factory_comment, @ins_emp, @up_date, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int cnt = 0;
                    cmd.Parameters.Add("@factory_grade", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@factory_type", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@factory_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@factory_parent", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@factory_use", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@factory_comment", SqlDbType.Text);
                    cmd.Parameters.Add("@ins_emp", SqlDbType.Int);
                    cmd.Parameters.Add("@up_date", SqlDbType.DateTime);
                    cmd.Parameters.Add("@up_emp", SqlDbType.Int);

                    for (int i = 0; i < temp.Count; i++)
                    {
                        cmd.Parameters["@factory_grade"].Value = temp[i].factory_grade;
                        cmd.Parameters["@factory_type"].Value = temp[i].factory_type;
                        cmd.Parameters["@factory_name"].Value = temp[i].factory_name;
                        cmd.Parameters["@factory_parent"].Value = temp[i].factory_parent;
                        cmd.Parameters["@factory_use"].Value = temp[i].factory_use;
                        cmd.Parameters["@factory_comment"].Value = temp[i].factory_comment;
                        cmd.Parameters["@ins_emp"].Value = temp[i].up_emp;
                        cmd.Parameters["@up_date"].Value = temp[i].up_date;
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
                Log.WriteError("FactoryDAC_ExcelImportFactory() 오류", err);

                return false;
            }
        }
        public bool ExcelImportWareHouse(List<FactoryVO> temp)
        {
            try
            {
                string sql = @"insert into TBL_WAREHOUSE (warehouse_type, warehouse_name, factory_id, factory_use, 
                                                          factory_comment, ins_emp, up_date, up_emp)
                               values(@warehouse_type, @warehouse_name, @factory_id, @factory_use, 
                                      @factory_comment, @ins_emp, @up_date, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int cnt = 0;
                    cmd.Parameters.Add("@warehouse_type", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@warehouse_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@factory_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@factory_use", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@factory_comment", SqlDbType.Text);
                    cmd.Parameters.Add("@ins_emp", SqlDbType.Int);
                    cmd.Parameters.Add("@up_date", SqlDbType.DateTime);
                    cmd.Parameters.Add("@up_emp", SqlDbType.Int);

                    for (int i = 0; i < temp.Count; i++)
                    {
                        cmd.Parameters["@warehouse_type"].Value = temp[i].factory_type;
                        cmd.Parameters["@warehouse_name"].Value = temp[i].factory_name;
                        cmd.Parameters["@factory_id"].Value = temp[i].factory_parent;
                        cmd.Parameters["@factory_use"].Value = temp[i].factory_use;
                        cmd.Parameters["@factory_comment"].Value = temp[i].factory_comment;
                        cmd.Parameters["@ins_emp"].Value = temp[i].up_emp;
                        cmd.Parameters["@up_date"].Value = temp[i].up_date;
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
                Log.WriteError("FactoryDAC_ExcelImportWareHouse() 오류", err);

                return false;
            }
        }

    }
}
