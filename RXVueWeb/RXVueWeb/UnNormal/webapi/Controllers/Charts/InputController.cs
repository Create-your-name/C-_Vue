using Aspose.Email.Clients.Exchange.WebService.Schema_2016;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using webapi.Bean;
using webapi.Bean.Chart;
using webapi.Entity;
using webapi.Entity.Api;
using webapi.Models;
using webapi.Util;
using static webapi.Bean.FormData;

namespace webapi.Controllers.Charts
{
    [Route("api/Charts")]
    [ApiController]
    public class InputController : Controller
    {

        [HttpGet("Product")]
        public List<ChartFrom> SelectProduct()
        {
            List<ChartFrom> result = new List<ChartFrom>();
            using (RxmesContext ctx =new RxmesContext()) {
               var GsProduct= ctx.CustProductSettings.FromSqlInterpolated($@"select *  from  cust_product_setting A  WHERE Substr(PRODUCT, 3, 2) = 'GS'").Select(e=> e.Product)
                    .ToList();
               var NdProduct = ctx.CustProductSettings.FromSqlInterpolated($@"select *  from  cust_product_setting A  WHERE Substr(PRODUCT, 3, 2) = 'ND'").Select(e => e.Product)
                   .ToList();
               var MeiProduct = ctx.CustProductSettings.FromSqlInterpolated($@"select *  from  cust_product_setting A  WHERE Substr(PRODUCT, 3, 2) = 'MM'").Select(e => e.Product)
                   .ToList();
                using (Rxrept2Context ctx3 =new Rxrept2Context()) { 
                using (RxrepContext ctx2 = new RxrepContext()) {
                    // 假设基础数据中的日期字段为 StartDate
                    var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // 获取本月的第一天
                    var endDate = startDate.AddMonths(1).AddDays(-1); // 获取本月的最后一天
                        DateTime currentDate = DateTime.Now;

                        //  年为单位


                        if (DateTime.Now.Date == new DateTime(DateTime.Now.Year,DateTime.Now.Month,1).Date) {
                            startDate = startDate.AddMonths(-1);
                            endDate = startDate.AddMonths(1).AddDays(-1);
                        }

                        var startDate2 = new DateTime(DateTime.Now.Year, 1, 1); // 获取本年的第一天
                        var endDate2 = startDate2.AddYears(1).AddDays(-1); ; // 获取本年的最后一天


                        var daysInMonth = Enumerable.Range(0, (endDate - startDate).Days + 1)
                        .Select(offset => startDate.AddDays(offset))
                        .ToList();

                        var monthsInYear = Enumerable.Range(0, 12)
                        .Select(offset => startDate2.AddMonths(offset))
                        .ToList();


                    var GsNumber = GsProduct.SelectMany(product => ctx2.RptWaferStarts.FromSqlInterpolated($@"select * from rpt_wafer_start where PRODUCTNAME = {product}")).ToList();
                    var NdNumber = NdProduct.SelectMany(product => ctx2.RptWaferStarts.FromSqlInterpolated($@"select * from rpt_wafer_start where PRODUCTNAME = {product}")).ToList();
                    var MeiNumber = MeiProduct.SelectMany(product => ctx2.RptWaferStarts.FromSqlInterpolated($@"select * from rpt_wafer_start where PRODUCTNAME = {product}")).ToList();

                    var GsONumber = GsProduct.SelectMany(product => ctx2.RptLotFinishes.FromSqlInterpolated($@"select * from RPT_LOT_FINISH where PRODUCTNAME = {product}")).ToList();
                    var NdONumber = NdProduct.SelectMany(product => ctx2.RptLotFinishes.FromSqlInterpolated($@"select * from RPT_LOT_FINISH where PRODUCTNAME = {product}")).ToList();
                    var MeiONumber = MeiProduct.SelectMany(product => ctx2.RptLotFinishes.FromSqlInterpolated($@"select * from RPT_LOT_FINISH where PRODUCTNAME = {product}")).ToList();

                    var GsHNumber = GsProduct.SelectMany(product => ctx2.VMfgHoldLastests.FromSqlInterpolated($@"select * from v_mfg_hold_lastest where PRODUCTNAME = {product} AND  AREA='QA'  AND HOLDREASON='HRMM11'")).ToList();
                    var NdHNumber = NdProduct.SelectMany(product => ctx2.VMfgHoldLastests.FromSqlInterpolated($@"select * from v_mfg_hold_lastest where PRODUCTNAME = {product} AND  AREA='QA'  AND HOLDREASON='HRMM11'")).ToList();
                    var MeiHNumber = MeiProduct.SelectMany(product => ctx2.VMfgHoldLastests.FromSqlInterpolated($@"select * from v_mfg_hold_lastest where PRODUCTNAME = {product}  AND  AREA='QA'  AND HOLDREASON='HRMM11' ")).ToList();


                        // 每月计算   投入
                        var GsData = daysInMonth.Select(day =>
                    {
                        var gsNumber = GsNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);
                        return new
                        {
                            GsNumber = gsNumber,
                        };
                    }).ToList();

                    var NdData = daysInMonth.Select(day =>
                    {
                        var ndNumber = NdNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);

                        return new
                        {
                            NdNumber = ndNumber,
                        };
                    }).ToList();

                    var MeiData = daysInMonth.Select(day =>
                    {
                         var meiNumber = MeiNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);

                        return new
                        {
                            MeiNumber = meiNumber,
                        };
                    }).ToList();

                        //  计算每月 总投入 曲线
                    var sum = 0;
                    var AccActData = daysInMonth.Select(day =>
                    {
                
                        var meiNumber = MeiNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);
                        var ndNumber = NdNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);
                        var gsNumber = GsNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);

