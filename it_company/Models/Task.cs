using System;
using System.Collections.Generic;

namespace it_company;

public partial class Task
{
    public int Id { get; set; }

    public string TaskName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int StatusId { get; set; }

    public int PriorityId { get; set; }

    public int ProjectId { get; set; }

    public string Executor { get; set; } = null!;

    public DateOnly DateOfCreate { get; set; }

    public DateOnly? DateOfEnd { get; set; }

    public virtual Priority Priority { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
