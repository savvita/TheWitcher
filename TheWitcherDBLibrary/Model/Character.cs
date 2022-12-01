using System;
using System.Collections.Generic;

namespace TheWitcherDBLibrary.Model;

public partial class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? SexId { get; set; }

    public int? RaceId { get; set; }

    public string? Death { get; set; }

    public string? Description { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual ICollection<CharacterBelongsTo> CharacterBelongsTos { get; } = new List<CharacterBelongsTo>();

    public virtual ICollection<CharacterChapter> CharacterChapters { get; } = new List<CharacterChapter>();

    public virtual ICollection<CharacterOccupation> CharacterOccupations { get; } = new List<CharacterOccupation>();

    public virtual Race? Race { get; set; }

    public virtual ICollection<Section> Sections { get; } = new List<Section>();

    public virtual Sex? Sex { get; set; }
}
