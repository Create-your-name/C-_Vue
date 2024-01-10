using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using webapi.Bean.FabRep;
using webapi.Model;
using webapi.Models;
using static webapi.Bean.Rep.FabLot;

namespace webapi.Controllers.OnlyOnceTable
{
    [Route("api/Spc")]
    [ApiController]
    public class ScrapController : Controller
    {
        private BeforeRep num;

        [HttpPost("ScrapLot")]

        public List<RptScrap> GetScrapLot()
        {
            List<RptScrap> result = new List<RptScrap>();
            using (RxrepContext rxrep = new RxrepContext() )  {
                result = rxrep.RptScraps.Where(e => e.Pstatus != "N").ToList();

                foreach (var i in result ) {
                    using (RxmesContext rxmes =  new RxmesContext () ) {
                        i.Userid = rxmes.Fwuserprofiles.Where(e => e.Username == i.Userid).Select(e => e.Nickname).FirstOrDefault();
                    }   
                }

            }

            return result;
        }

        [HttpPost("FormTimeLot")]

        public List<RptScrap> GetTimeScrapLot([FromBody] DateTimeInfo timeInfo)
        {
            List<RptScrap> result = new List<RptScrap>();
            using (RxrepContext rxrep = new RxrepContext())
            {
                result = rxrep.RptScraps.FromSqlInterpolated(//, tt.outdate  
                        $@"SELECT * 
                                        FROM rpt_scrap t1 
                                        WHERE t1.pstatus != 'N' 
                                          AND TO_TIMESTAMP(t1.scrapdate, 'YYYYMMDD HH24MISSFF3') > {DateTime.Parse(timeInfo.activityBeginTime)}
                                   AND TO_TIMESTAMP(t1.scrapdate, 'YYYYMMDD HH24MISSFF3') < {DateTime.Parse(timeInfo.activityEndTime)}    ;
                                                             "
                      ).ToList();

                foreach (var i in result)
                {
          /*          Console.WriteLine(DateTime.ParseExact(i.Scrapdate, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).GetType());
                    Console.WriteLine(DateTime.Parse(timeInfo.activityBeginTime).GetType());*/
                    using (RxmesContext rxmes = new RxmesContext())
                    {
                        i.Userid = rxmes.Fwuserprofiles.Where(e => e.Username == i.Userid).Select(e => e.Nickname).FirstOrDefault();
                    }
                }

            }

            return result;
        }
    }
}
