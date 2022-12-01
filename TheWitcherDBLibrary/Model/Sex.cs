using System;
using System.Collections.Generic;

namespace TheWitcherDBLibrary.Model;

public partial class Sex
{
    public int Id { get; set; }

    public string SexName { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; } = new List<Character>();
}
