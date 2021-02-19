using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;
using Util;
using log4net.Core;
using EncrytLibrary;
namespace DAC
{
    public class CommonDAC : ConnectionAccess, IDisposable
    {
        private static LoggingUtility _log = new LoggingUtility("Log_DAC", Level.Error, 30);
        public static LoggingUtility Log { get { return _log; } }

        /// <summary>
        /// ConnectionString
        /// </summary>
        static string strConn;
        protected SqlConnection conn;

        public CommonDAC()
        {
            if (strConn == null)
            {
                AES enc = new AES();
                strConn = enc.AESDecrypt256(this.ConnectionString);
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
