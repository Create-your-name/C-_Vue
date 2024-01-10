using NPOI.OpenXmlFormats.Spreadsheet;
using System.Globalization;
using webapi.Bean.Chart;

namespace webapi.Service.Chart
{
    public class NetRowChart
    {
        public static List<ChartFrom> Row(List<ChartFrom> result , List<Entity.Rxrep.RptWaferStart> start , List<Entity.Rxrep.RptLotFinish> WaferOut ,List<DateTime> monthsInYear , List<DateTime> dayInMonth , string  name , List<int> myList  , List<int> myList2)
        {
            var QtData = dayInMonth.Select(day =>
            {
                var EveNumber = start.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);
                return new
                {
                    EveNumber = EveNumber,
                };
            }).ToList();

            var QtDayAve = monthsInYear.Select(month =>
            {
                var start2 = start.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);

                var dayInMonth = DateTime.DaysInMonth(month.Date.Year, month.Date.Month);
                return new
                {
                    EveMNumber = Math.Round((double)((start2) / dayInMonth), 2),
                };
            }).ToList();

            string EveTitle = "其他";
            double[] GG = QtData.Select(x => x.EveNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
            GG = GG.Concat(myList2.Select(e => ((uint)e)).Select(Convert.ToDouble)).ToArray();
            GG = GG.Concat(QtDayAve.Select(e => e.EveMNumber).Select(Convert.ToDouble)).ToArray();
            ChartFrom EveChart = new ChartFrom(EveTitle, GG);
            result.Add(EveChart);


            var EveMonth = monthsInYear.Select(month =>
            {
                var EveNumber = start.Where(e => DateTime.Parse(DateTime.ParseExact(e.Lotstartdate.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);
                return new
                {
                    EveMNumber = EveNumber,
                };
            }).ToList();

            string EveMonthTitle = "其他";
            double[] EveMnumber = EveMonth.Select(x => x.EveMNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
            //   Mnumber = Mnumber.Concat(GsMonthAve.Select(e=>e.GsMNumber.GetValueOrDefault()).Select(Convert.ToInt32)).ToArray();
            ChartFrom QtEve = new ChartFrom(EveMonthTitle, EveMnumber);
            result.Add(QtEve);

            // Wafer Out

            // 每月计算  o->Out
            var QtoData = dayInMonth.Select(day =>
            {
                //   var gsHNumber = GsHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                var start = WaferOut.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse(day.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Startqty);
                return new
                {
                    //   GsNumber = gsNumber + gsHNumber,
                    EveNumber = start
                };
            }).ToList();

            var QTMonthAve = monthsInYear.Select(month =>
            {
                //     var gsHNumber = GsHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                var QsNumber = WaferOut.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);
   /*             if (month.Date.ToString("yyyy/MM/dd") == "2023/08/01")
                {
                    //    meiHNumber = 0;
                    gsNumber += 2;
                }*/


                var dayInMonth = DateTime.DaysInMonth(month.Date.Year, month.Date.Month);
                return new
                {
                    //    GsMNumber = Math.Round((double)((gsNumber + gsHNumber) / dayInMonth), 2),
                    EveMNumber = Math.Round((double)((QsNumber) / dayInMonth), 2),


                };
            }).ToList();

            string QtOut = "其他";
            double[] QtNum = QtoData.Select(x => x.EveNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
            QtNum = QtNum.Concat(myList.Select(e => ((uint)e)).Select(Convert.ToDouble)).ToArray();
            QtNum = QtNum.Concat(QTMonthAve.Select(e => e.EveMNumber).Select(Convert.ToDouble)).ToArray();
            ChartFrom Evet = new ChartFrom(QtOut, QtNum);
            result.Add(Evet);

            var QtOMonthP = monthsInYear.Select(month =>
            {
                //      var gsHNumber = GsHNumber.Where(e => DateTime.Parse(DateTime.ParseExact(e.HoldDate.ToString().AsSpan(), "yyyy/M/d H:m:s", CultureInfo.InvariantCulture).ToString("yyyy/MM/01 ")) == DateTime.Parse(month.Date.ToString("yyyy/MM/dd"))).Sum(e => e.Qty);
                var QeVeNumber = WaferOut.Where(e => DateTime.Parse(DateTime.ParseExact(e.Qaouttime.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture).ToString("yyyy/MM ")) == DateTime.Parse(month.Date.ToString("yyyy/MM"))).Sum(e => e.Startqty);
          /*      if (month.Date.ToString("yyyy/MM/dd") == "2023/08/01")
                {
                    //    meiHNumber = 0;
                    gsNumber += 2;
                }*/

                return new
                {
                    EveMNumber = QeVeNumber
                };
            }).ToList();


            string QMonth = "其他";
            double[] QtMnumber = QtOMonthP.Select(x => x.EveMNumber.GetValueOrDefault()).Select(Convert.ToDouble).ToArray();
            ChartFrom QtMchart = new ChartFrom(QMonth, QtMnumber);
            result.Add(QtMchart);

            return result;
        }
    }
}
