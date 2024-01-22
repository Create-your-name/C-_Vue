using System;
using System.Collections.Generic;

namespace webapi.Model;

public partial class RepChangepriTmp
{
    public string? Lotid { get; set; }

    public string? Partname { get; set; }

    public decimal? Qty { get; set; }

    public DateTime? Starttime { get; set; }

    public DateTime? Reqdtime { get; set; }

    public DateTime? Foretime { get; set; }

    public decimal? Change { get; set; }

    public string? Stage { get; set; }

    public DateTime? Repdate { get; set; }

    public decimal? Diffe { get; set; }

    public decimal? Ratio { get; set; }

    public decimal? ForeTheoct { get; set; }

    public DateTime? Foretime1 { get; set; }

    public DateTime? Foretime2 { get; set; }

    public decimal? TotTheoct { get; set; }

    public decimal? NowTheoct { get; set; }

    public DateTime? Outdate { get; set; }

    public string? Partid { get; set; }

    public decimal? Flowstep { get; set; }

    public DateTime? Ppforetime { get; set; }

    public decimal? Stageratio { get; set; }
}
