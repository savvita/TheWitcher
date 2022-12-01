using System;
using System.Collections.Generic;

namespace TheWitcherDBLibrary.Model;

public partial class CharacterBelongsTo
{
    public int Id { get; set; }

    public int? CharacterId { get; set; }

    public int? BelongToId { get; set; }

    public virtual BelongsTo? BelongTo { get; set; }

    public virtual Character? Character { get; set; }
}
