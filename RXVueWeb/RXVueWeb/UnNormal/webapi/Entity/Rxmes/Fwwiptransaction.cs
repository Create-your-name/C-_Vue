using System;
using System.Collections.Generic;

namespace webapi.Entity.Rxmes;

public partial class Fwwiptransaction
{
    public string Sysid { get; set; } = null!;

    public string? Lasttxnid { get; set; }

    public decimal? Txnsequence { get; set; }

    public string? Activity { get; set; }

    public string Wipid { get; set; } = null!;

    public string Userid { get; set; } = null!;

    public string Lotobject { get; set; } = null!;

    public string? Txncomment { get; set; }

    public string? Parenttxn { get; set; }

    public string Txntimestamp { get; set; } = null!;

    public string? Undoflag { get; set; }

    public string? Attribute { get; set; }

    public string? Originalvalue { get; set; }

    public string? Newvalue { get; set; }

    public string? Instep { get; set; }

    public decimal? Quantityin { get; set; }

    public string? Inlocation { get; set; }

    public string? Holdrelease { get; set; }

    public string? Reworkstep { get; set; }

    public decimal? Componentqtyadded { get; set; }

    public decimal? Componentqtyremoved { get; set; }

    public string? Mergestepid { get; set; }

    public string? Outstep { get; set; }

    public decimal? Quantityout { get; set; }

    public string? Originalstep { get; set; }

    public string? Newstep { get; set; }

    public string? Path { get; set; }

    public string? Frommaterial { get; set; }

    public decimal? Consumeqty { get; set; }

    public string? Fromlocation { get; set; }

    public string? Tolocation { get; set; }

    public string? Newproduct { get; set; }

    public string? Newplan { get; set; }

    public string? Receiveinfo { get; set; }

    public string? Shipmentnumber { get; set; }

    public string? Mainlotid { get; set; }

    public string? Futureholdplanid { get; set; }

    public string? Futureholdstepid { get; set; }

    public string? Clearfutureholdplanid { get; set; }

    public string? Clearfutureholdstepid { get; set; }

    public string? Transferfromlotid { get; set; }

    public string? Transfertolotid { get; set; }

    public decimal? Transferqty { get; set; }

    public string? Trackintime { get; set; }

    public string? Lasttrackout { get; set; }

    public string? Undotype { get; set; }

    public string? Wiptxntoundo { get; set; }

    public string? Stepidbeforeundo { get; set; }

    public string? Stepidtoundo { get; set; }

    public string? Stepidafterundo { get; set; }

    public string? Stephandleforundo { get; set; }

    public string? Endstephandle { get; set; }

    public string? Rejoinstephandle { get; set; }

    public string? Newlotid { get; set; }

    public string? Oldlotid { get; set; }

    public string? Futuretype { get; set; }

    public string? Futureplanid { get; set; }

    public string? Futurestepid { get; set; }

    public string? Componentid { get; set; }

    public string? Schedule { get; set; }

    public decimal? Scheduleversion { get; set; }

    public string? Shift { get; set; }
}
