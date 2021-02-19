using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{

	public class Log4NetSampleCode : CommonDAC
    {
		
		public void ErrorSample()
        {
			Log4NetSampleCode log = new Log4NetSampleCode();
			try
			{
                //메인함수나 부모 클래스에서 아래 변수 선언
                //private static LoggingUtility _log = new LoggingUtility("MyProject", Level.Error, 30);
                //public static LoggingUtility Log { get { return _log; } }


                //시작 Log.
                //("프로젝트명_클래스명_메서드명 상태")
                Log.WriteInfo("DAC_Log4NetSampleCode_ErrorSample() 시작");




                //종료 Log.
                Log.WriteInfo("DAC_Log4NetSampleCode_ErrorSample() 정상종료");
			}
			catch (Exception err)
			{

				//로그 오류
				Log.WriteError("DAC_Log4NetSampleCode_ErrorSample() 오류", err);

			}
        }

    }
}
