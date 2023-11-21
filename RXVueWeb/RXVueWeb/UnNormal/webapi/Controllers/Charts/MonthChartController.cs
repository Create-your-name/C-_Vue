using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using webapi.Bean.Chart;
using webapi.Model;
using webapi.Models;
using System.Globalization;
using System.Collections.Generic;

namespace webapi.Controllers.Charts
{
    [Route("api/MonthPlan")]
    [ApiController]
    public class MonthChartController : Controller
    {
        [HttpGet("Plan")]
        public List<ChartFrom> PcMonth()
        {
            //  请勿
            DateTime currentDate = DateTime.Today;
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            DateTime noeDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            List<ChartFrom> showList = new List<ChartFrom>();

            using (Rxrept2Context rxrep2 = new Rxrept2Context ()) {
                var result = rxrep2.Monthplans.ToList().GroupBy(e=> e.Dept).ToList();
                foreach (var WaferState in result) {
                    foreach (var DeptWafer in WaferState) {
                        Monthplan chart = new Monthplan();
                        string ChartName = DeptWafer.Process;
                        double[] chartNumber = new double[daysInMonth] ;
                            for (int i = 0; i < daysInMonth; i++)
                            {
                                chartNumber[i] = 0; // 初始化为0
                                for (int j = 0; j <= i; j++)
                                {
                                    // 累加每天的值
                                    switch (j + 1)
                                    {
                                        case 1: chartNumber[i] += (double) DeptWafer.Day1.GetValueOrDefault(); break;
                                        case 2: chartNumber[i] += (double)DeptWafer.Day2.GetValueOrDefault(); break;
                                        case 3: chartNumber[i] += (double)DeptWafer.Day3.GetValueOrDefault(); break;
                                        case 4: chartNumber[i] += (double)DeptWafer.Day4.GetValueOrDefault(); break;
                                        case 5: chartNumber[i] += (double)DeptWafer.Day5.GetValueOrDefault(); break;
                                        case 6: chartNumber[i] += (double)DeptWafer.Day6.GetValueOrDefault(); break;
                                        case 7: chartNumber[i] += (double)DeptWafer.Day7.GetValueOrDefault(); break;
                                        case 8: chartNumber[i] += (double)DeptWafer.Day8.GetValueOrDefault(); break;
                                        case 9: chartNumber[i] += (double)DeptWafer.Day9.GetValueOrDefault(); break;
                                        case 10: chartNumber[i] += (double)DeptWafer.Day10.GetValueOrDefault(); break;
                                        case 11: chartNumber[i] += (double)DeptWafer.Day11.GetValueOrDefault(); break;
                                        case 12: chartNumber[i] += (double)DeptWafer.Day12.GetValueOrDefault(); break;
                                        case 13: chartNumber[i] += (double)DeptWafer.Day13.GetValueOrDefault(); break;
                                        case 14: chartNumber[i] += (double)DeptWafer.Day14.GetValueOrDefault(); break;
                                        case 15: chartNumber[i] += (double)DeptWafer.Day15.GetValueOrDefault(); break;
                                        case 16: chartNumber[i] += (double)DeptWafer.Day16.GetValueOrDefault(); break;
                                        case 17: chartNumber[i] += (double)DeptWafer.Day17.GetValueOrDefault(); break;
                                        case 18: chartNumber[i] += (double)DeptWafer.Day18.GetValueOrDefault(); break;
                                        case 19: chartNumber[i] += (double)DeptWafer.Day19.GetValueOrDefault(); break;
                                        case 20: chartNumber[i] += (double)DeptWafer.Day20.GetValueOrDefault(); break;
                                        case 21: chartNumber[i] += (double)DeptWafer.Day21.GetValueOrDefault(); break;
                                        case 22: chartNumber[i] += (double)DeptWafer.Day22.GetValueOrDefault(); break;
                                        case 23: chartNumber[i] += (double)DeptWafer.Day23.GetValueOrDefault(); break;
                                        case 24: chartNumber[i] += (double)DeptWafer.Day24.GetValueOrDefault(); break;
                                        case 25: chartNumber[i] += (double)DeptWafer.Day25.GetValueOrDefault(); break;
                                        case 26: chartNumber[i] += (double)DeptWafer.Day26.GetValueOrDefault(); break;
                                        case 27: chartNumber[i] += (double)DeptWafer.Day27.GetValueOrDefault(); break;
                                        case 28: chartNumber[i] += (double)DeptWafer.Day28.GetValueOrDefault(); break;
                                        case 29: chartNumber[i] += (double)DeptWafer.Day29.GetValueOrDefault(); break;
                                        case 30: chartNumber[i] += (double)DeptWafer.Day30.GetValueOrDefault(); break;
                                        case 31: chartNumber[i] += (double)DeptWafer.Day31.GetValueOrDefault(); break;
                                        default: break;
                                    }
                                }
                            }
                        ChartFrom chartresult = new ChartFrom(ChartName, chartNumber);
                        showList.Add(chartresult);

                        //  计划 已完成 


                        var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // 获取本月的第一天
                        var endDate = startDate.AddMonths(1).AddDays(-1); // 获取本月的最后一天
                        if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date)
                        {
                            startDate = startDate.AddMonths(-1);
                            endDate = startDate.AddMonths(1).AddDays(-1);
                        }
                        var daysIMonth = Enumerable.Range(0, (endDate - startDate).Days + 1)
                                        .Select(offset => startDate.AddDays(offset))
                                        .ToList();

                        List<double> OutNumber; 
                        if (DeptWafer.Dept == "Waferstart")
                        {
                            using (RxmesContext rxmes = new RxmesContext())
                            {
                                var Product = rxmes.CustProductSettings.FromSqlInterpolated($@"select *  from  cust_product_setting A  WHERE  processtype = {DeptWafer.Process}").Select(e => e.Product).ToList();
                                using (RxrepContext rxrep = new RxrepContext())
                                {
                                    var Number = Product.SelectMany(product => rxrep.RptWaferStarts.FromSqlInterpolated($@"select * from rpt_wafer_start where PRODUCTNAME = {product}")).ToList();
                                    var number  = daysIMonth.Select(day =>
                                    {
                                        var ndNumber = Number.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);

                                        return new
                                        {
                                            NdNumber = ndNumber,
                                        };
                                    }).ToList();
                                     OutNumber = number.Select(e => (double)e.NdNumber).ToList();
                                    ChartFrom chartresult2 = new ChartFrom(ChartName, OutNumber.ToArray());
                                    showList.Add(chartresult2);
                                }
                            }
                        }
                        else
                        {
                            using (RxmesContext rxmes = new RxmesContext())
                            {
                                var Product = rxmes.CustProductSettings.FromSqlInterpolated($@"select *  from  cust_product_setting A  WHERE  processtype = {DeptWafer.Process}").Select(e => e.Product).ToList();

                                using (RxrepContext rxrep = new RxrepContext())
                                {
                                    var FinshNumber = Product.SelectMany(product => rxrep.RptLotFinishes.FromSqlInterpolated($@"select * from RPT_LOT_FINISH where PRODUCTNAME =  {product}")).ToList();
                                    var FinshHNumber = Product.SelectMany(product => rxrep.VMfgHoldLastests.FromSqlInterpolated($@"select * from v_mfg_hold_lastest where PRODUCTNAME = {product} AND  AREA='QA'  AND HOLDREASON='HRMM11'")).ToList();
                                    var number = daysIMonth.Select(day =>
                                    {
                                        var gsHNumber = FinshHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                                        var gsNumber = FinshNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qaoutqty);

                                        return new
                                        {
                                            NdNumber = gsNumber + gsHNumber,
                                        };
                                    }).ToList();

                                     OutNumber = number.Select(e => (double)e.NdNumber).ToList();
                                    ChartFrom chartresult2 = new ChartFrom(ChartName, OutNumber.ToArray());
                                    showList.Add(chartresult2);
                                }
                            }
                        }
                        double[] chartNumber2 = OutNumber.ToArray();
                        double[] chartNumber3 = new double[chartNumber.Length];
                        chartNumber3[0] = chartNumber2[0]; 
                        for (int i = 1 ; i<chartNumber.Length; i++) {
                            chartNumber3[i] = chartNumber3[i-1] + chartNumber2[i];
                        }
                        ChartFrom chartresult3 = new ChartFrom(ChartName, chartNumber3);
                        showList.Add(chartresult3);
                    }
                }
                return showList;
            }

        }
    }
}
