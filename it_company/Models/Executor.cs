using System;
using System.Collections.Generic;

namespace it_company;

public partial class Executor
{
    public int Id { get; set; }

    public int ProjectTypeId { get; set; }

    public string Employee { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ProjectsType ProjectType { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
