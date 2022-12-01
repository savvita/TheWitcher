using System;
using System.Collections.Generic;

namespace TheWitcherDBLibrary.Model;

public partial class CharacterOccupation
{
    public int Id { get; set; }

    public int? CharacterId { get; set; }

    public int? OccupationId { get; set; }

    public virtual Character? Character { get; set; }

    public virtual Occupation? Occupation { get; set; }
}
