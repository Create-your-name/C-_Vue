using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlTypes;
using webapi.Bean.Month;
using webapi.Model;
using webapi.Models;
using webapi.Service.CMP_SPTS_Email;
using webapi.Service.DynCTSummary_Email;

namespace webapi.Controllers.Month
{

    [Route("api/PcMonth")]
    [ApiController]
    public class PcMonthController : Controller
    {
        [HttpGet("Product")]
        public List<Waferstartemailmounth> ABC()
        {
            //  Wafer Start 邮件数据维护 
            List<Waferstartemailmounth> result;
            using (Rxrept2Context ctx = new Rxrept2Context())
            {
                    result= ctx.Waferstartemailmounths.ToList();
                return result;
            }

        }

        [HttpPost("WaferStart")]
        public string DbInsertWaferStart(PcMonth.PC PcMonth)
        {
            //  Wafer Start 邮件数据维护 
            using (Rxrept2Context ctx = new Rxrept2Context()) {
                var DelectInfo = ctx.Waferstartemailmounths.ToList();
                var Dle = DelectInfo.Where(e => e.Product == PcMonth.Product).ToList();
                if (Dle.Count!=0) {
                    string DeleteSql = "Delete From WaferStartEmailMounth WHERE PRODUCT='" + PcMonth.Product.ToString() + "'";
                    ctx.Database.ExecuteSqlRaw(DeleteSql);
                }
                string sql = "INSERT INTO WaferStartEmailMounth (PROCESS, PRODUCT, STAGE, BPPCS, BPWSACCPLAN, MFPCS, WSACCPLAN ,CAP)" +
                    "VALUES('"+PcMonth.GYDL+"', '" + PcMonth.Product + "','" +PcMonth.Stage + "'," +PcMonth.BP_PCS +","+PcMonth.BP_Plan+","
                    + PcMonth.MF_PCS + "," +PcMonth.MF_PLAN +",0)";
                ctx.Database.ExecuteSqlRaw(sql);
            }

                // 返回成功消息
                return "success";
        }
        [HttpPost("LT")]
        public string LtInsertWaferStart(PcMonth.LT LT)
        {
            //  刘涛单独维护产能 数据
            using (Rxrept2Context ctx = new Rxrept2Context())
            {
                string sql = "update WaferStartEmailMounth set cap = "+LT.Cap+ " where PRODUCT='" + LT.gydl.ToString() + "'";
                ctx.Database.ExecuteSqlRaw(sql);
            }

            // 返回成功消息
            return "success";
        }

        [HttpPost("FabIndex")]
        public string DbInsertFabIndex(PcMonth.FabIndex FabIndex)
        {
            //  FabIndex 数据维护 
            using (RxrepContext ctx =new RxrepContext()) {
                if (FabIndex.DailyMOVE!=1) {
                    string DeleteSql = "Delete From RANDY_EPM_TAR  WHERE PTYPE ='DailyMOVE'";
                    ctx.Database.ExecuteSqlRaw(DeleteSql);
                    string sql = "insert into RANDY_EPM_TAR (PTYPE,MP,DAY1,DAY2,DAY3,DAY4,DAY5,DAY6,DAY7,DAY8,DAY9,DAY10,DAY11,DAY12,DAY13,DAY14,DAY15,DAY16,DAY17,DAY18,DAY19,DAY20,DAY21,DAY22,DAY23,DAY24,DAY25,DAY26,DAY27,DAY28,DAY29,DAY30,DAY31,Repdate) VALUES ('DailyMOVE',"+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+","+FabIndex.DailyMOVE+",sysdate)";
                    ctx.Database.ExecuteSqlRaw(sql);
                }
                if (FabIndex.WaferStart != 1)
                {
                    string DeleteSql = "Delete From RANDY_EPM_TAR  WHERE PTYPE ='WaferStart'";
                    ctx.Database.ExecuteSqlRaw(DeleteSql);
                    string sql = "insert into RANDY_EPM_TAR (PTYPE,MP,DAY1,DAY2,DAY3,DAY4,DAY5,DAY6,DAY7,DAY8,DAY9,DAY10,DAY11,DAY12,DAY13,DAY14,DAY15,DAY16,DAY17,DAY18,DAY19,DAY20,DAY21,DAY22,DAY23,DAY24,DAY25,DAY26,DAY27,DAY28,DAY29,DAY30,DAY31,Repdate) VALUES ('WaferStart'," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + "," + FabIndex.WaferStart + ",sysdate)";
                    ctx.Database.ExecuteSqlRaw(sql);
                }
                if (FabIndex.OutPut != 1)
                {
                    string DeleteSql = "Delete From RANDY_EPM_TAR  WHERE PTYPE ='OutPut'";
                    ctx.Database.ExecuteSqlRaw(DeleteSql);
                    string sql = "insert into RANDY_EPM_TAR (PTYPE,MP,DAY1,DAY2,DAY3,DAY4,DAY5,DAY6,DAY7,DAY8,DAY9,DAY10,DAY11,DAY12,DAY13,DAY14,DAY15,DAY16,DAY17,DAY18,DAY19,DAY20,DAY21,DAY22,DAY23,DAY24,DAY25,DAY26,DAY27,DAY28,DAY29,DAY30,DAY31,Repdate) VALUES ('OutPut'," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + "," + FabIndex.OutPut + ",sysdate)";
                    ctx.Database.ExecuteSqlRaw(sql);
                }
                if (FabIndex.PhotoOut != 1)
                {
                    string DeleteSql = "Delete From RANDY_EPM_TAR  WHERE PTYPE ='PhotoOut'";
                    ctx.Database.ExecuteSqlRaw(DeleteSql);
                    string sql = "insert into RANDY_EPM_TAR (PTYPE,MP,DAY1,DAY2,DAY3,DAY4,DAY5,DAY6,DAY7,DAY8,DAY9,DAY10,DAY11,DAY12,DAY13,DAY14,DAY15,DAY16,DAY17,DAY18,DAY19,DAY20,DAY21,DAY22,DAY23,DAY24,DAY25,DAY26,DAY27,DAY28,DAY29,DAY30,DAY31,Repdate) VALUES ('PhotoOut'," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + "," + FabIndex.PhotoOut + ",sysdate)";
                    ctx.Database.ExecuteSqlRaw(sql);
                }

            }

                // 返回成功消息
                return "success";
        }

        [HttpPost("SPLLOT")]
        public string DbInsertSPLIndex(PcMonth.SPLLOTDATE SPLLOTDATE)
        {
            //  SPL 数据维护 
            using (Rxrept2Context ctx = new Rxrept2Context())
            {
                var DelectInfo = ctx.SpllotDescs.ToList();
                var Dle = DelectInfo.Where(e => e.Lotid == SPLLOTDATE.LOTID).ToList();
                if (Dle.Count != 0)
                {
                    string DeleteSql = "Delete From spllot_desc WHERE LOTID='" + SPLLOTDATE.LOTID.ToString() + "'";
                    ctx.Database.ExecuteSqlRaw(DeleteSql);
                }
                string sql = "Insert into spllot_desc(LOTID,DEPARTMENT,DOTIME,USERDESC) values('"+SPLLOTDATE.LOTID+"','"+SPLLOTDATE.DEPARTMENT+"','"+SPLLOTDATE.DOTIME+"','"+SPLLOTDATE.USERDESC+"');\r\n";
                ctx.Database.ExecuteSqlRaw(sql);
            }

            // 返回成功消息
            return "success";

        }
    }
}
