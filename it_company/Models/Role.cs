using System;
using System.Collections.Generic;

namespace it_company;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Executor> Executors { get; set; } = new List<Executor>();
}
