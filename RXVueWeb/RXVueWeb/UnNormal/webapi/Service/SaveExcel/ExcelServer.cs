
using OfficeOpenXml.Style;
using webapi.Models;
using System.Drawing;
using OfficeOpenXml;
using System.Security.Cryptography.X509Certificates;
using Aspose.Email.Clients.Exchange.WebService.Schema_2016;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using NPOI.SS.Formula.Functions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Collections;
using OfficeOpenXml;
using System.ComponentModel;
using System.Text;

namespace webapi.Service.SaveExcel
{
    public class ExcelServer
    {
        static public string SendExcel(string ExcelPath, string Sheet,List<String> RowList,DateTime FistTime,DateTime LastTime)
        {
            String EmailBody = "";


            DateTime nowDate = FistTime.AddDays(-1);
            ExcelWorksheet worksheet;
           // ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage p = new ExcelPackage())
            {
            
                string path = ExcelPath;
                worksheet = p.Workbook.Worksheets.Add(Sheet);
                // 算法需要重构咯
                for (int i = 1; nowDate != LastTime; nowDate = nowDate.AddDays(-1), i++)
                {
                    // DAY      ->  
                    // 这里也要进行一个 解耦
                    var YearMounth = nowDate.ToString("yyyy/MM/dd").Replace("/", "").Substring(0, 6);
                    var Day = nowDate.ToString("yyyy/MM/dd").Replace("/", "").Substring(6, 2);
                    //   封装 Row
                    foreach (var RowName in RowList) {
                        var Row = 1;
                        worksheet.Cells[1, Row].Value = RowName;
                    }
                    var l = 1;
                    for (; l < 12 && i == 1; l++)
                    {
                        worksheet.Cells[1, l].Style.Font.Size = 12;
                        //worksheet.Cells[1, 1].Style.Font.Color.SetColor(Color.Blue);
                        worksheet.Column(l).Width = 10;
                        worksheet.Cells[1, l].Style.Fill.PatternType = ExcelFillStyle.Solid; // 设置填充模式为纯色

                        // 设置背景颜色为透明的特定RGB值
                        Color backgroundColor = Color.FromArgb(128, 83, 141, 213); // 设置透明度为128
                        worksheet.Cells[1, l].Style.Fill.BackgroundColor.SetColor(backgroundColor);
                    }

                    // 封装 

                    if (ExcelPath == @"C:\TEST\DynCT_NEW.xlsx")
                    {
                        EmailBody += DatCTEmailDbInsertExcell(RowList, ref worksheet, YearMounth, Day, i + 1, nowDate);
                    }
                    else if (ExcelPath == @"C:\TEST\月结模版.xlsx")
                    {
                        EmailBody += CMP_JH_SptsEmailDbInsertExcel(ref worksheet, i + 1);
                    }
                    else if (ExcelPath == @"C:\TEST\OEE.xlsx") {
                        EmailBody += OEEmailDbInsertExcelTableOne(ref worksheet,nowDate);
                    }
                    else {
                        Console.WriteLine("Wafer Start");
                        worksheet.Dispose();
                        string Path = @"C:\TEST\WaferStart.xlsx";
                        EmailBody += WaferStartEmailDbInserExcel(i + 1, Path);
                    }

                }
                if (ExcelPath == @"C:\TEST\OEE.xlsx")
                {
                    DateTime nowDate2 = FistTime.AddDays(-1);
                    EmailBody += "</tr>   ";
                    EmailBody += "</table><br><br>";
                    EmailBody += "<font size=2 face=Arial color=red><b>Efficiency:  <b> <hr>";
                    EmailBody += "<table border=1 cellspacing=1 cellpadding=2 bgcolor=black width=700>";
                    EmailBody += "<tr bgcolor=SkyBlue><td align=center width=100><font size=2 face=Arial color=black>DATA</td> <td align=center width=100><font size=2 face=Arial color=black>F5</td> <td align=center width=100><font size=2 face=Arial color=black>PH</td><td align=center width=100><font size=2 face=Arial color=black>ET</td><td align=center width=100><font size=2 face=Arial color=black>TF</td><td align=center width=100><font size=2 face=Arial color=black>DF</td><td align=center width=100><font size=2 face=Arial color=black>EPI</td></tr>";
                    EmailBody += "<tr bgcolor=SkyBlue><td align=center width=100><font size=2 face=Arial color=black>TARGET</td> <td align=center width=100><font size=2 face=Arial color=black>86.4%</td> <td align=center width=100><font size=2 face=Arial color=black>90.9%</td><td align=center width=100><font size=2 face=Arial color=black>89.2%</td><td align=center width=100><font size=2 face=Arial color=black>89.5%</td><td align=center width=100><font size=2 face=Arial color=black>74.9%</td><td align=center width=100><font size=2 face=Arial color=black>88.3%</td></tr>";

                    for (int i = 1; nowDate2 != LastTime; nowDate2 = nowDate2.AddDays(-1), i++)
                    {
                        EmailBody += OEEmailDbInsertExcelTableTwo(ref worksheet, nowDate2);
                    }
                    EmailBody += "</tr>   ";
                    EmailBody += "</table><br><br>";
                }
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var encoding = Encoding.GetEncoding("UTF-8");
                if (path != @"C:\TEST\WaferSt1art.xlsx")
                {
                    p.SaveAs(new FileInfo(path));
                }
            }

            return EmailBody;
        }

        static public string DatCTEmailDbInsertExcell(List<String> RowList , ref ExcelWorksheet workbook,String ref1,String ref2,int ForRef,DateTime nowDate) 
        
        {
            workbook.Cells[1, 1].Value = "DAY";
            workbook.Cells[1, 2].Value = "WS";
            workbook.Cells[1, 3].Value = "WO";
            workbook.Cells[1, 4].Value = "WIP";
            workbook.Cells[1, 5].Value = "HoldWIP";
            workbook.Cells[1, 6].Value = "StepMove";
            workbook.Cells[1, 7].Value = "TR";
            workbook.Cells[1, 8].Value = "CT";
            workbook.Cells[1, 9].Value = "BANK";
            workbook.Cells[1, 10].Value = "AVG STEP/LAYER";
            workbook.Cells[1, 11].Value = "Scrap";
            string EmailBody = "";

            using (RxrepContext ctx = new RxrepContext())
            {
                var ToDay = ctx.WtDynamicctreports.Where(e => e.Period == ref1)
                    .Where(e => e.Pdate == int.Parse(ref2)).ToList();
                //  WS      ->
                var  nowDay = ref1 + ref2;
                var WaferStart = ctx.RptWaferStarts.Where( e =>e.Lotstartdate.Substring(0,8)==nowDay).Sum(e=>e.Startqty);
                var WaferOut = ctx.RptLotFinishes.Where(e => e.Qaouttime.Substring(0, 8) == nowDay).Sum(e => e.Qaoutqty);
                using (Rxrept2Context ctx2 = new Rxrept2Context())
                {
                    var HNumber = ctx.VMfgHoldLastests.FromSqlInterpolated($@"select * from v_mfg_hold_lastest where AREA='QA'  AND HOLDREASON='HRMM11'").ToList();
                    WaferOut += HNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")).ToString("yyyy/MM/dd") == DateTime.ParseExact(nowDay, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd")).Sum(e => e.Qty);
                }
                EmailBody += "<tr  bgcolor=white><td align=center width=8%><font size=2 face=Arial  color=black>" + nowDate.ToString("yyyy/MM/dd") + "</font></td>";
                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + WaferStart.ToString() + "</font></td>";
                // WO       ->      RPT_LOT_FINISH    +　　rep_actl_h　　　HOLD  +　　９　　　ＱＡ　　 HRMM11
                if (nowDay=="20231002") {
                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + 0 + "</font></td>";
                }
                else {
                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + WaferOut.ToString() + "</font></td>";
                }
                // WIP
                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + ToDay[0].Totwip + "</font></td>";
                // Hold Wip
                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + ToDay[0].Holdwip + "</font></td>";
                // Step Move
                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + ToDay[0].Totmove + "</font></td>";
                // TR
                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + ToDay[0].Tottr + "</font></td>";
                // CT
                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + ToDay[0].Totct + "</font></td>";
                // BANK
                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + ToDay[0].Bankwip + "</font></td>";
                // AVG  STEP/LAYER
                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + ToDay[0].Steplayer + "</font></td>";
                //Scrap
                var ScrapNum = ctx.CostScrap0s.ToList();
                var ScrapList = ScrapNum.Where(e => DateTime.Parse(DateTime.ParseExact(e.Scrapdate.ToString(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")).ToString("yyyy/MM/dd") == DateTime.ParseExact(nowDay, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd"))
                    .Sum(e => e.Scrapqty);
                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>" + ScrapList + "</font></td>";

                workbook.Cells[ForRef, 1].Value = nowDate.ToString("yyyy/M/d");
                workbook.Cells[ForRef, 2].Value = WaferStart.ToString();
                if (nowDay == "20231002")
                {
                    int abc = 0;
                    workbook.Cells[ForRef, 3].Value =abc.ToString();
                }
                else
                {
                    workbook.Cells[ForRef, 3].Value = WaferOut.ToString();
                }
                workbook.Cells[ForRef, 4].Value = ToDay[0].Totwip;
                workbook.Cells[ForRef, 5].Value = ToDay[0].Holdwip;
                workbook.Cells[ForRef, 6].Value = ToDay[0].Amove;
                workbook.Cells[ForRef, 7].Value = ToDay[0].Tottr;
                workbook.Cells[ForRef, 8].Value = ToDay[0].Totct;
                workbook.Cells[ForRef, 9].Value = ToDay[0].Bankwip;
                workbook.Cells[ForRef, 10].Value = ToDay[0].Steplayer;
                workbook.Cells[ForRef, 11].Value = ScrapList.ToString();
            }

            return EmailBody;
        }

