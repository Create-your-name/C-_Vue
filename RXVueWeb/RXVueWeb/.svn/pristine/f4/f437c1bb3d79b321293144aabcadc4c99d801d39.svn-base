using Aspose.Email.Storage.Pst;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Globalization;
using webapi.Bean;
using webapi.Bean.Rep;
using webapi.Entity.Rxmes;
using webapi.Entity.Rxrep;
using webapi.Entity.Rxrep2;
using webapi.Models;
using webapi.Service.WipMove;
using static webapi.Bean.Rep.FabLot;

namespace webapi.Controllers.Rep
{
    [Route("api/Rep")]
    public class WipMoveController : Controller
    {
        [HttpGet("WipMove")] // 首页
        public List<WipMoveBean> GetWipMove()
        {
            List<WipMoveBean> wipMoves = new List<WipMoveBean> { };
            using (Rxrept2Context ctx =new Rxrept2Context ()) {
                var result = ctx.RepActlHs
                    .OrderBy(e=>e.Curprcdcurinstnum)
            //        .Join(ctx.BCapagroupMaps, a => a.Recpname, b => b.Recpname, (a, b) => new { A = a, B = b })
                    .GroupBy(e => new { e.State, e.Recpname, e.Flag , e.Curprcdcurinstnum , e.Partname})
                    .Select(g => new WipRepBean
                    {
                        PRODUCT=g.Key.Partname,
                        State = g.Key.State,
                        RecpName = g.Key.Recpname,
                        Flag = g.Key.Flag,
                        StepCode=g.Key.Curprcdcurinstnum,
                        Sum = g.Sum(e => e.Curmainqty)
                    })
                    .ToList();
                StageWip resultList = new StageWip();
                wipMoves= StageWip.GetList(result);
            }

                return wipMoves;
        }

        [HttpGet("GetPro")] // select 
        public List<RepActlH> GetPro()
        {
            List<RepActlH> Pro = new List<RepActlH> { };
            using (Rxrept2Context ctx = new Rxrept2Context())
            {
               Pro = ctx.RepActlHs.ToList();
            }
            return Pro;
        }

