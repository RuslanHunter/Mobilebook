using System;
using System.Collections.Generic;

namespace Mobilebook.Mvvm.Model;

public partial class Call
{
    public int IdCall { get; set; }

    public string? PhoneAbonent { get; set; }

    public string? Date { get; set; }

    public int? Duration { get; set; }

    public int? IdPrice { get; set; }

    public virtual ICollection<CallUser> CallUsers { get; } = new List<CallUser>();

    public virtual Price? IdPriceNavigation { get; set; }
}
