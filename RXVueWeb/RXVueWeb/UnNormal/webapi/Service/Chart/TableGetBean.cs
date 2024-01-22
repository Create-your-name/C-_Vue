using System.Globalization;
using webapi.Bean.Rep;
using webapi.Entity;
using webapi.Entity.Rxrep;
using webapi.Models;

namespace webapi.Service.Chart
{
    public class TableGetBean
    {
        public static List<EngBean> GetBean(List<EngBean> result, List<RepActl15min> resultRep)
        {
            DateTime Now = DateTime.Now;
            using (RxrepContext rxrep = new RxrepContext())
            {
                using (Rxrept2Context rxrep2 = new Rxrept2Context())
                {
                    foreach (var item in resultRep)
                    {
                        EngBean OneLot = new EngBean();
                        OneLot.Lotid = item.Lotid;
                        OneLot.Product = item.Partname;
                        OneLot.Number =(int)item.Startmainqty;
                        OneLot.Location = item.Location;
                        OneLot.Repstage = item.Repstage;
                        OneLot.Capagroup = item.CapaGroup;
                        OneLot.Repname = item.Recpname;
                        OneLot.stepNumber = item.Flowstep.ToString();
                        OneLot.state = item.State;
                        TimeSpan timeDifference = (TimeSpan)(Now - item.Stateentrytime);
                        decimal waitTimeInHours = (decimal)timeDifference.TotalHours;
                        string waitTimeAsString = waitTimeInHours.ToString("0.00");
                        OneLot.WaitTime = waitTimeAsString;
                        //round(((sysdate-t1.stateentrytime)*24),2)
                        OneLot.Hold = item.Holdcode;
                        var nextStep = rxrep.RptWipRxgzs.Where(e => e.Lotid == item.Lotid).Select(e => e.Nstepname);
                        OneLot.NextStep = nextStep.FirstOrDefault();
                        var nextRep = rxrep.RptWipRxgzs.Where(e => e.Lotid == item.Lotid).Select(e => e.Nstepdesc);
                        OneLot.NextRep = nextRep.FirstOrDefault();
                        OneLot.foretime = item.Foretime.ToString();
                        var move = rxrep.RptWipRxgzs.Where(e => e.Lotid == item.Lotid).Select(e => e.TodayMoves);
                        OneLot.HMoveold = move.FirstOrDefault().ToString();
                        //   OneLot.Runtime =
                        OneLot.Privaite = item.Newpriority.ToString();
                        OneLot.Dingdantime = item.Outdate.ToString();
                        TimeSpan thisGpa = ((TimeSpan)((item.Outdate==null?Now:item.Outdate) - (item.Foretime==null?Now:item.Foretime)));
                        double gap = Math.Round(thisGpa.TotalHours, 2);
                        OneLot.Gap = gap.ToString();
                        var foreTheoctDay = rxrep2.RepChangepriTmps.Where(e => e.Lotid == item.Lotid).Select(e => e.TotTheoct - e.NowTheoct);
                        OneLot.fore_theoct = foreTheoctDay.FirstOrDefault().ToString();
                        OneLot.Owner = item.Engineer;
                        OneLot.process = item.Process;
                        OneLot.ProcessType = item.Processtype;
                        //OneLot.BEFLAG=
                        OneLot.starttime = item.Starttime.ToString();
                        TimeSpan stateTTime = (TimeSpan)(Now - item.Stateentrytime);
                        decimal NowStateTime = (decimal)stateTTime.TotalHours;
                        OneLot.statetime = NowStateTime.ToString("0.00");

                        var LotDesc = rxrep2.SpllotDescs.Where(e => e.Lotid == item.Lotid).ToList();
                        if (LotDesc.Count==0) {
                            OneLot.Department = "未填写数据";
                            OneLot.RequestTime = "未填写数据";
                            OneLot.aim = "未填写数据";
                        }
                        else { 
                        OneLot.Department = LotDesc.FirstOrDefault().Department;
                        OneLot.RequestTime = LotDesc.FirstOrDefault().Dotime;
                        OneLot.aim = LotDesc.FirstOrDefault().Userdesc;
                    }


                        result.Add(OneLot);


                    }
                }
            }
            return result;
        }

