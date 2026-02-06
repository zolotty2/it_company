using System;
using System.Collections.Generic;

namespace it_company;

public partial class User
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int PositionId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;
}
