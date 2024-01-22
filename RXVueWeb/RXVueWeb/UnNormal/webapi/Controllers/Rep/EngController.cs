using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Linq;
using System.Text;
using webapi.Bean.Rep;
using webapi.Entity;
using webapi.Model;
using webapi.Models;
using webapi.Service.Chart;

namespace webapi.Controllers.Rep
{

    [Route("api/Spc")]
    [ApiController]
    public class EngController : Controller
    {
        [HttpPost("Table/EngLot")]

        public List<EngBean> GetEngLot()
        {
            using (Rxrept2Context rxrep2 = new Rxrept2Context())
            {
                    List<EngBean> result = new List<EngBean>();
                // 工程或量产
                   var resultRep = rxrep2.RepActl15mins.Where(e=> e.Lotid.Contains("E.")).ToList();
                    result = TableGetBean.GetBean(result, resultRep);
                    return result;

            }
        }

        [HttpPost("Table/WaferStartTable")]

        public async Task<List<EngBean>> WaferStart()
        {
            using (Rxrept2Context rxrep2 = new Rxrept2Context())
            {
                List<EngBean> result = new List<EngBean>();
                using (var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
                {
                    var jsonString = await reader.ReadToEndAsync();
                    JObject jsonParams = JObject.Parse(jsonString);

                    var param1 = jsonParams["param1"].ToString();
                    var param2 = jsonParams["param2"].ToString();


                    var now = DateTime.Now;
                    var year = now.Year;
                    var month = now.Month;

                    var day = int.Parse(param2.Split('/')[1]);

                    var targetDate = new DateTime(year, month, day);

                    if (param1 =="MEI") {
                        param1 = "MM";
                    }

                    using (RxrepContext rxrep = new RxrepContext()) {

                        var resultRep = rxrep.RptWaferStarts.FromSqlInterpolated($@"select * from rpt_wafer_start A WHERE Substr(PRODUCTNAME, 3, 2) = {param1.ToString()}")
                            .ToList()
                            .Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(targetDate.Date.ToString("yyyy/MM/dd")))
                            .ToList();

                        result = TableGetBean.WaferStartBean(result, resultRep);

                        return result; 

                    }

                }
            }
        }

        [HttpPost("Table/WaferOutTable")]

        public async Task<List<EngBean>> WaferOut()
        {
            using (Rxrept2Context rxrep2 = new Rxrept2Context())
            {
                List<EngBean> result = new List<EngBean>();
                Console.WriteLine("123");
                using (var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
                {
                    var jsonString = await reader.ReadToEndAsync();
                    JObject jsonParams = JObject.Parse(jsonString);

                    var param1 = jsonParams["param1"].ToString();
                    var param2 = jsonParams["param2"].ToString();

                    var now = DateTime.Now;
                    var year = now.Year;
                    var month = now.Month;

                    var day = int.Parse(param2.Split('/')[1]);

                    var targetDate = new DateTime(year, month, day);

                    if (param1 == "MEI")
                    {
                        param1 = "MM";
                    }

                    using (RxrepContext rxrep = new RxrepContext())
                    {

                        var resultRep = rxrep.RptLotFinishes.FromSqlInterpolated($@"select * from RPT_LOT_FINISH A WHERE Substr(PRODUCTNAME, 3, 2) = {param1}")
                            .ToList()
                            .Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd")) == DateTime.Parse(targetDate.Date.ToString("yyyy/MM/dd")))
                            .ToList();
                        result = TableGetBean.WaferOutBean(result, resultRep);

                        return result;

                    }

                }
            }
        }

        [HttpPost("Table/TXLot")]
        public List<EngBean> GetScrapLot()
        {
            using (Rxrept2Context rxrep2 = new Rxrept2Context())
            {
                List<EngBean> result = new List<EngBean>();
                // 工程或量产
                var resultRep = rxrep2.RepActl15mins.Where(e => e.Lotid.Contains("T") || e.Lotid.Contains("X")).ToList();
                result = TableGetBean.GetBean(result, resultRep);
                return result;

            }
        }


        [HttpGet("Table/ProcessTableList")]
        public List<CustEqpConstraint> ProcessCon()
        {
            using (RxmesContext rxmes = new RxmesContext()) {
                var result = rxmes.CustEqpConstraints.ToList();
                return result;
            }
        }

        [HttpPost("Table/ProcessTable")]
        public List<CustEqpConstraint> GetProcessCon([FromBody] ProcessTable form )
        {
            using (RxmesContext rxmes = new RxmesContext())
            {
                var result = rxmes.CustEqpConstraints
                    .Where(e=> (form.EQPID==""||form.EQPID==null)? e.Eqpid!="" : e.Eqpid == form.EQPID)
                    .Where(e=> (form.Process == "" || form.Process == null) ? e.Process != "" : e.Process == form.Process)
                    .Where(e=> (form.Product == "" || form.Product == null) ? e.Product != "" : e.Product == form.Product)
                    .Where(e=> (form.Stage == "" || form.Stage == null) ? e.Stage != "" : e.Stage == form.Stage)
                    .Where(e=> (form.Step == "" || form.Step == null) ? e.Step != "" : e.Step == form.Step)
                    .ToList();

                return result;
            }
        }

    }
}
