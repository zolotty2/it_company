using System;
using System.Collections.Generic;

namespace it_company;

public partial class ProjectsType
{
    public int Id { get; set; }

    public string ProjectTypeName { get; set; } = null!;

    public virtual ICollection<Executor> Executors { get; set; } = new List<Executor>();
}
