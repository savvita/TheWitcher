using System;
using System.Collections.Generic;

namespace TheWitcher.Model;

public partial class School
{
    public int Id { get; set; }

    public string SchoolName { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; } = new List<Character>();
}
