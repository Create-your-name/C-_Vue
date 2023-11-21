using System;
using System.Collections.Generic;

namespace webapi.Entity.Rxrep;

public partial class RptLotFinish
{
    public string Lotid { get; set; } = null!;

    public decimal? Invqty { get; set; }

    public string? Invdate { get; set; }

    public string? Productname { get; set; }

    public string? Productrevision { get; set; }

    public string? Planname { get; set; }

    public string? Planrevision { get; set; }

    public string? Qaouttime { get; set; }

    public decimal? Qaoutqty { get; set; }

    public decimal? Startqty { get; set; }

    public string? Lottype { get; set; }

    public string? Duedate { get; set; }

    public decimal? Priority { get; set; }

    public string? Platform { get; set; }

    public decimal? Layerno { get; set; }

    public string? Custid { get; set; }

    public string? Custprod { get; set; }

    public string? Wono { get; set; }

    public string? Lotstartdate { get; set; }

    public string? Beflag { get; set; }

    public string? Abctype { get; set; }

    public string? Vflag { get; set; }

    public string? Createdate { get; set; }

    public decimal? Ttstepcnt { get; set; }

    public string? Pono { get; set; }

    public string? Outdate { get; set; }

    public decimal? Totruntime { get; set; }

    public decimal? Totholdtime { get; set; }

    public decimal? Totwaittime { get; set; }

    public string? DailyPday { get; set; }

    public DateTime? Pcmendtime { get; set; }

    public decimal? Pcmholdtimes { get; set; }

    public string? Lotowner { get; set; }

    public string? Processtype { get; set; }

    public decimal? Custhold { get; set; }

    public string? Newwono { get; set; }

    public string? Lotcomment { get; set; }

    public decimal? Ttphotos { get; set; }

    public string? Ownerid { get; set; }

    public decimal? Tpy { get; set; }

    public string? Bank0process { get; set; }

    public string? Bank0processver { get; set; }

    public string? Beprocess { get; set; }

    public string? Beprocessver { get; set; }

    public string? Isepi { get; set; }

    public string? Wbflag { get; set; }

    public DateTime? Bankreleasedate { get; set; }

    public string? Parentid { get; set; }

    public DateTime? Splitdate { get; set; }

    public string? Epiouttime { get; set; }

    public DateTime? Planinvdate { get; set; }

    public string? Plocation { get; set; }

    public string? Ordertype { get; set; }

    public string? Wafervendor { get; set; }

    public string? ParCode { get; set; }
}
