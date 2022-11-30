using System;
using System.Collections.Generic;

namespace TheWitcher.Model;

public partial class Race
{
    public int Id { get; set; }

    public string RaceName { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; } = new List<Character>();
}
