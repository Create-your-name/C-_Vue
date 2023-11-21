using System;
using System.Collections.Generic;

namespace webapi.Model;

public partial class CostScrap0
{
    public string Lotid { get; set; } = null!;

    public decimal? Scrapqty { get; set; }

    public DateTime Scrapdate { get; set; }

    public string? Productname { get; set; }

    public DateTime? Repdate { get; set; }

    public string? Process { get; set; }

    public string? Processver { get; set; }

    public string? Prodver { get; set; }

    public string? Stepseq { get; set; }
}
