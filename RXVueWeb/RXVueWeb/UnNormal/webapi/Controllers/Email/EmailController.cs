﻿using HslCommunication.Profinet.MegMeet;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NPOI.XWPF.UserModel;
using webapi.Bean.Chart;
using webapi.Entity.Api;
using webapi.Service.CMP_SPTS_Email;
using webapi.Service.DynCTSummary_Email;
using webapi.Service.Email.OEE_Email;
using webapi.Service.Email.WaferStart_Email;
using webapi.Util;

namespace webapi.Controllers.Email
{
    [Route("api/Email")]
    [ApiController]
    public class EmailController : Controller
    {

        [HttpGet("Sendmail")]
        public string Sendmail()
        {
            DayCTEmail ct = new DayCTEmail();
            ct.SendDayCTEmail();
            CmpEmail ct2 = new CmpEmail();
            ct2.SendCmpEmail();
            WaferStart_Email waferStart = new WaferStart_Email();
            waferStart.SendWaferStartEmail();
            OEEEmail oee = new OEEEmail();
            oee.SendOEEEmail();


            /*
                        String sBody;
                        List< String > fsTo = new List<string>();

                        sBody = " TEST !!! TEST !!!";
                        fsTo.Add("liuhai82@rxgz.crmicro.com");
                        //fsTo.Add("jiangmeiyuan@rxgz.crmicro.com");
                        string url = "http://localhost:35550/api/email/sendEmail"; //接口已经写好的，启动服务可以直接调用；                -> 已重构
                        EmailEntity email = new EmailEntity();
                        email.fromName = "MES automatically";
                        email.emailTitle = "liuhai  Test";
                        email.emailBody = sBody;
                        email.sendTo = fsTo;
                        //  email.sendCc = "";
                        string str = HttpHelper.Post(url, HttpHelper.ObjectToJson(email));
                        ApiEntity obj = HttpHelper.JsonToObject<ApiEntity>(str);
                        if (obj.data == "success")
                        {
                            //邮件成功
                            return obj.data;
                        }
                        else
                        {
                            //邮件失败
                            return  obj.data ;
                        }*/
            return "sucescc";
        }


    }
}
