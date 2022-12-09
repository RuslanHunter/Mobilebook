using System;
using System.Collections.Generic;

namespace Mobilebook.Mvvm.Model;

public partial class Price
{
    public int IdPrice { get; set; }

    public string? TimeOfDay { get; set; }

    public int? Tariff { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Call> Calls { get; } = new List<Call>();
}
