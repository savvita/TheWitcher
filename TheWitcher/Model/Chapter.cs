using System;
using System.Collections.Generic;

namespace TheWitcher.Model;

public partial class Chapter
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; } = new List<Character>();
}
