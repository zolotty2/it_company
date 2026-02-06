using System;
using System.Collections.Generic;

namespace it_company;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int StatusId { get; set; }

    public DateOnly DateStart { get; set; }

    public string Meneger { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
