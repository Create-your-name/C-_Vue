using Microsoft.AspNetCore.Mvc;
using webapi.Service.SaveExcel;
using webapi.Service.SendEmail;

namespace webapi.Service.Email.OEE_Email
{
    public class OEEEmail : Controller
    {
        public void SendOEEEmail()
        {
            String sBody = EmailBody();
            List<String> sendTO = new List<string>();
            // sendTO.Add("liuhai82@rxgz.crmicro.com");
            /*            sendTO.Add("songxingxing15@rxgz.crmicro.com");
                        sendTO.Add("zhangzhenglu1@crmicro.com");
                        sendTO.Add("caolianying1@rxgz.crmicro.com");*/

             sendTO.Add("runxin_shengchanyingyunbudep@rxgz.crmicro.com");

            List<String> SendCC = new List<string>();
            SendCC.Add("liuhai82@rxgz.crmicro.com");
            String fromEmail = "crmic_nc_MES_zy@rxgz.crmicro.com";
            String fromPwd = "Rxmes@2023";
            String fromName = " OEE Report_NEW";
            String title = " OEE Report_NEW";
            String Emailbody = sBody;
            String ExcelPath = @"C:\TEST\OEE.xlsx";

            // List<String> sendTO,List<String> SendCC, String fromEmail, string fromPwd, String fromName, String title, String Emailbody,String ExcelName
            //EmailServer SendEmail = new EmailServer()
            EmailServer.SendEmail(sendTO, SendCC, fromEmail, fromPwd, fromName, title, Emailbody, ExcelPath);
            Console.WriteLine("结束OEE邮件");

        }





        public string EmailBody()
        {
            string EmailBody = "<font size=2 face=Arial color=red><b>OEE DATA<b> <hr> ";
            EmailBody += "<html><title></title><body> <font size=2 face=Arial color=red><b>Available: <b> <hr>";
            EmailBody += "<table border=1 cellspacing=1 cellpadding=2 bgcolor=black width=700>";
            EmailBody += "<tr bgcolor=SkyBlue><td align=center width=100><font size=2 face=Arial color=black>DATA</td> <td align=center width=100><font size=2 face=Arial color=black>F5</td> <td align=center width=100><font size=2 face=Arial color=black>PH</td><td align=center width=100><font size=2 face=Arial color=black>ET</td><td align=center width=100><font size=2 face=Arial color=black>TF</td><td align=center width=100><font size=2 face=Arial color=black>DF</td><td align=center width=100><font size=2 face=Arial color=black>EPI</td> ";

            DateTime currentDate = DateTime.Now;
            // DateTime LastDate = currentDate.AddDays(-32);
            DateTime LastDate = currentDate.AddDays(-32);
            string ExcelPath = @"C:\TEST\OEE.xlsx";
            string Sheet = "OEE";
            List<String> RowList = new List<string>();
            EmailBody += ExcelServer.SendExcel(ExcelPath, Sheet, RowList, currentDate, LastDate);

            EmailBody += "</tr>   ";
            EmailBody += "</table><br><br>";
            EmailBody += "</BODY>";

            return EmailBody;

        }
    }
}
