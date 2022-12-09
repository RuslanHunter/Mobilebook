using System;
using System.Collections.Generic;

namespace Mobilebook.Mvvm.Model;

public partial class CallUser
{
    public int IdCallUser { get; set; }

    public int? IdCall { get; set; }

    public int? IdUser { get; set; }

    public string? OutInt { get; set; }

    public int? Cost { get; set; }

    public virtual Call? IdCallNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
