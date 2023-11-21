using System;
using System.Collections.Generic;

namespace webapi.Entity.Rxrep;

public partial class RptWipTrackout
{
    public string Wipid { get; set; } = null!;

    public string Trackoutbyid { get; set; } = null!;

    public string? Trackoutby { get; set; }

    public string Trackouttime { get; set; } = null!;

    public int Trackoutqty { get; set; }

    public string? Trackintime { get; set; }

    public string? Lasttrackout { get; set; }

    public string? Productname { get; set; }

    public string? Productversion { get; set; }

    public string? Planname { get; set; }

    public string? Planversion { get; set; }

    public string? Stepname { get; set; }

    public string? Stepversion { get; set; }

    public string? Equipname { get; set; }

    public string? Stepseq { get; set; }

    public string? Equipgroup { get; set; }

    public string? Lottype { get; set; }

    public string? Photoflag { get; set; }

    public decimal? Whold { get; set; }

    public decimal? Rhold { get; set; }

    public decimal? Tthold { get; set; }

    public decimal? Dummyqty { get; set; }

    public string? Trackinbyid { get; set; }

    public string? Trackinby { get; set; }

    public decimal? Trackinqty { get; set; }

    public string? Setuptime { get; set; }

    public string? Processflag { get; set; }

    public string? Stage { get; set; }

    public string? Stepdescription { get; set; }

    public string? Recipe { get; set; }

    public string? Grouphistkey { get; set; }

    public decimal? Custhold { get; set; }

    public decimal? Priority { get; set; }

    public DateTime? Repdate { get; set; }

    public string? Activity { get; set; }

    public string? Outflag { get; set; }

    public string? Batchid { get; set; }

    public string? AbcType { get; set; }

    public string? Reworkflag { get; set; }
}
