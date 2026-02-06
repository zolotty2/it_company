using System;
using System.Collections.Generic;

namespace it_company;

public partial class Position
{
    public int Id { get; set; }

    public string PosName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
