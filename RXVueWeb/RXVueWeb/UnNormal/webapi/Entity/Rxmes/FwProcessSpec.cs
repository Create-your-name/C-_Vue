using System;
using System.Collections.Generic;

namespace webapi.Entity.Rxmes;

public partial class FwProcessSpec
{
    public string PROCESS { get; set; } = null!;

    public string? Subplan { get; set; }

    public string? Stage { get; set; }

    public string? Step { get; set; }

    public string? Stephandle { get; set; }

    public string Stepseq { get; set; } = null!;

    public string? Stepcapability { get; set; }

    public string? Stepdescription { get; set; }

    public string? Stocker { get; set; }

    public string? Workarea { get; set; }

    public string? Recipe { get; set; }

    public string? Reticle { get; set; }

    public string? Edcplan { get; set; }

    public string? Instruction { get; set; }

    public string? PrimResource { get; set; }

    public string? BackResource { get; set; }

    public string? Dedicationflag { get; set; }

    public string? Contaminationflag { get; set; }

    public string? Maxexectime { get; set; }

    public string? Maxqueuetime { get; set; }

    public string? Maxreworkcnt { get; set; }

    public string? Processtype { get; set; }

    public string Processver { get; set; } = null!;

    public string? Status { get; set; }

    public byte? Standardruntime { get; set; }

    public string Deletestep { get; set; } = null!;

    public string? Monitorwafer { get; set; }

    public string? Comments { get; set; }

    public string? Runcardinfo { get; set; }

    public string? Firstocapstepseq { get; set; }

    public string? Secondocapstepseq { get; set; }

    public string? Thirdocapstepseq { get; set; }

    public string? Mergestep { get; set; }

    public decimal? PcmYield { get; set; }

    public decimal? PcmEffCores { get; set; }
}
