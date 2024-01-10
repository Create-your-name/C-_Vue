using System;
using System.Collections.Generic;

namespace webapi.Model;

public partial class Fwuserprofile
{
    public string Sysid { get; set; } = null!;

    public string? Extendedproperties { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Nickname { get; set; }

    public string Activationdate { get; set; } = null!;

    public string Expirationdate { get; set; } = null!;

    public decimal Agingperiod { get; set; }

    public string Lastpasswordchange { get; set; } = null!;

    public string? Usergroup { get; set; }

    public string? Resourcecategory { get; set; }

    public string? Shop { get; set; }

    public string? Vendor { get; set; }

    public string? Startequipment { get; set; }

    public string? Dbusername { get; set; }

    public string? Selectpartitionids { get; set; }

    public string? Insertpartitionids { get; set; }

    public string? Updatepartitionids { get; set; }

    public string? Deletepartitionids { get; set; }

    public decimal? Woclockonlimit { get; set; }

    public string? Lastlogindatetime { get; set; }

    public string? Allowlogindatetime { get; set; }

    public string? Lastpassword { get; set; }

    public decimal? Failedretrycount { get; set; }

    public string? Lastupdateuser { get; set; }

    public string? Modifieddatetime { get; set; }

    public int Fwtimestamp { get; set; }

    public string? Currenthistory { get; set; }

    public string? Historyissuppressed { get; set; }

    public string? Historyhasbeensuppressed { get; set; }
}
