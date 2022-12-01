using System;
using System.Collections.Generic;

namespace TheWitcherDBLibrary.Model;

public partial class BelongsTo
{
    public int Id { get; set; }

    public string SchoolName { get; set; } = null!;

    public virtual ICollection<CharacterBelongsTo> CharacterBelongsTos { get; } = new List<CharacterBelongsTo>();
}
