using System;
using System.Collections.Generic;

namespace TheWitcher.Model;

public partial class Occupation
{
    public int Id { get; set; }

    public string OccupationName { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; } = new List<Character>();
}
