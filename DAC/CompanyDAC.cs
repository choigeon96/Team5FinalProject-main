using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VO;

namespace DAC
{
    public class CompanyDAC : CommonDAC
    {
        public List<CompanyVO> GetCompany()
        {
            try
            {
                string sql = @"select company_id, company_name, o.name as company_type, company_ceo, company_bnum, d.name as company_btype, m.emp_name as company_manager,
                                      company_email, company_phone, company_faxnum, e.name as company_use, company_comment, c.up_date, c.up_emp
                               from TBL_COMPANY c join TBL_COMMON_CODE o on c.company_type = o.code
												  join TBL_COMMON_CODE d on c.company_btype = d.code
												  join TBL_COMMON_CODE e on c.company_use = e.code
												  join TBL_Employee m on c.company_manager = m.emp_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<CompanyVO> list = Helper.DataReaderMapToList<CompanyVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("CompanyDAC_GetCompany() 오류", err);

                return new List<CompanyVO>();
            }
        }


        public bool InsertCompany(CompanyVO vo)
        {
            try
            {
                string sql = @"insert into TBL_COMPANY(company_name, company_type, company_ceo, company_bnum, company_btype, company_manager,
                                                       company_email, company_phone, company_faxnum, company_use, company_comment, ins_emp, up_date, up_emp)
                               values(@company_name, @company_type, @company_ceo, @company_bnum, @company_btype, @company_manager,
                                      @company_email, @company_phone, @company_faxnum, @company_use, @company_comment, @ins_emp, @up_date, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                    cmd.Parameters.AddWithValue("@company_type", vo.company_type);
                    cmd.Parameters.AddWithValue("@company_ceo", vo.company_ceo);
                    cmd.Parameters.AddWithValue("@company_bnum", (vo.company_bnum == null) ? DBNull.Value : (object)vo.company_bnum);
                    cmd.Parameters.AddWithValue("@company_btype", vo.company_btype);
                    cmd.Parameters.AddWithValue("@company_manager", vo.company_manager);
                    cmd.Parameters.AddWithValue("@company_email", vo.company_email);
                    cmd.Parameters.AddWithValue("@company_phone", vo.company_phone);
                    cmd.Parameters.AddWithValue("@company_faxnum", vo.company_faxnum);
                    cmd.Parameters.AddWithValue("@company_use", vo.company_use);
                    cmd.Parameters.AddWithValue("@company_comment", vo.company_comment);
                    cmd.Parameters.AddWithValue("@ins_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@up_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@up_date", vo.up_date);

                    int iRow = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRow > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("CompanyDAC_InsertCompany() 오류", err);

                return false;
            }
        }

        public bool UpdateCompany(CompanyVO vo)
        {
            try
            {
                string sql = @"update TBL_COMPANY set company_name = @company_name, company_type = @company_type, company_ceo = @company_ceo, 
                                                      company_bnum = @company_bnum, company_btype = @company_btype, company_manager = @company_manager,
                                                      company_email = @company_email, company_phone = @company_phone, company_faxnum = @company_faxnum,
                                                      company_use = @company_use, company_comment = @company_comment, up_date = @up_date, up_emp = @up_emp
                               where company_id = @company_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                    cmd.Parameters.AddWithValue("@company_type", vo.company_type);
                    cmd.Parameters.AddWithValue("@company_ceo", vo.company_ceo);
                    cmd.Parameters.AddWithValue("@company_bnum", (vo.company_bnum == null) ? DBNull.Value : (object)vo.company_bnum);
                    cmd.Parameters.AddWithValue("@company_btype", vo.company_btype);
                    cmd.Parameters.AddWithValue("@company_manager", vo.company_manager);
                    cmd.Parameters.AddWithValue("@company_email", vo.company_email);
                    cmd.Parameters.AddWithValue("@company_phone", vo.company_phone);
                    cmd.Parameters.AddWithValue("@company_faxnum", vo.company_faxnum);
                    cmd.Parameters.AddWithValue("@company_use", vo.company_use);
                    cmd.Parameters.AddWithValue("@company_comment", vo.company_comment);
                    cmd.Parameters.AddWithValue("@up_date", vo.up_date);
                    cmd.Parameters.AddWithValue("@up_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@company_id", vo.company_id);

                    int iRow = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRow > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("CompanyDAC_UpdateCompany() 오류", err);

                return false;
            }
        }

        public bool DeleteCompany(int company_id)
        {
            try
            {
                string sql = @"delete from TBL_COMPANY where company_id = @company_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@company_id", company_id);

                    int iRow = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRow > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("CompanyDAC_DeleteCompany() 오류", err);

                return false;
            }
        }

        public bool ExcelImportCompany(List<CompanyVO> temp)
        {
            try
            {
                string sql = @"insert into TBL_COMPANY(company_name, company_type, company_ceo, company_bnum, company_btype, company_manager,
                                                       company_email, company_phone, company_faxnum, company_use, company_comment, ins_emp, up_date, up_emp)
                               values(@company_name, @company_type, @company_ceo, @company_bnum, @company_btype, @company_manager,
                                      @company_email, @company_phone, @company_faxnum, @company_use, @company_comment, @ins_emp,@up_date, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int cnt = 0;
                    cmd.Parameters.Add("@company_name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@company_type", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@company_ceo", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@company_bnum", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@company_btype", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@company_manager", SqlDbType.Int);
                    cmd.Parameters.Add("@company_email", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@company_phone", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@company_faxnum", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@company_use", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@company_comment", SqlDbType.Text);
                    cmd.Parameters.Add("@ins_emp", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@up_date", SqlDbType.DateTime);
                    cmd.Parameters.Add("@up_emp", SqlDbType.NVarChar);

                    for (int i = 0; i < temp.Count; i++)
                    {
                        cmd.Parameters["@company_name"].Value = temp[i].company_name;
                        cmd.Parameters["@company_type"].Value = temp[i].company_type;
                        cmd.Parameters["@company_ceo"].Value = temp[i].company_ceo;
                        cmd.Parameters["@company_bnum"].Value = temp[i].company_bnum;
                        cmd.Parameters["@company_btype"].Value = temp[i].company_btype;
                        cmd.Parameters["@company_manager"].Value = temp[i].company_manager;
                        cmd.Parameters["@company_email"].Value = temp[i].company_email;
                        cmd.Parameters["@company_phone"].Value = temp[i].company_phone;
                        cmd.Parameters["@company_faxnum"].Value = temp[i].company_faxnum;
                        cmd.Parameters["@company_use"].Value = temp[i].company_use;
                        cmd.Parameters["@company_comment"].Value = temp[i].company_comment;
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
                Log.WriteError("CompanyDAC_ExcelImportCompany() 오류", err);

                return false;
            }
        }

    }
}