        public static List<EngBean> WaferStartBean(List<EngBean> result, List<RptWaferStart> resultRep)
        {
            DateTime Now = DateTime.Now;
            using (RxrepContext rxrep = new RxrepContext())
            {
                using (Rxrept2Context rxrep2 = new Rxrept2Context())
                {
                    foreach (var item in resultRep)
                    {
                        var nowLot = rxrep2.RepActl15mins.Where(e => e.Lotid == item.Appid).ToList(); 
                        EngBean OneLot = new EngBean();
                        OneLot.Lotid = item.Appid;
                        OneLot.Product = item.Productname;
                        OneLot.Number =(int) item.Startqty;
                        if (nowLot.Count!=0) {
                            OneLot.Location = nowLot[0].Location;
                            OneLot.Repstage = nowLot[0].Repstage;
                            OneLot.Capagroup = nowLot[0].CapaGroup;
                            OneLot.Repname = nowLot[0].Recpname;
                            OneLot.stepNumber = nowLot[0].Flowstep.ToString();
                            OneLot.Hold = nowLot[0].Holdcode;
                            OneLot.foretime = nowLot[0].Foretime.ToString();
                            OneLot.Privaite = nowLot[0].Newpriority.ToString();
                            OneLot.Dingdantime = nowLot[0].Outdate.ToString();
                            TimeSpan thisGpa = ((TimeSpan)((nowLot[0].Outdate == null ? Now : nowLot[0].Outdate) - (nowLot[0].Foretime == null ? Now : nowLot[0].Foretime)));
                            double gap = Math.Round(thisGpa.TotalHours, 2);
                            OneLot.Gap = gap.ToString();
                            OneLot.Owner = nowLot[0].Engineer;
                            TimeSpan stateTTime = (TimeSpan)(Now - nowLot[0].Stateentrytime);
                            decimal NowStateTime = (decimal)stateTTime.TotalHours;
                            OneLot.statetime = NowStateTime.ToString("0.00");
                            TimeSpan timeDifference = (TimeSpan)(Now - nowLot[0].Stateentrytime);
                            decimal waitTimeInHours = (decimal)timeDifference.TotalHours;
                            string waitTimeAsString = waitTimeInHours.ToString("0.00");
                            OneLot.WaitTime = waitTimeAsString;

                        }

                        OneLot.state = item.Lottype;
                        var nextStep = rxrep.RptWipRxgzs.Where(e => e.Lotid == item.Appid).Select(e => e.Nstepname);
                        OneLot.NextStep = nextStep.FirstOrDefault();
                        var nextRep = rxrep.RptWipRxgzs.Where(e => e.Lotid == item.Appid).Select(e => e.Nstepdesc);
                        OneLot.NextRep = nextRep.FirstOrDefault();
                        var move = rxrep.RptWipRxgzs.Where(e => e.Lotid == item.Appid).Select(e => e.TodayMoves);
                        OneLot.HMoveold = move.FirstOrDefault().ToString();
                        //OneLot.Runtime =
                        var foreTheoctDay = rxrep2.RepChangepriTmps.Where(e => e.Lotid == item.Appid).Select(e => e.TotTheoct - e.NowTheoct);
                        OneLot.fore_theoct = foreTheoctDay.FirstOrDefault().ToString();
                        OneLot.process = item.Planname;
                        OneLot.ProcessType = item.Processtype;
                        //OneLot.BEFLAG=
                        OneLot.starttime = item.Lotcreatedate.ToString();
                        result.Add(OneLot);


                    }
                }
            }
            return result;
        }

        public static List<EngBean> WaferOutBean(List<EngBean> result, List<RptLotFinish> resultRep)
        {
            DateTime Now = DateTime.Now;
            using (RxrepContext rxrep = new RxrepContext())
            {
                using (Rxrept2Context rxrep2 = new Rxrept2Context())
                {
                    foreach (var item in resultRep)
                    {
                        EngBean OneLot = new EngBean();
                        OneLot.Lotid = item.Lotid;
                        OneLot.Product = item.Productname;
                        OneLot.Number = (int)item.Qaoutqty;
                        OneLot.WaitTime = item.Totwaittime.ToString();
                        OneLot.Hold = item.Totholdtime.ToString();
                        OneLot.NextStep = item.Totruntime.ToString();   // Run 时间
                        OneLot.NextRep = item.Planname; // 工艺大类
                        OneLot.foretime = item.Qaouttime; // 出Qa时间
                        OneLot.HMoveold = item.Lottype; // 工艺类型
                        OneLot.Runtime = item.Priority.ToString(); // 优先级
                        OneLot.Privaite = item.Layerno.ToString(); //光刻层数
                        OneLot.Dingdantime = item.Wono; // 工单号
                        OneLot.Gap = item.Lotstartdate; //开始时间
                        OneLot.fore_theoct = item.Ttstepcnt.ToString(); //总步数
                        OneLot.aim = item.Lotowner; // 所属人
                        result.Add(OneLot);


                    }
                }
            }
            return result;
        }
    }
}
