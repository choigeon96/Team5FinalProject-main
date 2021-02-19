using EncrytLibrary;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Util;

namespace API.DAC
{
    public class CommonDAC :  IDisposable
    {
        //private static LoggingUtility _log = new LoggingUtility("Log_API", Level.Error, 30);
        //public static LoggingUtility Log { get { return _log; } }

        //ConnectionString 전역으로 생성 암호화 한번만 할 수 있게
        static string strConn;

        /// <summary>
        /// ConnectionString
        /// </summary>
        protected SqlConnection conn;

        public CommonDAC()
        {
            if (strConn == null)
            {
                AES enc = new AES();
                strConn = enc.AESDecrypt256(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            }
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Close();
        }
    }
}