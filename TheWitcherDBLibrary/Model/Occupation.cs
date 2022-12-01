using System;
using System.Collections.Generic;

namespace TheWitcherDBLibrary.Model;

public partial class Occupation
{
    public int Id { get; set; }

    public string OccupationName { get; set; } = null!;

    public virtual ICollection<CharacterOccupation> CharacterOccupations { get; } = new List<CharacterOccupation>();
}