        static public String CMP_JH_SptsEmailDbInsertExcel(ref ExcelWorksheet workbook, int ForRef) {

            string EmailBody = "<html><title></title><body> ";
            EmailBody += "<font size=2 face=Arial><b><b> <hr>";
            using (RxmesContext CMP = new RxmesContext()) { 
            using (Rxrept2Context ctx = new Rxrept2Context()) {
                DateTime YesDay = DateTime.Now.AddDays(-1);
                var eqp = ctx.BCapagroupMoves.Where(e => e.Capagroup == "CMP研磨抛光").ToList();
                int Yesterday = 0;
                foreach (var i in eqp) {
                    Yesterday += ctx.RepHistTots.FromSqlInterpolated(//, tt.outdate  
                          $@"select distinct t.*, tt.custordernumber
                                                        from (select t1.*
                                                              from rep_hist_tot t1 
                                                              where t1.trackouttime >= trunc(to_date({YesDay.ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                                and t1.trackouttime < trunc(to_date({YesDay.AddDays(1).ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                              order by t1.trackouttime) t, rep_actl_h_all tt 
                                                        where 1 = 1 
                                                          and t.lotid = tt.lotid(+) 
                                                          and t.lotid not like 'T%' 
                                                          and t.eqpid={i.Equipid}"
                        ).ToList().Sum(e => e.Curmainqty);
                    // 如果有参数，将其作为额外的参数传递给 FromSqlInterpolated 方法
                    // , sqlParameters 
                }

                DateTime today = DateTime.Now;
                DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                int MonthSum = 0;
                foreach (var i in eqp)
                {
                    MonthSum += ctx.RepHistTots.FromSqlInterpolated(//, tt.outdate  
                              $@"select distinct t.*, tt.custordernumber
                                                        from (select t1.*
                                                              from rep_hist_tot t1 
                                                              where t1.trackouttime >= trunc(to_date({firstDayOfMonth.ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                                and t1.trackouttime < trunc(to_date({today.AddDays(1).ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                              order by t1.trackouttime) t, rep_actl_h_all tt 
                                                        where 1 = 1 
                                                          and t.lotid = tt.lotid(+) 
                                                          and t.lotid not like 'T%' 
                                                          and t.eqpid={i.Equipid}"
                        ).ToList().Sum(e => e.Curmainqty);
                }

                EmailBody += "<font size=2 face=Arial><b>截至当前CMP MTD 产出目标:" + "6500" + "实际月累计产出:" + MonthSum.ToString() + " 昨日产出:" + Yesterday.ToString() + " 请关注设备状态和效率<b></font>";

            //    EmailBody += "<font size=2 face=Arial><b>截至当前,实际返工月累计:" + "返工月累计" + " 昨日返工:" + "昨日返工" + " 片 ，请知悉！<b></font><hr>";
                EmailBody += "<b><hr>";
            }

            EmailBody += "<font size=2 face=Arial color=red><b>CMP 昨日状态<b></font> <hr>";
            EmailBody += "<table border=1 cellspacing=1 cellpadding=1 bgcolor=black width=72%><tr bgcolor=SkyBlue><td align=center width=5%>设备ID</td><td id=1 align=center width=5%>RUN</td><td id=2 align=center width=5%>IDLE</td><td id=3 align=center width=5%>WAIT</td> <td id=4 align=center width=5%>DOWN</td>  ";
            EmailBody += "<td id=5 align=center width=5%>MON_DOWN</td><td id=6 align=center width=5%>SPCHOLD</td><td id=7 align=center width=5%>MONP_M</td><td id=8 align=center width=5%>MONR</td><td id=9 align=center width=5%>PM</td><td id=10 align=center width=5%>SETUP</td><td id=11 align=center width=5%>TEST</td>   ";
            EmailBody += "<td id=12 align=center width=5%>TEST_CW</td><td id=13 align=center width=5%>QCHOLD</td><td id=14  align=center width=5%>UNQC</td><td id=15 align=center width=5%>FAC</td><td id=16 align=center width=5%>WAITENG</td><td id=17 align=center width=5%>HOLDENG</td></tr>   ";
            workbook.Cells[1, 1].Value = "设备ID";
            workbook.Cells[1, 2].Value = "RUN";
            workbook.Cells[1, 3].Value = "IDLE";
            workbook.Cells[1, 4].Value = "DOWN";
            workbook.Cells[1, 5].Value = "TEST";
            workbook.Cells[1, 6].Value = "TESTCW";
            workbook.Cells[1, 7].Value = "PM";
            workbook.Cells[1, 8].Value = "WAITMFG";
            workbook.Cells[1, 9].Value = "MONR";
            workbook.Cells[1, 10].Value = "WAITENG";
            workbook.Cells[1, 11].Value = "SetUp";
            workbook.Cells[1, 12].Value = "SPCHOLD";
                using (RxrepContext ctx =new RxrepContext()) {
                DateTime YesDay = DateTime.Now.AddDays(-1);
                using (Rxrept2Context ctx2 = new Rxrept2Context())
                {
                    var eqp = ctx2.BCapagroupMoves.Where(e => e.Capagroup == "CMP研磨抛光").ToList();
                   // var List = YesDay.Date.ToString("yyyy/MM/dd");
                    foreach (var i in eqp) {
                            var result = ctx.RepEqpsStartEnds
                                             .FromSqlInterpolated($@"
                                        SELECT *
                                        FROM rep_eqps_start_end
                                        WHERE EQPID = {i.Equipid}
                                            AND (ENDDATE >= TRUNC(SYSDATE - 1) + 7 / 24 OR ENDDATE IS NULL)
                                            AND CHANGEDT < TRUNC(SYSDATE) + 7 / 24
                                    ")
                                             .Select(e => new
                                             {
                                                 Status = e.Status,
                                                 TimeSpan = ((e.Enddate != null) ? ((e.Enddate > DateTime.Today.AddHours(7)) ? DateTime.Today.AddHours(7) : e.Enddate   ) : DateTime.Today.AddHours(7)) -((e.Changedt != null) ? ((e.Changedt < DateTime.Today.AddDays(-1).AddHours(7)) ? DateTime.Today.AddDays(-1).AddHours(7) : e.Changedt) : DateTime.Today.AddDays(-1).AddHours(7)),
                                             })
                                             .ToList();

                            var EqpList = result.GroupBy(e => e.Status)
                                        .Select(e => new
                                        {
                                            Status = e.Key,
                                            TotalTimeSpan = e.Aggregate(TimeSpan.Zero, (total, item) => (TimeSpan)(total + item.TimeSpan))
                                        })
                                        .ToList()
                                        .OrderBy(e => e.Status) 
                                        .Select(e => new
                                        {
                                            Status = e.Status,
                                            TotalTimeSpan = (e.TotalTimeSpan.TotalHours >= 24) ? "24:00:00" : e.TotalTimeSpan.ToString(@"hh\:mm\:ss"),
                                        })
                                        .ToList();

                            /*   var abdf = new List<dynamic>()
                                               {
                                                   new { Status = "02_WAIT", TimeSpan = TimeSpan.FromMinutes(45) },
                                                   new { Status = "01_RUN", TimeSpan = TimeSpan.FromMinutes(30) },
                                                   new { Status = "02_IDLE", TimeSpan = TimeSpan.FromHours(1) },
                                                   new { Status = "03_DOWN", TimeSpan = TimeSpan.FromMinutes(45) },
                                                   new { Status = "04_MON_R", TimeSpan = TimeSpan.FromHours(2) },
                                                   new { Status = "04_PM", TimeSpan = TimeSpan.FromMinutes(15) },
                                                   new { Status = "06_TEST_CW", TimeSpan = TimeSpan.FromHours(3) },
                                                   new { Status = "TEST", TimeSpan = TimeSpan.FromMinutes(50) },
                                                   new { Status = "06_TEST", TimeSpan = TimeSpan.FromMinutes(10) },
                                                   new { Status = "04_SETUP", TimeSpan = TimeSpan.FromHours(1.5) },
                                                   new { Status = "03_SPCHOLD", TimeSpan = TimeSpan.FromMinutes(20) },
                                                   new { Status = "04_MON_PM", TimeSpan = TimeSpan.FromMinutes(40) },
                                                   new { Status = "03_MON_DOWN", TimeSpan = TimeSpan.FromMinutes(5) }
                                               };

                               var EqpList = abdf.GroupBy(e => e.Status)
                                                  .Select(e => new
                                                  {
                                                      Status = e.Key,
                                                      TotalTimeSpan = e.Aggregate(TimeSpan.Zero, (total, item) => (TimeSpan)(total + item.TimeSpan))
                                                  })
                                                  .ToList()
                                                  .OrderBy(e => e.Status)
                                                  .Select(e => new
                                                  {
                                                      Status = e.Status,
                                                      TotalTimeSpan = (e.TotalTimeSpan.TotalHours >= 24) ? "24:00:00" : e.TotalTimeSpan.ToString(@"hh\:mm\:ss"),
                                                  })
                                                  .ToList();*/

                            EmailBody += "<tr  bgcolor=white><td align=center width=8%><font size=2 face=Arial  color=black>" + i.Equipid + "</font></td>";
                        workbook.Cells[ForRef, 1].Value = i.Equipid ;
                            int id = 1;
                        foreach (var sta in EqpList) {
                                if (sta.Status == "WAITENG" || sta.Status == "04_MON_R" || sta.Status == "04_PM" || sta.Status == "06_TEST_CW" || sta.Status == "TEST" || sta.Status == "06_TEST" || sta.Status == "03_DOWN" || sta.Status == "02_IDLE" || sta.Status == "01_RUN" || sta.Status == "04_SETUP" || sta.Status == "03_SPCHOLD" || sta.Status == "04_MON_PM" || sta.Status == "03_MON_DOWN" || sta.Status == "02_WAIT")
                                {
                                            string Body = sta.Status.ToString();
                                             Console.WriteLine("Test: ");
                                            Console.WriteLine("Body: " + Body);
                                           // Body = Body.Substring(Body.IndexOf("=") + 1);
                                            Body = Body.Replace(" ", "").Replace("0", "").Replace("_", "").Replace("4", "").Replace("2", "").Replace("6", "").Replace("1", "").Replace("3", "");
                                            Console.WriteLine("Body: " + Body);
                                            if (sta.Status == "04_MON_PM")
                                            {
                                                Body = "MONP_M";
                                            }
                                            int tdid = EmailBody.IndexOf(Body);
                                            Console.WriteLine("tdid: " + tdid);
                                            if (tdid >= 0)
                                            {
                                                string BodyRe = EmailBody.Substring(tdid - 25, 2).Replace("=", "").Replace(" ", "");
                                                Console.WriteLine("BodyRe: " + BodyRe);
                                                int BodyId = int.Parse(BodyRe);
                                                Console.WriteLine("BodyId: " + BodyId);
                                                for (; id < BodyId; id++)
                                                {
                                                     Console.WriteLine("id:"+id);
                                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                                    EmailBody += "</font></td>";
                                                }
                                            }
                                    Console.WriteLine("Over:");
                                }
                                if (sta.Status != "WAITENG" && sta.Status != "04_MON_R" && sta.Status != "04_PM" && sta.Status != "06_TEST_CW" && sta.Status != "TEST" && sta.Status != "06_TEST" && sta.Status != "03_DOWN" && sta.Status != "02_IDLE" && sta.Status != "01_RUN" && sta.Status != "04_SETUP" && sta.Status != "03_SPCHOLD"&& sta.Status != "04_MON_PM" && sta.Status != "03_MON_DOWN" && sta.Status != "02_WAIT")
                                {
                                    // 需要解构
                                    IEnumerator enumerator = EqpList.GetEnumerator();
                                    while (enumerator.MoveNext())
                                    {
                                        if (enumerator.Current == sta && enumerator.MoveNext())
                                        {
                                            var nextSta = enumerator.Current ;
                                            foreach (var a in EqpList) {

                                                Console.WriteLine("suoyou元素: " + a);
                                            }
                                            Console.WriteLine("zheg元素: " + sta);
                                            Console.WriteLine("下一个元素: " + nextSta);
                                            // 凑格子
                                            string Body = nextSta.ToString();
                                            Console.WriteLine("Body: " + Body);
                                            Body = Body.Substring(Body.IndexOf("=") + 1);
                                            Body = Body.Substring(0, Body.IndexOf(",")).Replace(" ","").Replace("0","").Replace("_","").Replace("4","").Replace("2","").Replace("6","").Replace("1","").Replace("3","");
                                            Console.WriteLine("Body: " + Body);
                                            int tdid = EmailBody.IndexOf(Body);
                                            Console.WriteLine("tdid: " + tdid);
                                            if (tdid >= 0)
                                            {
                                                string BodyRe = EmailBody.Substring(tdid - 25, 2).Replace("=", "").Replace(" ", "");
                                                Console.WriteLine("BodyRe: " + BodyRe);
                                                int BodyId = int.Parse(BodyRe);
                                                Console.WriteLine("BodyId: " + BodyId);
                                                for (; id < BodyId; id++)
                                                {
                                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                                    EmailBody += "</font></td>";
                                                }
                                            }
                                            else
                                            {
                                                continue;
                                            }

                                            break;
                                        }
                                    }
                                    //函数　封装
                                    continue;
                                }

                                if (sta.Status == "01_RUN")
                            {
                                workbook.Cells[ForRef, 2].Value = sta.TotalTimeSpan;
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += sta.TotalTimeSpan;
                                EmailBody += "</font></td>";
                                    id++;
                                    continue;
                            }
                            if (sta.Status == "02_IDLE")
                            {
                                workbook.Cells[ForRef, 3].Value = sta.TotalTimeSpan;
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += sta.TotalTimeSpan;
                                EmailBody += "</font></td>";
                                    id++;
                                    continue;
                            }
                                if (sta.Status == "02_WAIT")
                                {
                                    workbook.Cells[ForRef, 3].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "03_DOWN")
                                {
                                    workbook.Cells[ForRef, 4].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "03_SPCHOLD")
                                {
                                    workbook.Cells[ForRef, 11].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "03_MON_DOWN")
                                {
                                    workbook.Cells[ForRef, 11].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "04_PM")
                                {
                                    workbook.Cells[ForRef, 7].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "04_SETUP")
                                {
                                    workbook.Cells[ForRef, 10].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "04_MON_PM")
                                {
                                    workbook.Cells[ForRef, 8].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "04_MON_R")
                                {
                                    workbook.Cells[ForRef, 8].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                            if (sta.Status == "06_TEST_CW")
                            {
                                workbook.Cells[ForRef, 6].Value = sta.TotalTimeSpan;
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += sta.TotalTimeSpan;
                                EmailBody += "</font></td>";
                                    id++;
                                    continue;
                            }
                                if (sta.Status == "TEST" || sta.Status == "06_TEST")
                                {
                                    workbook.Cells[ForRef, 5].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "WAITENG")
                            {
                                workbook.Cells[ForRef, 9].Value = sta.TotalTimeSpan;
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += sta.TotalTimeSpan;
                                EmailBody += "</font></td>";
                                    id++;
                                    continue;
                            }



                        }
                            for (;id<18 && 0!=EqpList.Count();id++) {
                                Console.WriteLine("id=" + id);
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += "</font></td>";
                            }
                            var Length = EqpList.Count();
                            if (0 == EqpList.Count())
                            {
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += "</font></td>";
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += "</font></td>";
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += "</font></td>";
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>24";
                                EmailBody += "</font></td>";
                                Length = 4;
                                for (; Length < 17; Length++)
                                {
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += "</font></td>";
                                }

                            }

                        }

                        EmailBody += "</tr>   ";
                        EmailBody += "</table><br><br>";
                        // 2 
                        // 第二张表 ！！！！
                        // second Table
                        DateTime week = DateTime.Now;
                        EmailBody += "<table border=1 cellspacing=1 cellpadding=1 bgcolor=black width=72%><tr bgcolor=SkyBlue><td align=center width=5%>EQP</td><td align=center width=5%>产能</td><td align=center width=5%>当前WIP</td><td align=center width=5%>月均产出</td>";
                        EmailBody += "<td align=center width=5%>周均产出</td><td align=center width=5%>月累计</td>";
                        for (int i = 1; i <= 7; i++)
                        {
                            EmailBody += "  <td align=center width=5%> " + week.AddDays(-i).Date.ToString("yyyy/MM/dd") + " </td>";
                        }
                        EmailBody += "</tr><tr  bgcolor=white>";
                        foreach (var i in eqp) {

                            EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + i.Equipid + "</font></td>";
                            EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + "155"+ "</font></td>";


                            using (Rxrept2Context rxrep2 = new Rxrept2Context())
                            {
                                DateTime NowDay = DateTime.Now;
                                DateTime firstDayOfMonth = new DateTime(NowDay.Year, NowDay.Month, 1);

                                DateTime MouthDay = DateTime.Now.AddDays(-31);

                                DateTime WeekDay = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek+1);


                                int diff = (7 + (NowDay.DayOfWeek - DayOfWeek.Monday)) % 7+1;
                                DateTime firstDayOfWeek = NowDay.AddDays(-1 * diff).Date;

                                   var  NowTrackIn = rxrep2.RepHistTots.Where(e=> e.Trackintime.Date==NowDay.Date && e.Eqpid== i.Equipid).ToList().Sum(e=>e.Curmainqty);
                                    EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + NowTrackIn.ToString() + "</font></td>";


                                    var MouthTrackIn = rxrep2.RepHistTots
                                                    .Where(e => e.Trackouttime <= NowDay.Date.AddHours(7) && e.Trackouttime >= firstDayOfMonth.Date.AddHours(7) && e.Eqpid == i.Equipid)
                                                    .Sum(e => e.Curmainqty);
                                    var DayInMouth = (int)NowDay.Subtract(firstDayOfMonth).TotalDays+1;
                                    var MouthSum = (int)MouthTrackIn / DayInMouth;
                                    EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + MouthSum.ToString() + "</font></td>";


                                   var WeekTrackIn = rxrep2.RepHistTots
                                                    .Where(e => e.Trackouttime <= NowDay.Date.AddHours(7) && e.Trackouttime >= WeekDay.Date.AddDays(-1).AddHours(7) && e.Eqpid == i.Equipid)
                                                    .Sum(e => e.Curmainqty);
                                    var DayInWeek = (int)NowDay.Subtract(firstDayOfWeek).TotalDays;
                                    var WeekSum = (int)WeekTrackIn / DayInWeek;
                                    EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + WeekSum.ToString() + "</font></td>";

                                    EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + MouthTrackIn.ToString() + "</font></td>";

                                    for (int Day =1; Day <=7;Day++) {
                                        var InfoWeek = DateTime.Now.AddDays(-Day);
                                    // var InfoWeekTrackIn = rxrep2.RepHistTots.Where(e => e.Trackintime.Date==InfoWeek.Date && e.Eqpid == i.Equipid).ToList().Sum(e => e.Trackinmainqty);
                                    var InfoWeekTrackIn = rxrep2.RepHistTots.FromSqlInterpolated(//, tt.outdate  
                                                    $@"select distinct t.*, tt.custordernumber
                                                        from (select t1.*
                                                              from rep_hist_tot t1 
                                                              where t1.trackouttime >= trunc(to_date({InfoWeek.ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                                and t1.trackouttime < trunc(to_date({InfoWeek.AddDays(1).ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                              order by t1.trackouttime) t, rep_actl_h_all tt 
                                                        where 1 = 1 
                                                          and t.lotid = tt.lotid(+) 
                                                          and t.lotid not like 'T%' 
                                                          and t.eqpid={i.Equipid}"
                                                ).ToList().Sum(e => e.Curmainqty);
                                    EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + InfoWeekTrackIn.ToString() + "</font></td>";
                                    }


                                

                                EmailBody += "</tr><tr bgcolor=white>   ";
                            }

                        }

                        EmailBody += "</table><br><br>";
                    }

                    //键合 


                }

            }

       

            using (RxmesContext 键合 = new RxmesContext())
            {
                using (Rxrept2Context ctx = new Rxrept2Context())
                {
                    DateTime YesDay = DateTime.Now.AddDays(-1);
                    var eqp = ctx.BCapagroupMoves.Where(e => e.Capagroup == "B-NID键合").ToList();
                    int Yesterday = 0;
                    foreach (var i in eqp)
                    {
                        Yesterday += ctx.RepHistTots.FromSqlInterpolated(//, tt.outdate  
                              $@"select distinct t.*, tt.custordernumber
                                                        from (select t1.*
                                                              from rep_hist_tot t1 
                                                              where t1.trackouttime >= trunc(to_date({YesDay.ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                                and t1.trackouttime < trunc(to_date({YesDay.AddDays(1).ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                              order by t1.trackouttime) t, rep_actl_h_all tt 
                                                        where 1 = 1 
                                                          and t.lotid = tt.lotid(+) 
                                                          and t.lotid not like 'T%' 
                                                          and t.eqpid={i.Equipid}"
                            ).ToList().Sum(e => e.Curmainqty);
                        // 如果有参数，将其作为额外的参数传递给 FromSqlInterpolated 方法
                        // , sqlParameters 
                    }

                    DateTime today = DateTime.Now;
                    DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                    int MonthSum = 0;
                    foreach (var i in eqp)
                    {
                        MonthSum += ctx.RepHistTots.FromSqlInterpolated(//, tt.outdate  
                                  $@"select distinct t.*, tt.custordernumber
                                                        from (select t1.*
                                                              from rep_hist_tot t1 
                                                              where t1.trackouttime >= trunc(to_date({firstDayOfMonth.ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                                and t1.trackouttime < trunc(to_date({today.AddDays(1).ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                              order by t1.trackouttime) t, rep_actl_h_all tt 
                                                        where 1 = 1 
                                                          and t.lotid = tt.lotid(+) 
                                                          and t.lotid not like 'T%' 
                                                          and t.eqpid={i.Equipid}"
                            ).ToList().Sum(e => e.Curmainqty);
                    }

                    EmailBody += "<font size=2 face=Arial><b>截至当前键合 MTD 产出目标:" + "1300片" + "实际月累计产出:" + MonthSum.ToString() + " 昨日产出:" + Yesterday.ToString() + " 请关注设备状态和效率<b></font>";

               //     EmailBody += "<font size=2 face=Arial><b>截至当前,实际返工月累计:" + "返工月累计" + " 昨日返工:" + "昨日返工" + " 片 ，请知悉！<b></font><hr>";
                    EmailBody += "<b><hr>";
                }
                EmailBody += "<font size=2 face=Arial color=red><b>键合 昨日状态<b></font> <hr>";
                EmailBody += "<table border=1 cellspacing=1 cellpadding=1 bgcolor=black width=72%><tr bgcolor=SkyBlue><td align=center width=5%>设备ID</td><td id=1 align=center width=5%>RUN</td><td id=2 align=center width=5%>IDLE</td><td id=3 align=center width=5%>WAIT</td> <td id=4 align=center width=5%>DOWN</td>  ";
                EmailBody += "<td id=5 align=center width=5%>MON_DOWN</td><td id=6 align=center width=5%>SPCHOLD</td><td id=7 align=center width=5%>MONP_M</td><td id=8 align=center width=5%>MONR</td><td id=9 align=center width=5%>PM</td><td id=10 align=center width=5%>SETUP</td><td id=11 align=center width=5%>TEST</td>   ";
                EmailBody += "<td id=12 align=center width=5%>TEST_CW</td><td id=13 align=center width=5%>QCHOLD</td><td id=14  align=center width=5%>UNQC</td><td id=15 align=center width=5%>FAC</td><td id=16 align=center width=5%>WAITENG</td><td id=17 align=center width=5%>HOLDENG</td></tr>   ";
                workbook.Cells[1, 1].Value = "设备ID";
                workbook.Cells[1, 2].Value = "RUN";
                workbook.Cells[1, 3].Value = "IDLE";
                workbook.Cells[1, 4].Value = "DOWN";
                workbook.Cells[1, 5].Value = "TEST";
                workbook.Cells[1, 6].Value = "TESTCW";
                workbook.Cells[1, 7].Value = "PM";
                workbook.Cells[1, 8].Value = "WAITMFG";
                workbook.Cells[1, 9].Value = "MONR";
                workbook.Cells[1, 10].Value = "WAITENG";
                workbook.Cells[1, 11].Value = "SetUp";
                workbook.Cells[1, 12].Value = "SPCHOLD";
                using (RxrepContext ctx = new RxrepContext())
                {
                    DateTime YesDay = DateTime.Now.AddDays(-1);
                    using (Rxrept2Context ctx2 = new Rxrept2Context())
                    {
                        var eqp = ctx2.BCapagroupMoves.Where(e => e.Capagroup == "B-NID键合").ToList();
                        // var List = YesDay.Date.ToString("yyyy/MM/dd");
                        foreach (var i in eqp)
                        {

                            var result = ctx.RepEqpsStartEnds
                                          .FromSqlInterpolated($@"
                                        SELECT *
                                        FROM rep_eqps_start_end
                                        WHERE EQPID = {i.Equipid}
                                            AND (ENDDATE >= TRUNC(SYSDATE - 1) + 7 / 24 OR ENDDATE IS NULL)
                                            AND CHANGEDT < TRUNC(SYSDATE) + 7 / 24
                                    ")
                                          .Select(e => new
                                          {
                                              Status = e.Status,
                                              TimeSpan = ((e.Enddate != null) ? ((e.Enddate > DateTime.Today.AddHours(7)) ? DateTime.Today.AddHours(7) : e.Enddate) : DateTime.Today.AddHours(7)) - ((e.Changedt != null) ? ((e.Changedt < DateTime.Today.AddDays(-1).AddHours(7)) ? DateTime.Today.AddDays(-1).AddHours(7) : e.Changedt) : DateTime.Today.AddDays(-1).AddHours(7)),
                                          })
                                          .ToList();


                            var EqpList = result.GroupBy(e => e.Status)
                                         .Select(e => new
                                         {
                                             Status = e.Key,
                                             TotalTimeSpan = e.Aggregate(TimeSpan.Zero, (total, item) => (TimeSpan)(total + item.TimeSpan))
                                         })
                                         .ToList()
                                         .OrderBy(e => e.Status)
                                         .Select(e => new
                                         {
                                             Status = e.Status,
                                             TotalTimeSpan = (e.TotalTimeSpan.TotalHours >= 24) ? "24:00:00" : e.TotalTimeSpan.ToString(@"hh\:mm\:ss"),
                                         })
                                         .ToList();

                            EmailBody += "<tr  bgcolor=white><td align=center width=8%><font size=2 face=Arial  color=black>" + i.Equipid + "</font></td>";
                            workbook.Cells[ForRef, 1].Value = i.Equipid;
                            int id = 1;
                            foreach (var sta in EqpList)
                            {
                                if (sta.Status == "WAITENG" || sta.Status == "04_MON_R" || sta.Status == "04_PM" || sta.Status == "06_TEST_CW" || sta.Status == "TEST" || sta.Status == "06_TEST" || sta.Status == "03_DOWN" || sta.Status == "02_IDLE" || sta.Status == "01_RUN" || sta.Status == "04_SETUP" || sta.Status == "03_SPCHOLD" || sta.Status == "04_MON_PM" || sta.Status == "02_WAIT")
                                {
                                    string Body = sta.Status.ToString();
                                    Console.WriteLine("Test: ");
                                    Console.WriteLine("Body: " + Body);
                                    // Body = Body.Substring(Body.IndexOf("=") + 1);
                                    Body = Body.Replace(" ", "").Replace("0", "").Replace("_", "").Replace("4", "").Replace("2", "").Replace("6", "").Replace("1", "").Replace("3", "");
                                    Console.WriteLine("Body: " + Body);
                                    if (sta.Status == "04_MON_PM") {
                                        Body = "MONP_M";
                                    }
                                    int tdid = EmailBody.IndexOf(Body);
                                    Console.WriteLine("tdid: " + tdid);
                                    if (tdid >= 0)
                                    {
                                        string BodyRe = EmailBody.Substring(tdid - 25, 2).Replace("=", "").Replace(" ", "");
                                        Console.WriteLine("BodyRe: " + BodyRe);
                                        int BodyId = int.Parse(BodyRe);
                                        Console.WriteLine("BodyId: " + BodyId);
                                        for (; id < BodyId; id++)
                                        {
                                            Console.WriteLine("id:" + id);
                                            EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                            EmailBody += "</font></td>";
                                        }
                                    }
                                    Console.WriteLine("Over:");
                                }
                                if (sta.Status != "WAITENG" && sta.Status != "04_MON_R" && sta.Status != "04_PM" && sta.Status != "06_TEST_CW" && sta.Status != "TEST" && sta.Status != "06_TEST" && sta.Status != "03_DOWN" && sta.Status != "02_IDLE" && sta.Status != "01_RUN" && sta.Status != "04_SETUP" && sta.Status != "03_SPCHOLD" && sta.Status != "04_MON_PM" && sta.Status != "02_WAIT")
                                {
                                    // 需要解构
                                    IEnumerator enumerator = EqpList.GetEnumerator();
                                    while (enumerator.MoveNext())
                                    {
                                        if (enumerator.Current == sta && enumerator.MoveNext())
                                        {
                                            var nextSta = enumerator.Current;
                                            foreach (var a in EqpList)
                                            {

                                                Console.WriteLine("suoyou元素: " + a);
                                            }
                                            Console.WriteLine("zheg元素: " + sta);
                                            Console.WriteLine("下一个元素: " + nextSta);
                                            // 凑格子
                                            string Body = nextSta.ToString();
                                            Console.WriteLine("Body: " + Body);
                                            Body = Body.Substring(Body.IndexOf("=") + 1);
                                            Body = Body.Substring(0, Body.IndexOf(",")).Replace(" ", "").Replace("0", "").Replace("_", "").Replace("4", "").Replace("2", "").Replace("6", "").Replace("1", "").Replace("3", "");
                                            Console.WriteLine("Body: " + Body);
                                            int tdid = EmailBody.IndexOf(Body);
                                            Console.WriteLine("tdid: " + tdid);
                                            if (tdid >= 0)
                                            {
                                                string BodyRe = EmailBody.Substring(tdid - 25, 2).Replace("=", "").Replace(" ", "");
                                                Console.WriteLine("BodyRe: " + BodyRe);
                                                int BodyId = int.Parse(BodyRe);
                                                Console.WriteLine("BodyId: " + BodyId);
                                                for (; id < BodyId; id++)
                                                {
                                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                                    EmailBody += "</font></td>";
                                                }
                                            }
                                            else
                                            {
                                                continue;
                                            }

                                            break;
                                        }
                                    }
                                    //函数　封装
                                    continue;
                                }

                                if (sta.Status == "01_RUN")
                                {
                                    workbook.Cells[ForRef, 2].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "02_IDLE")
                                {
                                    workbook.Cells[ForRef, 3].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "03_DOWN")
                                {
                                    workbook.Cells[ForRef, 4].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "03_SPCHOLD")
                                {
                                    workbook.Cells[ForRef, 11].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "04_PM")
                                {
                                    workbook.Cells[ForRef, 7].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "04_SETUP")
                                {
                                    workbook.Cells[ForRef, 10].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "04_MON_PM")
                                {
                                    workbook.Cells[ForRef, 8].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "04_MON_R")
                                {
                                    workbook.Cells[ForRef, 8].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "06_TEST_CW")
                                {
                                    workbook.Cells[ForRef, 6].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "TEST" || sta.Status == "06_TEST")
                                {
                                    workbook.Cells[ForRef, 5].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }
                                if (sta.Status == "WAITENG")
                                {
                                    workbook.Cells[ForRef, 9].Value = sta.TotalTimeSpan;
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += sta.TotalTimeSpan;
                                    EmailBody += "</font></td>";
                                    id++;
                                    continue;
                                }

                            }
                            for (; id < 18 && 0 != EqpList.Count(); id++)
                            {
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += "</font></td>";
                            }
                            var Length = EqpList.Count();
                            if (0 == EqpList.Count())
                            {
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += "</font></td>";
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += "</font></td>";
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                EmailBody += "</font></td>";
                                EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>24";
                                EmailBody += "</font></td>";
                                Length = 4;
                                for (; Length < 17; Length++)
                                {
                                    EmailBody += "<td align=center width=5%><font size=2 face=Arial color=black>";
                                    EmailBody += "</font></td>";
                                }
                            }
                            
                        }

                        EmailBody += "</tr>   ";
                        EmailBody += "</table><br><br>";
                        // 2 
                        // 第二张表 ！！！！
                        // second Table
                        DateTime week = DateTime.Now;
                        EmailBody += "<table border=1 cellspacing=1 cellpadding=1 bgcolor=black width=72%><tr bgcolor=SkyBlue><td align=center width=5%>EQP</td><td align=center width=5%>产能</td><td align=center width=5%>当前WIP</td><td align=center width=5%>月均产出</td>";
                        EmailBody += "<td align=center width=5%>周均产出</td><td align=center width=5%>月累计</td>";
                        for (int i = 1; i <= 7; i++)
                        {
                            EmailBody += "  <td align=center width=5%> " + week.AddDays(-i).Date.ToString("yyyy/MM/dd") + " </td>";
                        }
                        EmailBody += "</tr><tr  bgcolor=white>";
                        foreach (var i in eqp)
                        {

                            EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + i.Equipid + "</font></td>";
                            EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + "46" + "</font></td>";

                            using (Rxrept2Context rxrep2 = new Rxrept2Context())
                            {
                                DateTime NowDay = DateTime.Now;
                                DateTime firstDayOfMonth = new DateTime(NowDay.Year, NowDay.Month, 1);

                                DateTime MouthDay = DateTime.Now.AddDays(-31);

                                DateTime WeekDay = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + 1);


                                int diff = (7 + (NowDay.DayOfWeek - DayOfWeek.Monday)) % 7 + 1;
                                DateTime firstDayOfWeek = NowDay.AddDays(-1 * diff).Date;

                                var NowTrackIn = rxrep2.RepHistTots.Where(e => e.Trackintime.Date == NowDay.Date && e.Eqpid == i.Equipid).ToList().Sum(e => e.Curmainqty);
                                EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + NowTrackIn.ToString() + "</font></td>";


                                var MouthTrackIn = rxrep2.RepHistTots
                                                .Where(e => e.Trackouttime <= NowDay.Date.AddHours(7) && e.Trackouttime >= firstDayOfMonth.Date.AddHours(7) && e.Eqpid == i.Equipid)
                                                .Sum(e => e.Curmainqty);
                                var DayInMouth = (int)NowDay.Subtract(firstDayOfMonth).TotalDays + 1;
                                var MouthSum = (int)MouthTrackIn / DayInMouth;
                                EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + MouthSum.ToString() + "</font></td>";


                                var WeekTrackIn = rxrep2.RepHistTots
                                                 .Where(e => e.Trackouttime <= NowDay.Date.AddHours(7) && e.Trackouttime >= WeekDay.Date.AddDays(-1).AddHours(7) && e.Eqpid == i.Equipid)
                                                 .Sum(e => e.Curmainqty);
                                var DayInWeek = (int)NowDay.Subtract(firstDayOfWeek).TotalDays;
                                var WeekSum = (int)WeekTrackIn / DayInWeek;
                                EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + WeekSum.ToString() + "</font></td>";

                                EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + MouthTrackIn.ToString() + "</font></td>";

                                for (int Day = 1; Day <= 7; Day++)
                                {
                                    var InfoWeek = DateTime.Now.AddDays(-Day);
                                    // var InfoWeekTrackIn = rxrep2.RepHistTots.Where(e => e.Trackintime.Date==InfoWeek.Date && e.Eqpid == i.Equipid).ToList().Sum(e => e.Trackinmainqty);
                                    var InfoWeekTrackIn = rxrep2.RepHistTots.FromSqlInterpolated(//, tt.outdate  
                                                    $@"select distinct t.*, tt.custordernumber
                                                        from (select t1.*
                                                              from rep_hist_tot t1 
                                                              where t1.trackouttime >= trunc(to_date({InfoWeek.ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                                and t1.trackouttime < trunc(to_date({InfoWeek.AddDays(1).ToString("yyyy-MM-dd")}, 'yyyy/mm/dd')) + 7 / 24 
                                                              order by t1.trackouttime) t, rep_actl_h_all tt 
                                                        where 1 = 1 
                                                          and t.lotid = tt.lotid(+) 
                                                          and t.lotid not like 'T%' 
                                                          and t.eqpid={i.Equipid}"
                                                ).ToList().Sum(e => e.Curmainqty);
                                    EmailBody += "<td align=center width=8%><font size=2 face=Arial  color=black>" + InfoWeekTrackIn.ToString() + "</font></td>";
                                }




                                EmailBody += "</tr><tr bgcolor=white>   ";
                            }


                        }

                        EmailBody += "</table><br><br>";
                    }

                    //键合 


                }

            }



            return EmailBody;
        }


        static public String WaferStartEmailDbInserExcel( int ForRef ,string ExcelPath)
        {
            string EmailBody = "";
            FileInfo file = new FileInfo(ExcelPath);
            using (Rxrept2Context ctx = new Rxrept2Context())
            {
                var PcMonthList = ctx.Waferstartemailmounths.ToList();
                using (RxrepContext rxrep = new RxrepContext())
                {
                    DateTime nowDay = DateTime.Now;
                    DateTime firstDayOfMonth = new DateTime(nowDay.Year, nowDay.Month, 1);

                    var groupedPcMonthList = PcMonthList.GroupBy(i => i.Process);

                    using (OfficeOpenXml.ExcelPackage Excel = new OfficeOpenXml.ExcelPackage(file))
                    {

                        ExcelWorksheet sheet = Excel.Workbook.Worksheets["Sheet1"];
                        int BP_PCS = 0;
                        int BP_K_Layers = 0;
                        int WS_ACC_PLAN = 0;
                        int WS_ACC_PLAN_K = 0;
                        int MF_1_6_PCS = 0;
                        int MF_1_6_Klayers = 0;
                        int MF_1_6_PLAN = 0;
                        int MF_1_6_PLAN_K = 0;
                        decimal? Wip = 0;
                        decimal? Wip_K = 0;
                        decimal? NowWip = 0;
                        int Row = 4;
                        decimal? capacity = 0;
                        decimal WaferOut = 0;
                    foreach (var group in groupedPcMonthList)
                    {
                        var process = group.Key;
                        foreach (var i in group)
                        {
                                BP_PCS += i.Bppcs ;
                                BP_K_Layers += i.Bppcs * int.Parse(i.Stage);
                                WS_ACC_PLAN += i.Bpwsaccplan;
                                WS_ACC_PLAN_K += i.Bpwsaccplan * int.Parse(i.Stage);
                                MF_1_6_PCS += i.Mfpcs;
                                MF_1_6_Klayers += i.Mfpcs * int.Parse(i.Stage);
                                MF_1_6_PLAN += i.Wsaccplan;
                                MF_1_6_PLAN_K += i.Wsaccplan * int.Parse(i.Stage);

                                capacity += i.Cap;

                                var lotStartDates = rxrep.RptWaferStarts.FromSqlInterpolated($@"select * from rpt_wafer_start where PRODUCTNAME = {i.Product} ").ToList();
                            var WaferStart = lotStartDates.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) > DateTime.Parse(firstDayOfMonth.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);
                                Wip += WaferStart;
                                Wip_K += WaferStart * int.Parse(i.Stage);

                                NowWip += ctx.RepActlHs.Where(e => e.Partname == i.Product).Sum(e => e.Startmainqty);

                                //  在线利用率 等于 Wafer Out / 产能
                                var ONumber = rxrep.RptLotFinishes.FromSqlInterpolated($@"select * from RPT_LOT_FINISH where PRODUCTNAME = {i.Product}").ToList();
                                var HNumber = ctx.RepActlHs.FromSqlInterpolated($@"select * from rep_actl_h where PARTNAME = {i.Product} AND  STAGE='QA' AND STATE='HOLD' AND HOLDCODE='HRMM11'").ToList();

                                var HoldNumber = HNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Stateentrytime.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) > DateTime.Parse(firstDayOfMonth.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Curmainqty);
                                var OutNumber = ONumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) > DateTime.Parse(firstDayOfMonth.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qaoutqty);

                                WaferOut += (decimal)(HoldNumber + OutNumber);

                            }
                            EmailBody += "<tr bgcolor='white' align='center'><td ><font size=2 face=Arial color=black>" + process.ToString() + "</font></td>";
                            EmailBody += "<td ><font size=2 face=Arial color=black>代工</font></td>";
                            sheet.Cells[Row, 4].Value = BP_PCS;
                            EmailBody += "<td ><font size=2 face=Arial color=black>"+BP_PCS.ToString()+ "</font></td>";
                            sheet.Cells[Row, 5].Value = BP_K_Layers;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + BP_K_Layers.ToString() + "</font></td>";
                            sheet.Cells[Row, 6].Value = WS_ACC_PLAN;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + WS_ACC_PLAN.ToString() + "</font></td>";
                            sheet.Cells[Row, 7].Value = WS_ACC_PLAN_K;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + WS_ACC_PLAN_K.ToString() + "</font></td>";
                            sheet.Cells[Row, 8].Value = MF_1_6_PCS;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + MF_1_6_PCS.ToString() + "</font></td>";
                            sheet.Cells[Row, 9].Value = MF_1_6_Klayers;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + MF_1_6_Klayers.ToString() + "</font></td>";
                            sheet.Cells[Row, 10].Value = MF_1_6_PLAN;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + MF_1_6_PLAN.ToString() + "</font></td>";
                            sheet.Cells[Row, 11].Value = MF_1_6_PLAN_K;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + MF_1_6_PLAN_K.ToString() + "</font></td>";
                            sheet.Cells[Row, 12].Value = Wip;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + Wip.ToString() + "</font></td>";
                            sheet.Cells[Row, 13].Value = Wip_K;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + Wip_K.ToString() + "</font></td>";

                            sheet.Cells[Row, 14].Value = capacity;
                            EmailBody += "<td ><font size=2 face=Arial color=black>"+ capacity.ToString()+ "</font></td>";

                            sheet.Cells[Row, 15].Value = NowWip;
                            EmailBody += "<td ><font size=2 face=Arial color=black>" + NowWip.ToString() + "</font></td>";
                            double abc;
                            if (capacity == 0 ) { abc = ((int)(Math.Round((decimal)(WaferOut / 1), 5) * 100)); }
                            else {
                                 abc = ((int)(Math.Round((decimal)(WaferOut / capacity), 5) * 100)); }
                            sheet.Cells[Row, 16].Value = abc/100;
                            EmailBody += "<td ><font size=2 face=Arial color=black>"+ Math.Round( abc,2) + "%</font></td>";

                            string colo;
                            // 计算
                            if (Wip_K - WS_ACC_PLAN_K < 0 ) {
                                colo = "red";
                            }
                            else {
                                colo = "black";
                            }
                            EmailBody += "<td ><font size=2 face=Arial color=" + colo + ">" + (Wip_K- WS_ACC_PLAN_K).ToString() +"</font></td>";
                            if (Row == 4) {
                                EmailBody += "<td rowspan=4><font size=2 face=Arial color=black>BP达成率</font></td>";
                            }

                            if (Wip_K - MF_1_6_PLAN_K < 0)
                            {
                                colo = "red";
                            }
                            else
                            {
                                colo = "black";
                            }
                            EmailBody += "<td ><font size=2 face=Arial color=" + colo + ">" + (Wip_K - MF_1_6_PLAN_K).ToString() + "</font></td>";
                            if (Row == 4)
                            {
                                EmailBody += "<td rowspan=4><font size=2 face=Arial color=black>MF达成率</font></td>";
                            }

                            EmailBody += "</tr>";

                            BP_PCS = 0;
                             BP_K_Layers = 0;
                             WS_ACC_PLAN = 0;
                             WS_ACC_PLAN_K = 0;
                             MF_1_6_PCS = 0;
                             MF_1_6_Klayers = 0;
                             MF_1_6_PLAN = 0;
                             MF_1_6_PLAN_K = 0;
                             Wip = 0;
                             Wip_K = 0;
                            capacity = 0;
                            WaferOut = 0;
                            NowWip = 0;
                            Row++;
                        }
                        

                        Excel.Save();

                        EmailBody += "<tr bgcolor='white' align='center'><td ><font size=2 face=Arial color=black>" + sheet.Cells[Row, 2].Value + "</font></td>";
                        EmailBody += "<td ><font size=2 face=Arial color=black>代工</font></td>";
                        EmailBody += "<td ><font size=2 face=Arial color=black>" + ((int)sheet.Cells[Row-1,4].Value + (int)sheet.Cells[Row - 2, 4].Value+ (int)sheet.Cells[Row-3, 4].Value).ToString() + "</font></td>";
                        EmailBody += "<td ><font size=2 face=Arial color=black>" + ((int)sheet.Cells[Row - 1, 5].Value + (int)sheet.Cells[Row - 2, 5].Value + (int)sheet.Cells[Row - 3, 5].Value).ToString() + "</font></td>";
                        EmailBody += "<td ><font size=2 face=Arial color=black>" + ((int)sheet.Cells[Row - 1, 6].Value + (int)sheet.Cells[Row - 2, 6].Value + (int)sheet.Cells[Row - 3, 6].Value).ToString() + "</font></td>";
                        EmailBody += "<td ><font size=2 face=Arial color=black>" + ((int)sheet.Cells[Row - 1, 7].Value + (int)sheet.Cells[Row - 2, 7].Value + (int)sheet.Cells[Row - 3, 7].Value).ToString() + "</font></td>";

                        EmailBody += "<td ><font size=2 face=Arial color=black>" + ((int)sheet.Cells[Row - 1, 8].Value + (int)sheet.Cells[Row - 2, 8].Value + (int)sheet.Cells[Row - 3, 8].Value).ToString() + "</font></td>";
                        EmailBody += "<td ><font size=2 face=Arial color=black>" + ((int)sheet.Cells[Row - 1, 9].Value + (int)sheet.Cells[Row - 2, 9].Value + (int)sheet.Cells[Row - 3, 9].Value).ToString() + "</font></td>";
                        //EmailBody += "<td ><font size=2 face=Arial color=black>" + ((int)sheet.Cells[Row - 1, 10].Value + (int)sheet.Cells[Row - 2, 10].Value + (int)sheet.Cells[Row - 3, 10].Value).ToString() + "</font></td>";
                        //EmailBody += "<td ><font size=2 face=Arial color=black>" + ((int)sheet.Cells[Row - 1, 11].Value + (int)sheet.Cells[Row - 2, 11].Value + (int)sheet.Cells[Row - 3, 11].Value).ToString() + "</font></td>";

                        DateTime today = DateTime.Now;

                        int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

                        EmailBody += "<td ><font size=2 face=Arial color=black>" + (((int)sheet.Cells[Row - 1, 8].Value + (int)sheet.Cells[Row - 2, 8].Value + (int)sheet.Cells[Row - 3, 8].Value)*today.Day/daysInMonth).ToString() + "</font></td>";
                        EmailBody += "<td ><font size=2 face=Arial color=black>" + (((int)sheet.Cells[Row - 1, 9].Value + (int)sheet.Cells[Row - 2, 9].Value + (int)sheet.Cells[Row - 3, 9].Value)*today.Day/daysInMonth).ToString() + "</font></td>";



                        EmailBody += "<td ><font size=2 face=Arial color=black>" + (Convert.ToInt32(sheet.Cells[Row - 1, 12].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 12].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 12].Value)).ToString() + "</font></td>";
                        EmailBody += "<td ><font size=2 face=Arial color=black>" + (Convert.ToInt32(sheet.Cells[Row - 1, 13].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 13].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 13].Value)).ToString() + "</font></td>";
                          EmailBody += "<td ><font size=2 face=Arial color=black>"+ (Convert.ToInt32(sheet.Cells[Row - 1, 14].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 14].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 14].Value)).ToString() +"</font></td>";
                        EmailBody += "<td ><font size=2 face=Arial color=black>" + (Convert.ToInt32(sheet.Cells[Row - 1, 15].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 15].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 15].Value)).ToString() + "</font></td>";
                          EmailBody += "<td ><font size=2 face=Arial color=black>" +(Math.Round((Convert.ToDouble(sheet.Cells[Row - 1, 16].Value) + Convert.ToDouble(sheet.Cells[Row - 2, 16].Value) + Convert.ToDouble(sheet.Cells[Row - 3, 16].Value)),4)*100).ToString() + "%</font></td>";
                        string color;
                        // 计算
                        if ((Convert.ToInt32(sheet.Cells[Row - 1, 17].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 17].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 17].Value)) < 0)
                        {
                            color = "red";
                        }
                        else
                        {
                            color = "black";
                        }
                        EmailBody += "<td ><font size=2 face=Arial color=" + color + ">" + (Convert.ToInt32(sheet.Cells[Row - 1, 17].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 17].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 17].Value)).ToString() + "</font></td>";

                        if ((Convert.ToInt32(sheet.Cells[Row - 1, 19].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 19].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 19].Value)) < 0)
                        {
                            color = "red";
                        }
                        else
                        {
                            color = "black";
                        }
                        EmailBody += "<td ><font size=2 face=Arial color=" + color + ">" + (Convert.ToInt32(sheet.Cells[Row - 1, 19].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 19].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 19].Value)).ToString() + "</font></td>";

                        EmailBody += "</tr>";

                        if (Row == 7) {
                            double BP = ((Convert.ToInt32(sheet.Cells[Row - 1, 13].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 13].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 13].Value)) /(double)((int)sheet.Cells[Row - 1, 7].Value + (int)sheet.Cells[Row - 2, 7].Value + (int)sheet.Cells[Row - 3, 7].Value));
                            double MF = (((Convert.ToInt32(sheet.Cells[Row - 1, 13].Value) + Convert.ToInt32(sheet.Cells[Row - 2, 13].Value) + Convert.ToInt32(sheet.Cells[Row - 3, 13].Value)) /(double)(((int)sheet.Cells[Row - 1, 11].Value + (int)sheet.Cells[Row - 2, 11].Value + (int)sheet.Cells[Row - 3, 11].Value) * today.Day / daysInMonth)) ); //* today.Day / daysInMonth
                            BP = BP * 100 + 0.4;
                            MF = MF * 100 + 0.4;
                            int kq = (int)BP;
                            int wl = (int)MF; 
                            EmailBody = EmailBody.Replace("<td rowspan=4><font size=2 face=Arial color=black>BP达成率</font></td>", "<td rowspan=4><font size=2 face=Arial color=black>" +kq.ToString()+ "%" + "</font></td>");
                           EmailBody = EmailBody.Replace("<td rowspan=4><font size=2 face=Arial color=black>MF达成率</font></td>", "<td rowspan=4><font size=2 face=Arial color=black>" + wl.ToString()+ "%" + "</font></td>");
                        }
                    }
                  

                }
            }
            return EmailBody;
        }

        static public string OEEmailDbInsertExcelTableOne(ref ExcelWorksheet workbook , DateTime nowday) {
            string EmailBody = "";
            using (RxrepContext rxrep = new RxrepContext()) {
                string formattedDate = nowday.ToString("yyyyMMdd");
                var OEEList = rxrep.VOeeSumV2011s.Where(e => e.Pday == formattedDate).ToList();
                string DateForEmail = nowday.ToString("yyyy-MM-dd");
                EmailBody += "<tr bgcolor='white' align='center'><td align=center width=100><font size=2 face=Arial color=black>" + DateForEmail.ToString()+"</td> ";
                double TT = (double)OEEList.Select(e => e.Tt).Sum();
                double Avai = (double)OEEList.Select(e => e.Avai).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100*(Avai/TT),2) + "</td> ";
                double PHTT = (double)OEEList.Where(e=>e.Module== "PHOTO").Select(e => e.Tt).Sum();
                double PHAvai = (double)OEEList.Where(e => e.Module == "PHOTO").Select(e => e.Avai).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100 * (PHAvai / PHTT), 2) + "</td> ";
                double ETTT = (double)OEEList.Where(e => e.Module == "ETCH").Select(e => e.Tt).Sum();
                double ETAvai = (double)OEEList.Where(e => e.Module == "ETCH").Select(e => e.Avai).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100 * (ETAvai / ETTT), 2) + "</td> ";
                double TFTT = (double)OEEList.Where(e => e.Module == "THINF").Select(e => e.Tt).Sum();
                double TFAvai = (double)OEEList.Where(e => e.Module == "THINF").Select(e => e.Avai).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100 * (TFAvai / TFTT), 2) + "</td> ";
                double DFTT = (double)OEEList.Where(e => e.Module == "DIFF").Select(e => e.Tt).Sum();
                double DFAvai = (double)OEEList.Where(e => e.Module == "DIFF").Select(e => e.Avai).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100 * (DFAvai / DFTT), 2) + "</td> ";

                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round((Math.Round(100 * (PHAvai / PHTT), 2) + Math.Round(100 * (ETAvai / ETTT), 2) + Math.Round(100 * (TFAvai / TFTT), 2)+ Math.Round(100 * (DFAvai / DFTT), 2))/4 ,2)+ "</td> ";

                EmailBody += "</tr>";
            }

            return EmailBody;
        }

        static public string OEEmailDbInsertExcelTableTwo(ref ExcelWorksheet workbook, DateTime nowday)
        {
            string EmailBody = "";
            using (RxrepContext rxrep = new RxrepContext())
            {
                string formattedDate = nowday.ToString("yyyyMMdd");
                var OEEList = rxrep.VOeeSumV2011s.Where(e => e.Pday == formattedDate).ToList();
                string DateForEmail = nowday.ToString("yyyy-MM-dd");
                EmailBody += "<tr bgcolor='white' align='center'><td align=center width=100><font size=2 face=Arial color=black>" + DateForEmail.ToString() + "</td> ";
                // 2 
                double EFF = (double)OEEList.Select(e => e.Eff).Sum();
                double EFFRun = (double)OEEList.Select(e => e.Effrun).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100 * (EFF * 60 / EFFRun), 2) + "</td> ";
                double PHEFF = (double)OEEList.Where(e => e.Module == "PHOTO").Select(e => e.Eff).Sum();
                double PHEFFRun = (double)OEEList.Where(e => e.Module == "PHOTO").Select(e => e.Effrun).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100 * (PHEFF * 60 / PHEFFRun), 2) + "</td> ";
                double ETEFF = (double)OEEList.Where(e => e.Module == "ETCH").Select(e => e.Eff).Sum();
                double ETEFFRun = (double)OEEList.Where(e => e.Module == "ETCH").Select(e => e.Effrun).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100 * (ETEFF * 60 / ETEFFRun), 2) + "</td> ";
                double TFEFF = (double)OEEList.Where(e => e.Module == "THINF").Select(e => e.Eff).Sum();
                double TFEFFRun = (double)OEEList.Where(e => e.Module == "THINF").Select(e => e.Effrun).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100 * (TFEFF * 60 / TFEFFRun), 2) + "</td> ";
                double DFEFF = (double)OEEList.Where(e => e.Module == "DIFF").Select(e => e.Eff).Sum();
                double DFEFFRun = (double)OEEList.Where(e => e.Module == "DIFF").Select(e => e.Effrun).Sum();
                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round(100 * (DFEFF * 60 / DFEFFRun), 2) + "</td> ";

                EmailBody += "<td align=center width=100><font size=2 face=Arial color=black>" + Math.Round((Math.Round(100 * (TFEFF * 60 / TFEFFRun), 2) + Math.Round(100 * (PHEFF * 60 / PHEFFRun), 2) + Math.Round(100 * (ETEFF * 60 / ETEFFRun), 2) + Math.Round(100 * (DFEFF * 60 / DFEFFRun), 2)) / 4, 2) + "</td> ";


                EmailBody += "</tr>";

            }

            return EmailBody;
        }




    }
}
