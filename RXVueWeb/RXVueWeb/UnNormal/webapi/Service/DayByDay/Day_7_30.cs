using System;
using webapi.Service.CMP_SPTS_Email;
using webapi.Service.DynCTSummary_Email;
using webapi.Service.Email.OEE_Email;
using webapi.Service.Email.WaferStart_Email;

namespace webapi.Service.DayByDay
{
    public class Day_7_30
    {
        public static  void TimeFor()
        {
            Console.WriteLine("进入定时程序");
            //System.Timers.Timer t = new System.Timers.Timer(86400000);
            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(Day_By_Day);
            t.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }
        private static  void Day_By_Day(object source, System.Timers.ElapsedEventArgs e) {

            Console.WriteLine("开始发送");
            DayCTEmail ct = new DayCTEmail();
            ct.SendDayCTEmail();
            CmpEmail ct2 = new CmpEmail();
            ct2.SendCmpEmail();
            WaferStart_Email waferStart = new WaferStart_Email();
            waferStart.SendWaferStartEmail();
            OEEEmail oee = new OEEEmail();
            oee.SendOEEEmail();
            Console.WriteLine("邮件发送完毕");

        }
    }
}
