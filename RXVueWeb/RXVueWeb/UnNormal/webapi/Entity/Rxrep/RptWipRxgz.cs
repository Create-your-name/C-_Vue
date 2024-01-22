using System;
using System.Collections.Generic;

namespace webapi.Model;

public partial class RptWipRxgz
{
    public string Lotid { get; set; } = null!;

    public string? Lotstatus { get; set; }

    public string? Productname { get; set; }

    public string? Productversion { get; set; }

    public string? Planname { get; set; }

    public string? Planversion { get; set; }

    public string? Lasttransactiontime { get; set; }

    public string? Lasttrackouttime { get; set; }

    public string? Lottype { get; set; }

    public decimal? Priority { get; set; }

    public string? Duedate { get; set; }

    public string? Plancompletedate { get; set; }

    public string? Handle { get; set; }

    public string? Stepname { get; set; }

    public string? Stepdescription { get; set; }

    public string? Stage { get; set; }

    public string? Recipe { get; set; }

    public string? Steplocation { get; set; }

    public string? Resourcetype { get; set; }

    public decimal? Startqty { get; set; }

    public decimal? Wipqty { get; set; }

    public string? Currentrule { get; set; }

    public string? Lotstartdate { get; set; }

    public string? Nstepseq { get; set; }

    public string? Nstepname { get; set; }

    public string? Nstepdesc { get; set; }

    public string? Nstage { get; set; }

    public string? Nrecipe { get; set; }

    public string? Neqpgroup { get; set; }

    public string? ProcessPlatform { get; set; }

    public string? Holdreason { get; set; }

    public string? Holdby { get; set; }

    public string? Wo { get; set; }

    public string? Processtime { get; set; }

    public decimal? Layerno { get; set; }

    public string? Feproduct { get; set; }

    public string? Feproductver { get; set; }

    public string? Feprocess { get; set; }

    public string? Feprocessver { get; set; }

    public string? OutFlag { get; set; }

    public string? Stepcategory { get; set; }

    public string? AbcType { get; set; }

    public DateTime? Repdate { get; set; }

    public DateTime? Lotcreatedate { get; set; }

    public decimal? Balphoto { get; set; }

    public decimal? TodayMoves { get; set; }

    public string? Beflag { get; set; }

    public string? Processtype { get; set; }

    public decimal? Defernum { get; set; }

    public DateTime? YqUpdatedate { get; set; }

    public string? Lotowner { get; set; }

    public decimal? Wbcnt { get; set; }

    public decimal? WbcntBal { get; set; }

    public string? Ordertype { get; set; }

    public string? Planinvdate { get; set; }

    public string? Plocation { get; set; }

    public string? StepseqRw { get; set; }

    public string? Lotcomment { get; set; }

    public string? Cusprod { get; set; }

    public string? Newduedate { get; set; }

    public string? Cusno { get; set; }
}
