using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;
namespace CompanyManager
{
    static class Program
    {
        private static LoggingUtility _log = new LoggingUtility("Log_Mes", Level.Info, 30);
        public static LoggingUtility Log { get { return _log; } }

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.WriteInfo("프로그램 시작");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
