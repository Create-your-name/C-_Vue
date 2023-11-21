using webapi.Service.SaveExcel;
using webapi.Service.SendEmail;

namespace webapi.Service.Email.WaferStart_Email
{
    public class WaferStart_Email
    {

        public void SendWaferStartEmail()
        {

            String sBody = EmailBody();
            List<String> sendTO = new List<string>();
           sendTO.Add("liuhai82@rxgz.crmicro.com");
            /*           sendTO.Add("songxingxing15@rxgz.crmicro.com");
                      sendTO.Add("zhangzhenglu1@crmicro.com");
                      sendTO.Add("caolianying1@rxgz.crmicro.com");
                      sendTO.Add("liutao511@rxgz.crmicro.com");*/

            //sendTO.Add("runxin_shengchanyingyunbudep@rxgz.crmicro.com");
            /*               sendTO.Add("guojiahui@csmc.crmicro.com");
              sendTO.Add("gaojw@csmc.crmicro.com");
  */

            List<String> SendCC = new List<string>();
            /*            SendCC.Add("zhangzhenglu1@crmicro.com");*/
            SendCC.Add("liuhai82@rxgz.crmicro.com");
            String fromEmail = "crmic_nc_MES_zy@rxgz.crmicro.com";
            String fromPwd = "Rxmes@2023";
            String fromName = " Wafer Start汇总！";
            String title = " Wafer Start汇总！";
            String Emailbody = sBody;
            String ExcelPath = @"C:\TEST\WaferStart.xlsx";

            // List<String> sendTO,List<String> SendCC, String fromEmail, string fromPwd, String fromName, String title, String Emailbody,String ExcelName
            //EmailServer SendEmail = new EmailServer()
            EmailServer.SendEmail(sendTO, SendCC, fromEmail, fromPwd, fromName, title, Emailbody, ExcelPath);
            Console.WriteLine("结束WaferStart邮件");

        }


        public string EmailBody()
        {
            string EmailBody = "<font color='red'>Wafer Start汇总</font> ";
            EmailBody += "<html><title></title><body> ";
            //      <td >SIZE</td>
            EmailBody += "<Table border='1' cellspacing='1' cellpadding='1' bgcolor='black' width='100%' ><tr bgcolor=SkyBlue align='center'><td colspan=2>工艺大类</td><td colspan=2>BP投料目标</td><td colspan=2>BP投料计划</td>";
            EmailBody += "<td colspan=2>MF1+6投料目标</td><td colspan=2>MF1+6投料计划</td><td colspan=2>实际投料</td><td >产能</td><td >WIP</td><td >在线利用率</td><td colspan=2>BP达成率</td><td colspan=2>MF达成率</td></tr>";
            //      <td >SIZE</td>
            EmailBody += "<tr bgcolor=SkyBlue align='center'><td >Process</td><td >Type</td><td >BP PCS</td><td >BP KLayer</td><td >WS Acc. Plan</td><td >WS Acc. Plan(K/L)</td><td >MF PCS</td><td >MF KLayer</td><td >WS Acc. Plan</td><td >WS Acc. Plan(K/L)</td>";
            EmailBody += "<td >Acc(PCS)</td><td >Acc(K/L)</td><td >Capacity</td><td >WIP</td><td >Capacity Ratio</td><td width='5%'>Diff</td><td >达成率</td><td width='5%'>Diff</td><td >达成率</td></tr>";

            //   數據編碼   針對潤興數據進行Show        


            DateTime currentDate = DateTime.Now;
            DateTime LastDate = currentDate.AddDays(-2);
            string ExcelPath = @"C:\TEST\WaferSt1art.xlsx";
            string Sheet = "WaferStart";
            List<String> RowList = new List<string>();
            EmailBody += ExcelServer.SendExcel(ExcelPath, Sheet, RowList, currentDate, LastDate);
            // 數據結束 
            EmailBody += "</table><br><br>";
            EmailBody += "</BODY>";

            return EmailBody;

        }
    }
}
