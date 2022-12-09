using System;
using System.Collections.Generic;

namespace Mobilebook.Mvvm.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string? Phone { get; set; }

    public string? NaturalLegacyEntity { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<CallUser> CallUsers { get; } = new List<CallUser>();
}
