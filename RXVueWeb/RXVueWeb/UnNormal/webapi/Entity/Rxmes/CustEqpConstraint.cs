using System;
using System.Collections.Generic;

namespace webapi.Model;

public partial class CustEqpConstraint
{
    public string Eqpid { get; set; } = null!;

    public string Ectp { get; set; } = null!;

    public string Ckord { get; set; } = null!;

    public string? Product { get; set; }

    public string? Process { get; set; }

    public string? Stage { get; set; }

    public string? Step { get; set; }

    public string? Recipe { get; set; }

    public string Userid { get; set; } = null!;

    public string Docid { get; set; } = null!;

    public string Doctp { get; set; } = null!;

    public DateTime EnterD { get; set; }

    public DateTime EffectiveD { get; set; }

    public DateTime ExpireD { get; set; }

    public string? CstDes { get; set; }

    public string? Lotid { get; set; }

    public string Status { get; set; } = null!;

    public string? Eqpgroup { get; set; }

    public string? Sysid { get; set; }

    public string? Description { get; set; }

    public decimal? Seqid { get; set; }

    public string? Subplan { get; set; }
}
