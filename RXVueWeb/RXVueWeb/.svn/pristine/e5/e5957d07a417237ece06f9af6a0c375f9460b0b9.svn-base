using System.Text;
using webapi.Models;
using System.Net.Mail;
using webapi.Util;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Hangfire.Storage.Monitoring;
using Microsoft.Office.Interop.Excel;

namespace webapi.Service.SendEmail
{
    public class EmailServer
    {
        static public string SendEmail(List<String> sendTO,List<String> SendCC, String fromEmail, string fromPwd, String fromName, String title, String Emailbody,String ExcelPath) {

            String sBody = Emailbody;


            string attachmentPath = ExcelPath;

            MailMessage mail = new MailMessage();
            if(sendTO != null && sendTO.Count != 0)
            {
                foreach (String to in sendTO)
                {
                    mail.To.Add(to);
                }
            }
            if (SendCC != null && SendCC.Count != 0)
            {
                foreach (String cc in SendCC)
                {
                    mail.CC.Add(cc);
                }
            }
            mail.From = new MailAddress(fromEmail, fromName);
            /*     foreach (string to in email.sendTo)
                     mail.To.Add(to);*/
            mail.Subject = title;//邮件标题 
            mail.SubjectEncoding = Encoding.UTF8; //标题格式为UTF8 
            mail.BodyEncoding = Encoding.UTF8; //内容格式为UTF8 
            mail.IsBodyHtml = true;//设置邮件格式为html格式
            mail.Body = sBody;//邮件内容

            if (attachmentPath == @"C:\TEST\DynCT_NEW.xlsx" || attachmentPath == @"C:\TEST\WaferStart.xlsx")
            {
                if (attachmentPath == @"C:\TEST\WaferStart.xlsx") {
                    attachmentPath = @"C:\TEST\WaferStart.xlsx";
                }
                mail.Attachments.Add(new System.Net.Mail.Attachment(attachmentPath));
            }


            SmtpClient client = new SmtpClient();
            client.Host = "crmail.crc.com.cn"; //SMTP服务器地址 
            client.EnableSsl = false; //启用SSL加密 （使用除QQ邮箱之外的最好关闭）
            client.UseDefaultCredentials = false;

            client.Credentials = new System.Net.NetworkCredential(fromEmail, fromPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            //  .sendCc = "";
            /*string str = HttpHelper.Post(url, HttpHelper.ObjectToJson(email));
            ApiEntity obj = HttpHelper.JsonToObject<ApiEntity>(str);*/
            try
            {
                Console.WriteLine("发送邮件");
                client.Send(mail); //发送邮件
                Console.WriteLine("成功");
                return ("sucucess");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Send email faile,error message:" + ex.Message);
                return ("fault");
            }
        }
    }
}
