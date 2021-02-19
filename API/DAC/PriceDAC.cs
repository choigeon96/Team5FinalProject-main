using API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VO;

namespace API.DAC
{
    public class PriceDAC : CommonDAC
    {
        public List<PriceVO> GetItemPrice(string prictType)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SP_GetPrice";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@price_type", prictType);
                    List<PriceVO> list = Helper.DataReaderMapToList<PriceVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();
                    return list;
                }
                catch (Exception err)
                {
                    //Log.WriteError("단가 목록을 불러오는중 오류 발생" + err.Message);
                    return null;
                }
            }
        }

        public List<CompanyCodeVO> GetCompanyList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select company_id,company_name
                                        from TBL_COMPANY; ";
                    List<CompanyCodeVO> list = Helper.DataReaderMapToList<CompanyCodeVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();
                    return list;
                }
                catch (Exception err)
                {
                    //Log.WriteError("업체 목록을 불러오는중 오류 발생" + err.Message);
                    return null;
                }
            }
        }

        public bool InsupPrice(PriceVO price)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_InsUpPrice ";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@item_id ", price.item_id);
                    cmd.Parameters.AddWithValue("@comment", price.price_comment);
                    cmd.Parameters.AddWithValue("@start_date", price.price_sdate);
                    cmd.Parameters.AddWithValue("@price_type", price.price_type);
                    cmd.Parameters.AddWithValue("@price", price.now);
                    cmd.Parameters.AddWithValue("@currency", price.price_currency);

                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return true;
                }
                catch (Exception err)
                {
                   // Log.WriteError("신규 단가 정보를 저장하는중 오류 발생" + err.Message);
                    return false;
                }
            }
        }

        public bool ImportExcel(List<PriceVO> priceList)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_InsUpPrice ";
                    cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@item_id", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@comment", System.Data.SqlDbType.Text);
                    cmd.Parameters.Add("@start_date", System.Data.SqlDbType.Date);
                    cmd.Parameters.Add("@price_type", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@price", System.Data.SqlDbType.Decimal);
                    cmd.Parameters.Add("@currency", System.Data.SqlDbType.NVarChar);
                    foreach (PriceVO price in priceList)
                    {
                        cmd.Parameters["@item_id"].Value = price.item_id;
                        cmd.Parameters["@comment"].Value = price.price_comment;
                        cmd.Parameters["@start_date"].Value = price.price_sdate;
                        cmd.Parameters["@price_type"].Value = price.price_type;
                        cmd.Parameters["@price"].Value = price.now;
                        cmd.Parameters["@currency"].Value = price.price_currency;
                        cmd.ExecuteNonQuery();
                    }


                    trans.Commit();
                    cmd.Connection.Close();
                    return true;
                }
                catch (Exception err)
                {
                    //Log.WriteError("단가 정보를 저장하는중 오류 발생" + err.Message);
                    trans.Rollback();
                    cmd.Connection.Close();
                    return false;
                }
            }
        }

        public List<ItemCodeVO> GetItemList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select item_id,item_name,supply_company
                                        from TBL_ITEM; ";
                    List<ItemCodeVO> list = Helper.DataReaderMapToList<ItemCodeVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();
                    return list;
                }
                catch (Exception err)
                {
                    //Log.WriteError("상품 목록을 불러오는중 오류 발생" + err.Message);
                    return null;
                }
            }
        }
    }
}