        [HttpPost("PostPro")] //  inser to select 
        public List<WipMoveBean> PostPro([FromBody] StageWipDate date)
        {
            List<WipMoveBean> wipMoves = new List<WipMoveBean> { };
            using (RxmesContext ctx = new RxmesContext())
            {
                Console.WriteLine("jin");
                if (date.Process == "" && date.Product == "") {
                    return GetWipMove();
                }
                else if (date.Process != "" && date.Product=="")
                {
                    var ProcessResult = ctx.CustProductSettings.Where(e => e.Processtype == date.Process).Select(e => new { e.Product, e.Processcode }).ToList();
                    List<FwProcessSpec> ProcessStep = new List<FwProcessSpec>();
                    foreach (var i in ProcessResult)
                    {
                        string sql2 = "SELECT C.* FROM FW_PROCESS_SPEC C ,(SELECT NAME,ACTIVEVERSION FROM FWPROCESSPLAN WHERE SYSID = ((SELECT B.TOID FROM FWPRODUCTVERSION_N2M B WHERE FROMID = (SELECT C.SYSID FROM FWPRODUCTVERSION C WHERE PRODUCTNAME = '" + i.Product + "') AND B.LINKNAME = 'processes')))D WHERE C.PROCESS = D.NAME AND C.PROCESSVER = D.ACTIVEVERSION ORDER BY C.STEPSEQ ASC";
                        var wat = ctx.FwProcessSpecs.FromSqlRaw(sql2);
                        ProcessStep.AddRange(wat);
                    }
                    List<WipRepBean> ProcessStepResult = ProcessStep.OrderBy(e => e.Stepseq)
                     .GroupBy(e => new { e.Stepseq, e.Step, e.Stepdescription, e.PROCESS })
                     .Select(g => new WipRepBean
                     {
                         PRODUCT = g.Key.PROCESS,
                         StepCode = g.Key.Stepseq,
                         RecpName = g.Key.Step,
                         Flag = g.Key.Stepdescription
                     }).Distinct().ToList();

                    var Product = ctx.CustProductSettings.ToList();

                    ProcessStepResult = (from p in ProcessStepResult
                                         join pr in Product on p.PRODUCT equals pr.Processcode
                                         select new WipRepBean
                                         {
                                             PRODUCT = pr.Product,
                                             StepCode = p.StepCode,
                                             RecpName = p.RecpName,
                                             Flag = p.Flag
                                         }).ToList();


                    Console.WriteLine("获取所有 非重复的 step 后");
                    ProcessStep.Clear();

                    //move
                    List<WipRepBean> moveresult = new List<WipRepBean>();
                    using (RxrepContext ctx2 =new RxrepContext()) {
                        //var a = DateTime.Parse(DateTime.ParseExact("20230919 030034000", "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd "));
                        //var b = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));
                        //bool c = a == b;
                        List<RptWipTrackout> moveLi = new List<RptWipTrackout>();
                        foreach (var i in ProcessResult) {
                            moveLi.AddRange(ctx2.RptWipTrackouts.ToList()
                                 .Where(e => DateTime.Parse(DateTime.ParseExact(e.Trackouttime, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse((DateTime.Now.AddDays(-1)).ToString("yyyy/MM/dd")))
                                 .Where(e=>e.Productname==i.Product).OrderBy(e => e.Stepseq).ToList());
                        }
                      

                         moveresult = moveLi
                            .GroupBy( e=> new { e.Stepname, e.Stepseq ,e.Productname,e.Planname,e.Stage,e.Stepdescription})
                            .Select(g => new WipRepBean { 
                                PRODUCT = g.Key.Productname,
                                State=g.Key.Stage,
                                RecpName=g.Key.Stepname,
                                Flag=g.Key.Stepdescription,
                                StepCode=g.Key.Stepseq,
                                Sum=g.Sum(e=>e.Trackoutqty)
                            })
                            .ToList();
                        moveLi.Clear();
                      //  Console.WriteLine("moveresult");
                    }
                    // wip
                    List<WipRepBean> wipresult = new List<WipRepBean>();
                    using (Rxrept2Context ctx3 = new Rxrept2Context())
                    {
                        List<RepActlH> WipLi = new List<RepActlH>();
                        foreach (var i in ProcessResult)
                        {
                            WipLi.AddRange(ctx3.RepActlHs.ToList()
                          //       .Where(e => DateTime.Parse(DateTime.ParseExact(e.Trackouttime, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse((DateTime.Now.AddDays(-1)).ToString("yyyy/MM/dd")))
                                 .Where(e => e.Partname == i.Product).OrderBy(e => e.Curprcdcurinstnum).ToList());
                        }


                        wipresult = WipLi
                            .GroupBy(e => new { e.State, e.Recpname, e.Flag, e.Curprcdcurinstnum, e.Partname })
                            .Select(g => new WipRepBean
                            {
                                PRODUCT = g.Key.Partname,
                                State = g.Key.State,
                                RecpName = g.Key.Recpname,
                                Flag = g.Key.Flag,
                                StepCode = g.Key.Curprcdcurinstnum,
                                Sum = g.Sum(e => e.Curmainqty)
                            })
                            .OrderBy(e => e.StepCode)
                            .ToList();
                         WipLi.Clear();
                        //  Console.WriteLine("WipResult");
                    }
                    // 开始 
                    Console.WriteLine("开始");
                    StageWip resultList = new StageWip();
                    wipMoves = StageWip.MoveWipList(ProcessStepResult, moveresult, wipresult);
                    Console.WriteLine("未来可期");

                }
                else if (date.Product != "")
                {
                    List<FwProcessSpec> ProcessStep = new List<FwProcessSpec>();
                        string sql2 = "SELECT C.* FROM FW_PROCESS_SPEC C ,(SELECT NAME,ACTIVEVERSION FROM FWPROCESSPLAN WHERE SYSID = ((SELECT B.TOID FROM FWPRODUCTVERSION_N2M B WHERE FROMID = (SELECT C.SYSID FROM FWPRODUCTVERSION C WHERE PRODUCTNAME = '" + date.Product + "') AND B.LINKNAME = 'processes')))D WHERE C.PROCESS = D.NAME AND C.PROCESSVER = D.ACTIVEVERSION ORDER BY C.STEPSEQ ASC";
                        var wat = ctx.FwProcessSpecs.FromSqlRaw(sql2);
                        ProcessStep.AddRange(wat);
                    List<WipRepBean> ProcessStepResult = ProcessStep.OrderBy(e => e.Stepseq)
                     .GroupBy(e => new { e.Stepseq, e.Step, e.Stepdescription, e.PROCESS })
                     .Select(g => new WipRepBean
                     {
                         PRODUCT = g.Key.PROCESS,
                         StepCode = g.Key.Stepseq,
                         RecpName = g.Key.Step,
                         Flag = g.Key.Stepdescription
                     }).Distinct().ToList();

                    var Product = ctx.CustProductSettings.ToList();

                    ProcessStepResult = (from p in ProcessStepResult
                                         join pr in Product on p.PRODUCT equals pr.Processcode
                                         select new WipRepBean
                                         {
                                             PRODUCT = pr.Product,
                                             StepCode = p.StepCode,
                                             RecpName = p.RecpName,
                                             Flag = p.Flag
                                         }).ToList();


                    Console.WriteLine("获取所有 非重复的 step 后");
                    ProcessStep.Clear();

                    //move
                    List<WipRepBean> moveresult = new List<WipRepBean>();
                    using (RxrepContext ctx2 = new RxrepContext())
                    {
                        //var a = DateTime.Parse(DateTime.ParseExact("20230919 030034000", "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd "));
                        //var b = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));
                        //bool c = a == b;
                        List<RptWipTrackout> moveLi = new List<RptWipTrackout>();
                            moveLi.AddRange(ctx2.RptWipTrackouts.ToList()
                                 .Where(e => DateTime.Parse(DateTime.ParseExact(e.Trackouttime, "yyyyMMdd HHmmssfff", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd ")) == DateTime.Parse((DateTime.Now.AddDays(-1)).ToString("yyyy/MM/dd")))
                                 .Where(e => e.Productname == date.Product ).OrderBy(e => e.Stepseq).ToList());


                        moveresult = moveLi
                           .GroupBy(e => new { e.Stepname, e.Stepseq, e.Productname, e.Planname, e.Stage, e.Stepdescription })
                           .Select(g => new WipRepBean
                           {
                               PRODUCT = g.Key.Productname,
                               State = g.Key.Stage,
                               RecpName = g.Key.Stepname,
                               Flag = g.Key.Stepdescription,
                               StepCode = g.Key.Stepseq,
                               Sum = g.Sum(e => e.Trackoutqty)
                           })
                           .ToList();
                        moveLi.Clear();
                        //  Console.WriteLine("moveresult");
                    }
                    // wip
                    List<WipRepBean> wipresult = new List<WipRepBean>();
                    using (Rxrept2Context ctx3 = new Rxrept2Context())
                    {
                        List<RepActlH> WipLi = new List<RepActlH>();
                            WipLi.AddRange(ctx3.RepActlHs.ToList()
                                .Where(e => e.Partname == date.Product).OrderBy(e => e.Curprcdcurinstnum).ToList());


                        wipresult = WipLi
                            .GroupBy(e => new { e.State, e.Recpname, e.Flag, e.Curprcdcurinstnum, e.Partname })
                            .Select(g => new WipRepBean
                            {
                                PRODUCT = g.Key.Partname,
                                State = g.Key.State,
                                RecpName = g.Key.Recpname,
                                Flag = g.Key.Flag,
                                StepCode = g.Key.Curprcdcurinstnum,
                                Sum = g.Sum(e => e.Curmainqty)
                            })
                            .OrderBy(e => e.StepCode)
                            .ToList();
                        WipLi.Clear();
                        //  Console.WriteLine("WipResult");
                    }
                    // 开始 
                    Console.WriteLine("开始");
                    StageWip resultList = new StageWip();
                    wipMoves = StageWip.MoveWipList(ProcessStepResult, moveresult, wipresult);
                    Console.WriteLine("未来可期");
                }
            }

            return wipMoves;
        }

    }
}
