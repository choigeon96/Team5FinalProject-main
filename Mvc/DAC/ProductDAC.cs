using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Mvc.DAC
{
    public class ProductDAC : IDisposable
    {
        SqlConnection conn;

        #region 생성
        public ProductDAC()
        {
            string strConn = WebConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            conn = new SqlConnection(strConn);
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Close();
        }

        #endregion

        public List<Product> GetProducts(int pageNo, int pageSize, string category)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "GetProductList";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@page_no", pageNo);
                cmd.Parameters.AddWithValue("@page_size", pageSize);
                cmd.Parameters.AddWithValue("@category",
                    (string.IsNullOrEmpty(category)) ? DBNull.Value : (object)category);

                conn.Open();

                List<Product> list = Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());

                conn.Close();
                return list;
            }
        }

        public int GetProductTotalCount(string category)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "select count(*) from Products1 where Category = isnull(@category, Category) ";

                cmd.Parameters.AddWithValue("@category",
                    (string.IsNullOrEmpty(category)) ? DBNull.Value : (object)category);

                //cmd.Parameters.Add("@category", System.Data.SqlDbType.NVarChar);
                //if (string.IsNullOrEmpty(category))
                //    cmd.Parameters["@category"].Value = DBNull.Value;
                //else
                //    cmd.Parameters["@category"].Value = category;

                conn.Open();
                int tot = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                return tot;
            }
        }

        public List<string> GetCategoryList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "select distinct category from Products1 order by Category ";

                List<string> list = new List<string>();

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["category"].ToString());
                }
                conn.Close();
                return list;
            }
        }

        public Product GetProductInfo(int productID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "select ProductID, Name, Price, Description, Category from Products1 where ProductID = @productID ";
                cmd.Parameters.AddWithValue("@productID", productID);

                conn.Open();
                List<Product> list = Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                conn.Close();

                if (list != null && list.Count > 0)
                    return list[0];
                else
                    return null;
            }
        }
    }
}