                        sum += Convert.ToInt32(meiNumber) + Convert.ToInt32(gsNumber) + Convert.ToInt32(ndNumber) ;
                        return new
                        {

                            AccActNumber = sum

                        };
                    }).ToList();

                        // 计算 年平均
                        var GsDayAve = monthsInYear.Select(month =>
                        {
                           var gsNumber = GsNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                            var dayInMonth = DateTime.DaysInMonth(month.Date.Year, month.Date.Month);
                            return new
                            {
                                GsMNumber = Math.Round((double)((gsNumber) / dayInMonth), 2),
                            };
                        }).ToList();

                        var NdDayhAve = monthsInYear.Select(month =>
                        {
                            var ndNumber = NdNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                            var dayInMonth = DateTime.DaysInMonth(month.Date.Year, month.Date.Month);
                            return new
                            {
                                NdNumber = Math.Round((double)(ndNumber) / dayInMonth, 2),
                            };
                        }).ToList();

                        var MeiDayAve = monthsInYear.Select(month =>
                        {
                           var meiNumber = MeiNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                            var dayInMonth = DateTime.DaysInMonth(month.Date.Year, month.Date.Month);

                            return new
                            {
                                MeiNumber = Math.Round((double)(meiNumber ) / dayInMonth, 2),
                            };
                        }).ToList();
                        var myList2 = new List<int> { 0, 0 };

                        // Wafer Start  投入 +2  +年平均
                        string title = "GS";
                         double[] number = GsData.Select(x => x.GsNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                        number = number.Concat(myList2.Select(e => ((uint)e)).Select(Convert.ToDouble)).ToArray();
                        number = number.Concat(GsDayAve.Select(e => e.GsMNumber).Select(Convert.ToDouble)).ToArray();
                        ChartFrom chart0 = new ChartFrom(title, number);
                         result.Add(chart0);

                    string title2 = "ND";
                        double[] number2 = NdData.Select(x => x.NdNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                        number2 = number2.Concat(myList2.Select(e => ((uint)e)).Select(Convert.ToDouble)).ToArray();
                        number2 = number2.Concat(NdDayhAve.Select(e => e.NdNumber).Select(Convert.ToDouble)).ToArray();
                        ChartFrom chart1 = new ChartFrom(title2, number2);
                    result.Add(chart1);

                    string title3 = "MEI";
                        double[] number3 = MeiData.Select(x => x.MeiNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                        number3 = number3.Concat(myList2.Select(e => ((uint)e)).Select(Convert.ToDouble)).ToArray();
                        number3 = number3.Concat(MeiDayAve.Select(e => e.MeiNumber).Select(Convert.ToDouble)).ToArray();
                        ChartFrom chart2 = new ChartFrom(title3, number3);
                    result.Add(chart2);


                    string title4 = "ACC act";
                        double[] number4 = AccActData.Select(x => x.AccActNumber).Select(Convert.ToDouble).ToArray();
                    ChartFrom chart3 = new ChartFrom(title4, number4);
                    result.Add(chart3);

                    //一个月维护一次
                    string title5 = "动态目标";
                        double[] number5 = { 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93 };
                    ChartFrom chart4 = new ChartFrom(title5, number5);
                    result.Add(chart4);

                    string title6 = "MP目标";
                        double[] number6 = { 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93, 93 };
                    ChartFrom chart5 = new ChartFrom(title6, number6);
                    result.Add(chart5);

                    string title7 = "Acc Target";
                        double[] number7 = new double[number6.Length];
                    number7[0] = number6[0];
                    for (int i = 1; i < number6.Length; i++)
                    {
                        number7[i] = number7[i - 1] + number6[i];
                    }

                    ChartFrom chart6 = new ChartFrom(title7, number7);
                    result.Add(chart6);

                        //wafer Out

                        // 每月计算  o->Out
                        var GsoData = daysInMonth.Select(day =>
                        {
                            var gsHNumber = GsHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                            var gsNumber = GsONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qaoutqty);

                            if (day.Date.ToString("yyyy/MM/dd") =="2023/10/02" ) {
                                 gsHNumber = 0;
                                 gsNumber = 0;
                            }
                            return new
                            {
                                GsNumber = gsNumber + gsHNumber,
                            };
                        }).ToList();

                        var NdoData = daysInMonth.Select(day =>
                        {
                            var ndHNumber = NdHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                            var ndNumber = NdONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).ToString("yyyy /MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qaoutqty);
                            if (day.Date.ToString("yyyy/MM/dd") == "2023/10/02")
                            {
                                ndHNumber = 0;
                                ndNumber = 0;
                            }
                            if (day.Date.ToString("yyyy/MM/dd") == "2023/11/04")
                            {
                                ndHNumber = 0;
                                ndNumber = 0;
                            }
                            if (day.Date.ToString("yyyy/MM/dd") == "2023/11/02")
                            {
                                ndHNumber = 0;
                                ndNumber = 0;
                            }
                            if (day.Date.ToString("yyyy/MM/dd") == "2023/11/06")
                            {
                                ndHNumber = 2;
                                ndNumber = 0;
                            }
                            if (day.Date.ToString("yyyy/MM/dd") == "2023/11/07")
                            {
                                ndHNumber = 48;
                                ndNumber = 0;
                            }

                            return new
                            {
                                NdNumber = ndNumber + ndHNumber,
                            };
                        }).ToList();

                        var MeioData = daysInMonth.Select(day =>
                        {
                            var meiHNumber = MeiHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                            var meiNumber = MeiONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qaoutqty);
                            if (day.Date.ToString("yyyy/MM/dd") == "2023/10/02")
                            {
                                meiHNumber = 0;
                                meiNumber = 0;
                            }
                            return new
                            {
                                MeiNumber = meiNumber + meiHNumber,
                            };
                        }).ToList();


                        // 年投入

                        var GsMonth = monthsInYear.Select(month =>
                    {
                        var gsNumber = GsNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);
                        return new
                        {
                            GsMNumber = gsNumber,
                        };
                    }).ToList();

                    var NdMonth = monthsInYear.Select(month =>
                    {
                        var ndNumber = NdNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                        return new
                        {
                            NdNumber = ndNumber,
                        };
                    }).ToList();

                    var MeiMonth = monthsInYear.Select(month =>
                    {
                        var meiNumber = MeiNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                        return new
                        {
                            MeiNumber = meiNumber,
                        };
                    }).ToList();
                        
                        //123

                        //  start ->年为单位  年投入  第二幅图
                            string Month = "GS";
                        double[] Mnumber = GsMonth.Select(x => x.GsMNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                        //   Mnumber = Mnumber.Concat(GsMonthAve.Select(e=>e.GsMNumber.GetValueOrDefault()).Select(Convert.ToInt32)).ToArray();
                            ChartFrom Mchart7 = new ChartFrom(Month, Mnumber);
                            result.Add(Mchart7);

                            string Month2 = "ND";
                        double[] Mnumber2 = NdMonth.Select(x => x.NdNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                            ChartFrom Mchart8 = new ChartFrom(Month2, Mnumber2);
                            result.Add(Mchart8);

                            string Month3 = "MEI";
                        double[] Mnumber3 = MeiMonth.Select(x => x.MeiNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                            ChartFrom Mchart9 = new ChartFrom(Month3, Mnumber3);
                            result.Add(Mchart9);


                        // OUT -》  月平均

                        var GsMonthAve = monthsInYear.Select(month =>
                        {
                            var gsHNumber = GsHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                            var gsNumber = GsONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);
                            if (month.Date.ToString("yyyy/MM/dd") == "2023/09/01")
                            {
                                gsHNumber += 28;
                            }
                            if (month.Date.ToString("yyyy/MM/dd") == "2023/10/01")
                            {
                                gsHNumber -= 28;
                            }
                            
                            var dayInMonth = DateTime.DaysInMonth(month.Date.Year, month.Date.Month);
                            return new
                            {
                                GsMNumber = Math.Round((double)((gsNumber + gsHNumber) / dayInMonth), 2),
                               
                            };
                        }).ToList();

                        var NdMonthAve = monthsInYear.Select(month =>
                        {
                            var ndHNumber = NdHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                            var ndNumber = NdONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);


                            if (month.Date.ToString("yyyy/MM/dd") == "2023/09/01")
                            {
                                ndHNumber += 47;
                            }
                            if (month.Date.ToString("yyyy/MM/dd") == "2023/10/01")
                            {
                                ndHNumber -= 47;
                            }
                            if (month.Date.ToString("yyyy/MM/dd") == "2023/11/01")
                            {
                                ndHNumber -= 196;
                                ndHNumber -= 72;
                                ndHNumber -= 8;
                            }
                            var dayInMonth = DateTime.DaysInMonth(month.Date.Year, month.Date.Month);
                            return new
                            {
                                NdNumber = Math.Round((double)(ndNumber + ndHNumber) / dayInMonth, 2),
                            };
                        }).ToList();

                        var MeiMonthAve = monthsInYear.Select(month =>
                        {
                            var meiHNumber = MeiHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                            var meiNumber = MeiONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                            if (month.Date.ToString("yyyy/MM/dd") == "2023/09/01")
                            {
                                meiHNumber += 37;
                            }
                            if (month.Date.ToString("yyyy/MM/dd") == "2023/10/01")
                            {
                                meiHNumber -= 37;
                            }

                            var dayInMonth = DateTime.DaysInMonth(month.Date.Year, month.Date.Month);

                            return new
                            {
                                MeiNumber = Math.Round((double)(meiNumber + meiHNumber) / dayInMonth, 2),
                            };
                        }).ToList();

                        // Wafer Out
                        var myList = new List<int> { 0, 0};


                        string GSout = "GS";
                        double[] GSoutNum = GsoData.Select(x => x.GsNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                        GSoutNum = GSoutNum.Concat(myList.Select(e => ((uint)e)).Select(Convert.ToDouble)).ToArray();
                        GSoutNum = GSoutNum.Concat(GsMonthAve.Select(e => e.GsMNumber).Select(Convert.ToDouble)).ToArray();
                        ChartFrom GS10 = new ChartFrom(GSout, GSoutNum);
                        result.Add(GS10);

                        string NdOut = "ND";
                        double[] NdNum = NdoData.Select(x => x.NdNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                        NdNum = NdNum.Concat(myList.Select(e => ((uint)e)).Select(Convert.ToDouble)).ToArray();
                        NdNum = NdNum.Concat(NdMonthAve.Select(e => e.NdNumber).Select(Convert.ToDouble)).ToArray();
                        ChartFrom ND11 = new ChartFrom(NdOut, NdNum);
                        result.Add(ND11);

                        string MeiOut = "MEI";
                        double[] MeiNum = MeioData.Select(x => x.MeiNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                        MeiNum = MeiNum.Concat(myList.Select(e => ((uint)e)).Select(Convert.ToDouble)).ToArray();
                        MeiNum = MeiNum.Concat(MeiMonthAve.Select(e => e.MeiNumber).Select(Convert.ToDouble)).ToArray();
                        ChartFrom Mei12 = new ChartFrom(MeiOut, MeiNum);
                        result.Add(Mei12);




                    var sum2 = 0;
                    var AccActOData = daysInMonth.Select(day =>
                    {
                        var gsHNumber = GsHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                        var ndHNumber = NdHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                        var meiHNumber = MeiHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);

                        var meiNumber2 = MeiONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qaoutqty);
                        var ndNumber2 = NdONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qaoutqty);
                        var gsNumber2 = GsONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qaoutqty);

                        if (day.Date.ToString("yyyy/MM/dd") == "2023/10/02")
                        {
                            gsHNumber = 0;
                            gsNumber2 = 0;
                            ndHNumber = 0;
                            ndNumber2 = 0;
                            meiHNumber = 0;
                            meiNumber2 = 0;
                        }
                        if (day.Date.ToString("yyyy/MM/dd") == "2023/11/04")
                        {
                            gsHNumber = 0;
                            gsNumber2 = 0;
                            ndHNumber = 0;
                            ndNumber2 = 0;
                            meiHNumber = 0;
                            meiNumber2 = 0;
                        }
                        if (day.Date.ToString("yyyy/MM/dd") == "2023/11/02")
                        {
                            gsHNumber = 0;
                            gsNumber2 = 0;
                            ndHNumber = 0;
                            ndNumber2 = 0;
                            meiHNumber = 0;
                            meiNumber2 = 0;
                        }
                        if (day.Date.ToString("yyyy/MM/dd") == "2023/11/06")
                        {
                            gsHNumber = 0;
                            gsNumber2 = 0;
                            ndHNumber = 2;
                            ndNumber2 = 0;
                            meiHNumber = 0;
                            meiNumber2 = 0;
                        }
                        if (day.Date.ToString("yyyy/MM/dd") == "2023/11/07")
                        {
                            gsHNumber = 0;
                            gsNumber2 = 0;
                            ndHNumber = 48;
                            ndNumber2 = 0;
                            meiHNumber = 0;
                            meiNumber2 = 0;
                        }
                        sum2 += Convert.ToInt32(meiNumber2) + Convert.ToInt32(ndNumber2) + Convert.ToInt32(gsNumber2) + Convert.ToInt16(gsHNumber) + Convert.ToInt16(ndHNumber) + Convert.ToInt16(meiHNumber);
                        return new
                        {

                            AccActNumber = sum2

                        };
                    }).ToList();


                    string B = "ACC act";
                    double[] BB = AccActOData.Select(x => x.AccActNumber).Select(Convert.ToDouble).ToArray();
                    ChartFrom BBB13 = new ChartFrom(B, BB);
                    result.Add(BBB13);

                    //一个月维护一次
                    string C = "动态目标";
                        double[] CC = { };
                    ChartFrom CCC14 = new ChartFrom(C, CC);
                    result.Add(CCC14);

                    string D = "MP目标";
                        double[] DD = {77   ,77  , 77  , 77  , 77  , 77 , 77 , 77 , 77 , 77 , 77 , 77 , 77 , 77 , 77 , 77 , 77 , 77 , 77 , 77 , 77  ,77  ,77 , 77  ,77 ,77  ,77  ,77 ,77  ,77 };
                    ChartFrom DDD15 = new ChartFrom(D, DD);
                    result.Add(DDD15);

                    string E = "Acc Target";
                        double[] EE = new double[DD.Length];
                    EE[0] = DD[0];
                    for (int i = 1; i < DD.Length; i++)
                    {
                        EE[i] = EE[i - 1] + DD[i];
                    }

                    ChartFrom EE16 = new ChartFrom(E, EE);
                    result.Add(EE16);



                        // out 月产出 

                    var GsOMonth = monthsInYear.Select(month =>
                    {
                        var gsHNumber = GsHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                        var gsNumber = GsONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                        if (month.Date.ToString("yyyy/MM/dd") == "2023/09/01")
                        {
                            gsHNumber += 28;
                        }
                        return new
                        {
                            GsMNumber = gsNumber+gsHNumber,
                        };
                    }).ToList();

                    var NdOMonth = monthsInYear.Select(month =>
                    {
                        var ndHNumber = NdHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                        var ndNumber = NdONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                        if (month.Date.ToString("yyyy/MM/dd") == "2023/09/01")
                        {
                            ndHNumber += 47;
                            // 338 -> 326
                            ndHNumber += 12;
                        }
                        if (month.Date.ToString("yyyy/MM/dd") == "2023/10/01")
                        {
                            ndHNumber -= 36;
                        }
                        if (month.Date.ToString("yyyy/MM/dd") == "2023/11/01")
                        {
                            ndHNumber -= 196;
                            ndHNumber -= 72;
                        }
                        if (month.Date.ToString("yyyy/MM/dd") == "2023/10/01")
                        {
                            ndHNumber += 196;
                            ndHNumber += 50;

                        }
                        if (month.Date.ToString("yyyy/MM/dd") == "2023/11/01")
                        {
                            ndHNumber += 11;

                        }
                        return new
                        {
                            NdNumber = ndNumber+ndHNumber,
                        };
                    }).ToList();

                    var MeiOMonth = monthsInYear.Select(month =>
                    {
                        var meiHNumber = MeiHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                        var meiNumber = MeiONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                        if (month.Date.ToString("yyyy/MM/dd") == "2023/09/01")
                        {
                            meiHNumber += 37;
                           
                        }
                        if (month.Date.ToString("yyyy/MM/dd") == "2023/10/01")
                        {
                            meiHNumber -= 37;
                        }

                        return new
                        {
                            MeiNumber = meiNumber+meiHNumber,
                        };
                    }).ToList();


                    string OMonth = "GS";
                    double[] OMnumber = GsOMonth.Select(x => x.GsMNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                    ChartFrom OMchart = new ChartFrom(OMonth, OMnumber);
                    result.Add(OMchart);

                    string OMonth2 = "ND";
                    double[] OMnumber2 = NdOMonth.Select(x => x.NdNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                    ChartFrom OMchart2 = new ChartFrom(OMonth2, OMnumber2);
                    result.Add(OMchart2);

                    string OMonth3 = "MEI";
                        double[] OMnumber3 = MeiOMonth.Select(x => x.MeiNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
                    ChartFrom OMchart3 = new ChartFrom(OMonth3, OMnumber3);
                    result.Add(OMchart3);

                        //标准线

                        //纯 HOLD  统计

                        var sumresult = 0;
                        var hold = monthsInYear.Select(month =>
                        {
                            var meiHNumber = MeiHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                            var ndHNumber = NdHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                            var gsHNumber = GsHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                            
                            sumresult += Convert.ToInt32(ndHNumber) + Convert.ToInt32(meiHNumber) + Convert.ToInt32(gsHNumber);

                            return new
                            {
                                holdNumber = sumresult,
                            };
                        }).ToList();

                        string holdt = "hold";
                        double[] holdNum = hold.Select(x => x.holdNumber).Select(Convert.ToDouble).ToArray();
                        ChartFrom HoldNum = new ChartFrom(holdt, holdNum);
                        result.Add(HoldNum);


                        var abc = 0;
                        // 大于 8 月31日 的 总投量
                        var year = monthsInYear.Select(month =>
                        {
                            if (month.Date >= new DateTime(2023,8,1)) {
                                var meiNumber = MeiNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);
                                var ndNumber = NdNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);
                                var gsNumber = GsNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);

                                abc += Convert.ToInt32(meiNumber) + Convert.ToInt32(gsNumber) + Convert.ToInt32(ndNumber);
                            }
                            return new
                            {
                                MeiNumber = abc,
                            };
                        }).ToList();

                        string years = "hold";
                        double[] yearS = year.Select(x => x.MeiNumber).Select(Convert.ToDouble).ToArray();
                        ChartFrom NowYear = new ChartFrom(years, yearS);
                        result.Add(NowYear);





                        //     改就 死

                        int dayDiff = (currentDate - startDate).Days;

                        string waferStartMP = "动态目标";
                        double[] waferStartMPnumber = new double [number7.Length];
                        int abcd= number7.Length;
                        for (var start =0; start< dayDiff; start++) {
                            waferStartMPnumber[start] = Math.Round( (number7[number7.Length-1] - number4[start]) / ( abcd-(start + 1)!=0? (abcd - (start + 1)):1), 0);
                            if (waferStartMPnumber[start] > 200)
                            {
                                waferStartMPnumber[start] = 201;
                            }
                            if (waferStartMPnumber[start] < 40) {
                                waferStartMPnumber[start] = 41;
                            }
                        }
                         for (; dayDiff < number4.Length; dayDiff++)
                        {
                            waferStartMPnumber[dayDiff] = waferStartMPnumber[dayDiff-1];
                            if (waferStartMPnumber[dayDiff] > 200)
                            {
                                waferStartMPnumber[dayDiff] = 201;
                            }
                            if (waferStartMPnumber[dayDiff] < 40)
                            {
                                waferStartMPnumber[dayDiff] = 41;
                            }
                        }
                        ChartFrom waferStartMPresult = new ChartFrom(waferStartMP, waferStartMPnumber);
                        result.Add(waferStartMPresult);



                        dayDiff = (currentDate - startDate).Days;

                        string waferOutMP = "动态目标";
                        double[] waferOutMPnumber = new double[EE.Length];
                        int abcde = EE.Length;
                        for (var start = 0; start < dayDiff; start++)
                        {
                            waferOutMPnumber[start] = Math.Round((EE[EE.Length - 1] - BB[start]) / (abcde - (start + 1) != 0 ? (abcde - (start + 1)) : 1), 0);
                            if (waferOutMPnumber[start] > 200)
                            {
                                waferOutMPnumber[start] = 201;
                            }
                            if (waferOutMPnumber[start] < 40)
                            {
                                waferOutMPnumber[start] = 41;
                            }
                        }
                        for (; dayDiff < BB.Length; dayDiff++)
                        {
                            waferOutMPnumber[dayDiff] = waferOutMPnumber[dayDiff-1];
                            if (waferOutMPnumber[dayDiff] > 200)
                            {
                                waferOutMPnumber[dayDiff] = 201;
                            }
                            if (waferOutMPnumber[dayDiff] < 40)
                            {
                                waferOutMPnumber[dayDiff] = 41;
                            }
                        }
                        ChartFrom waferOutMPresult = new ChartFrom(waferOutMP, waferOutMPnumber);
                        result.Add(waferOutMPresult);

                        //  泪目  真改不动

                        
                        string NowDay = "今日";
                        double[] nowDayNumber = new double[1] ;
                        if (DateTime.Now.Day == 1)
                        {
                            nowDayNumber[0] = DateTime.Now.AddDays(-1).Day;
                        }
                        else {
                            nowDayNumber[0] = DateTime.Now.Day;
                        }
                        ChartFrom today = new ChartFrom(NowDay, nowDayNumber);
                        result.Add(today);


                    }
                }
            }

                return result;

        }

        [HttpGet("Date")]
        public List<DateFrom> Date()
        {
            List<DateFrom> result = new List<DateFrom>();
            DateTime currentDate = DateTime.Now;
            DateTime noeDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (currentDate.Date == noeDate.Date) {
                currentDate.AddDays(-1);
            }
            int year = currentDate.Year;
            int month = currentDate.Month;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(year, month, day);
                string formattedDate = date.ToString(date.ToString("M/d"));
                DateFrom dateFrom = new DateFrom();
                dateFrom.DateDay = formattedDate.Substring(0, formattedDate.Length);
                result.Add(dateFrom);
            }


            for (int day = 1; day <= 2; day++)
            {
                DateTime date = new DateTime(year, month, day);
                string formattedDate = "";
                DateFrom dateFrom = new DateFrom();
                dateFrom.DateDay = formattedDate.Substring(0, formattedDate.Length);
                result.Add(dateFrom);
            }


            return result;
        }


    }
}
