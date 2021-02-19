using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Mvc.DAC
{
    public class OrderDAC : IDisposable
    {
        SqlConnection conn;

        #region 생성
        public OrderDAC()
        {
            string strConn = WebConfigurationManager.ConnectionStrings["MyChart"].ConnectionString;
            conn = new SqlConnection(strConn);
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Close();
        }

        #endregion
        
        //----------------------------------------------

        public List<OrderStats> GetOrderBestProduct()
        {
            string sql = @"
    select sum(SQty) as Qty, Month(CloseDate) MM, item_name as ProductName
                           from Salescloselist  
                           where CloseDate between '2022-12-01' and '2024-02-18'
                              
                           group by Month(CloseDate), item_name";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                List<OrderStats> list = Helper.DataReaderMapToList<OrderStats>(cmd.ExecuteReader());
                conn.Close();

                return list;
            }
        }
    }
}