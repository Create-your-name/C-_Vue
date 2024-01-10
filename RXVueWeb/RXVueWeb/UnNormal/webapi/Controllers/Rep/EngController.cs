using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Bean.Rep;
using webapi.Model;
using webapi.Models;

namespace webapi.Controllers.Rep
{

    [Route("api/Spc")]
    [ApiController]
    public class EngController : Controller
    {
        [HttpPost("Table/ScrapLot")]

        public void GetScrapLot()
        {
            using (Rxrept2Context rxrep2 = new Rxrept2Context())
            {
                using (RxrepContext rxrep = new RxrepContext()) { 
                    List<EngBean> result = new List<EngBean>();
                // 工程或量产
                   var resultRep = rxrep2.RepActl15mins.Where(e=> e.Lotid.Contains("E")).ToList();
                    DateTime Now = DateTime.Now;
                    foreach (var item in resultRep) {
                        EngBean OneLot = new EngBean();
                        OneLot.Lotid = item.Lotid;
                        OneLot.Product = item.Partname;
                        OneLot.Number =item.Startmainqty.ToString();
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
                        var Next = rxrep.RptLotFinishes
                        OneLot.NextStep = 
                    }


                    Console.WriteLine("abcd");

                }

            }
        }
    }
}
