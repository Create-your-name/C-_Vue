using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.DirectoryServices.Protocols;
using webapi.Bean.Rep;
using webapi.Entity.Rxrep;
using webapi.Models;
using static webapi.Bean.Rep.HoldTable;

namespace webapi.Controllers.Rep
{
    [Route("api/Rep")]
    public class HotLotController
    {
        [HttpGet("HotLot")]
        public List<HoldTable> GetHotLot()
        {
            List<HoldTable> fabLots = new List<HoldTable>();

            string[] tableNames = { "TD", "TF", "MFG", "EPI", "PID", "FMA", "MD", "DF", "ET", "PH", "QA" };


            foreach (string tableName in tableNames)
            {
                HoldTable holdTable = new HoldTable(tableName);
                fabLots.Add(holdTable);
            }

            using (RxrepContext ctx = new RxrepContext())
            {
                int falseNumber = -1;           //
                var a = ctx.VMfgHoldLastests.FromSqlInterpolated($@"select * from V_MFG_HOLD_LASTEST").Where(e => e.Priority != 9 && (falseNumber == e.Comm.IndexOf("外包") || e.Comm=="") && falseNumber == e.Commentcode.IndexOf("HR-MW100") && falseNumber==e.Comm.IndexOf("wb"))
                    .ToList();
                for (int g=0;g<fabLots.Count;g++) {
                    HoldTable i = fabLots[g];
                    foreach (var hold in a)
                    {

                        string sholdCode = hold.Commentcode.ToString();
                        if (hold.Holdreason == "FutureHold")
                        {
                            int n = hold.Holdcomment0.IndexOf(":HR") + 1;
                            sholdCode = hold.Holdreason0.Substring(n, 6);
                        }

                        if (i.Dept == "TD" )
                        {
                            i.Target_0 = "0.30%";
                            i.Target_12 = "0.15%";
                            i.Target_48 = "0.15%";
                            if (falseNumber != sholdCode.IndexOf("HRKU2P") || falseNumber != sholdCode.IndexOf("HR-W") ){
                                PostHoldTable(ref i, hold);
                            }

                        }
                        if (i.Dept == "TF"  )
                        {
                            i.Target_0 = "0.55%";
                            i.Target_12 = "0.20%";
                            i.Target_48 = "0.08%";
                            if (falseNumber != sholdCode.IndexOf("HRKU2L") || falseNumber != sholdCode.IndexOf("HR-T")|| falseNumber != sholdCode.IndexOf("HRT") || falseNumber != sholdCode.IndexOf("Hold By Pilot(F)"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                        if (i.Dept == "MFG" )
                        {
                            i.Target_0 = "4.60%";
                            i.Target_12 = "3.00%";
                            i.Target_48 = "2.30%";
                            if (falseNumber != sholdCode.IndexOf("Post") || (falseNumber != sholdCode.IndexOf("HR-F") && falseNumber == sholdCode.IndexOf("HR-FA1")  ) || falseNumber != sholdCode.IndexOf("HR-M"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                        if (i.Dept == "EPI" )
                        {
                            i.Target_0 = "0.20%";
                            i.Target_12 = "0.10%";
                            i.Target_48 = "0.05%";
                            if (falseNumber != sholdCode.IndexOf("HR-S"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                        if (i.Dept == "PID"  )
                        {
                            i.Target_0 = "0.80%";
                            i.Target_12 = "0.40%";
                            i.Target_48 = "0.60%";
                            if (falseNumber != sholdCode.IndexOf("HRKU2I") || falseNumber != sholdCode.IndexOf("HR-Y"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                        if (i.Dept == "FMA")
                        {
                            i.Target_0 = "0.10%";
                            i.Target_12 = "0.40%";
                            i.Target_48 = "0.30%";
                            if (falseNumber != sholdCode.IndexOf("HR-A"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                        if (i.Dept == "MD" )
                        {
                            i.Target_0 = "0.20%";
                            i.Target_12 = "0.10%";
                            i.Target_48 = "0.07%";
                            if (falseNumber != sholdCode.IndexOf("HRKU2M") || falseNumber != sholdCode.IndexOf("HR-N"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                        if (i.Dept == "DF" )
                        {
                            i.Target_0 = "0.55%";
                            i.Target_12 = "0.20%";
                            i.Target_48 = "0.15%";
                            if (falseNumber != sholdCode.IndexOf("HRKU2T") || falseNumber != sholdCode.IndexOf("HR-D"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                        if (i.Dept == "ET"  )
                        {
                            i.Target_0 = "0.20%";
                            i.Target_12 = "0.10%";
                            i.Target_48 = "0.05%";
                            if (falseNumber != sholdCode.IndexOf("HRKU2E") || falseNumber != sholdCode.IndexOf("HR-E"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                        if (i.Dept == "PH"  )
                        {
                            i.Target_0 = "0.20%";
                            i.Target_12 = "0.05%";
                            i.Target_48 = "0%";
                            if (falseNumber != sholdCode.IndexOf("HRKU2P") || falseNumber != sholdCode.IndexOf("HR-P"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                        if (i.Dept == "QA" )
                        {
                            i.Target_0 = "0.30%";
                            i.Target_12 = "0.10%";
                            i.Target_48 = "0%";
                            if (falseNumber != sholdCode.IndexOf("HR-Q"))
                            {
                                PostHoldTable(ref i, hold);
                            }
                        }
                    }

                }
                 
            }
            int wip = 0;
            using (Rxrept2Context ctx = new Rxrept2Context() ) {
                wip = ctx.RepActlHs.Count();
            }
                foreach (var i in fabLots) {
                if (i.TotalNum != 0)
                {
                    i.avg_Hold = (Math.Round(Convert.ToDouble(i.avg_Hold) / i.TotalNum, 2) ).ToString() ;
                }
                else {
                    i.avg_Hold = "0";
                }
              
                
                i.Hold_bl = (Math.Round((Convert.ToDouble(i.TotalNum) / wip)*100, 2)).ToString()+"%";
                i.Hold__12 = (Math.Round((Convert.ToDouble(i.number_12) / wip)*100, 2)).ToString()+"%";
                i.Hold__48 = (Math.Round((Convert.ToDouble(i.number_48) / wip)*100, 2)).ToString()+"%";
            }

            HoldTable hj = new HoldTable("合计");
            foreach (var i in fabLots) {
                hj.number_48 += i.number_48;
                hj.number_12 += i.number_12;
                hj.number_24 += i.number_24;
                hj.TotalNum = hj.TotalNum + i.TotalNum;
                hj.Total_HoldNumber = (Convert.ToDouble(hj.Total_HoldNumber.Replace("%", "")) + Convert.ToDouble(i.Total_HoldNumber.Replace("%", ""))).ToString() ;
                hj.Target_0 =  Math.Round((Convert.ToDouble(hj.Target_0.Replace("%", "")) + Convert.ToDouble(i.Target_0.Replace("%", ""))),2).ToString() +"%";
                hj.Target_12 = Math.Round((Convert.ToDouble(hj.Target_12.Replace("%", "")) + Convert.ToDouble(i.Target_12.Replace("%",""))),2).ToString() +"%";
                hj.Target_48 = Math.Round((Convert.ToDouble(hj.Target_48.Replace("%", "")) + Convert.ToDouble(i.Target_48.Replace("%", ""))),2).ToString() +"%";
              //  hj.avg_Hold =Math.Round((Convert.ToDouble(hj.avg_Hold.Replace("%", "")) + Convert.ToDouble(i.avg_Hold.Replace("%", ""))),2).ToString();
                hj.Hold__12 =Math.Round((Convert.ToDouble(hj.Hold__12.Replace("%", "")) + Convert.ToDouble(i.Hold__12.Replace("%", ""))),2).ToString()+"%";
                hj.Hold__48 =Math.Round((Convert.ToDouble(hj.Hold__48.Replace("%", "")) + Convert.ToDouble(i.Hold__48.Replace("%", ""))),2).ToString()+"%";
                hj.avg_Hold = Math.Round((Convert.ToDouble(hj.avg_Hold) + Convert.ToDouble(i.avg_Hold)),2).ToString();
                hj.Total_HoldTime = Math.Round((Convert.ToDouble(hj.Total_HoldTime) + Convert.ToDouble(i.Total_HoldTime)),2).ToString();
                hj.Hold_bl = Math.Round((Convert.ToDouble(hj.Hold_bl.Replace("%", "")) + Convert.ToDouble(i.Hold_bl.Replace("%", ""))),2).ToString()+"%";
                       
            }
            fabLots.Add(hj);
            return fabLots;
        }

         void PostHoldTable( ref  HoldTable holdInfo , VMfgHoldLastest hold) {

            DateTime now = DateTime.Now;
            TimeSpan interval = now.Subtract(hold.HoldDate);
            double TotalTime = interval.TotalHours;
            holdInfo.Total_HoldTime = (Math.Round(Convert.ToDouble(holdInfo.Total_HoldTime) + Math.Round(TotalTime, 2),2)).ToString();
            holdInfo.avg_Hold= (Math.Round(Convert.ToDouble(holdInfo.avg_Hold)+Math.Round(TotalTime, 2),2) ).ToString();  // 统一 处理
            holdInfo.TotalNum += (int)hold.Qty;
            if (TotalTime >48) {
                holdInfo.number_48 += (int)hold.Qty;
            }
            if (TotalTime > 24)
            {
                holdInfo.number_24 += (int)hold.Qty;
            }
            if (TotalTime > 12 )
            {
                holdInfo.number_12 += (int)hold.Qty;
            }
            
        }
    }
}