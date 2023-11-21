using System;
using System.Collections.Generic;

namespace webapi.Model;

public partial class SpllotDesc
{
    public string Lotid { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Dotime { get; set; } = null!;

    public string? Userdesc { get; set; }
}
