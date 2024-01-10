using System;
using System.Collections.Generic;

namespace webapi.Model;

public partial class RptScrap
{
    public string Wipid { get; set; } = null!;

    public string Userid { get; set; } = null!;

    public string Scrapdate { get; set; } = null!;

    public decimal? Scrapqty { get; set; }

    public string Scrapsysid { get; set; } = null!;

    public string? Occursinstep { get; set; }

    public string? Commentcode { get; set; }

    public string? Briefdescription { get; set; }

    public string? Detaileddescription { get; set; }

    public string? Username { get; set; }

    public string? Process { get; set; }

    public string? Processver { get; set; }

    public string? Productname { get; set; }

    public string? Prodver { get; set; }

    public string? Lottype { get; set; }

    public decimal? Lotquantity { get; set; }

    public string? Stepseq { get; set; }

    public string? Stage { get; set; }

    public string? Pcmflag { get; set; }

    public string? Processflag { get; set; }

    public string? Equipname { get; set; }

    public string? Platform { get; set; }

    public string? Processtype { get; set; }

    public string? Lotcomment { get; set; }

    public string? Pday { get; set; }

    public decimal? Scrapqty1 { get; set; }

    public string? Wono { get; set; }

    public string? Lotowner { get; set; }

    public decimal? Ttphotos { get; set; }

    public decimal? Photosort { get; set; }

    public string? Pstatus { get; set; }

    public string? AbnormDept1 { get; set; }

    public string? AbnormDept2 { get; set; }

    public decimal? AbnormScrap1 { get; set; }

    public decimal? AbnormScarp2 { get; set; }

    public string? AbnormReason { get; set; }

    public string? Abnormcard { get; set; }

    public string? Lott { get; set; }

    public string? Scraptype { get; set; }

    public string? Enganalyze { get; set; }

    public string? Engdescription { get; set; }

    public string? Engabnormequip { get; set; }

    public string? Cause1 { get; set; }

    public string? Cause2 { get; set; }

    public decimal? Flowstep { get; set; }

    public decimal? Maxflowstep { get; set; }

    public string? ScrapWaferno { get; set; }

    public string? ScrapReason { get; set; }
}
