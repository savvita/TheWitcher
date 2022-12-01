using System;
using System.Collections.Generic;

namespace TheWitcherDBLibrary.Model;

public partial class Section
{
    public int Id { get; set; }

    public int SectionNumber { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? CharacterId { get; set; }

    public int? ParentSectionId { get; set; }

    public virtual Character? Character { get; set; }

    public virtual ICollection<Section> InverseParentSection { get; } = new List<Section>();

    public virtual Section? ParentSection { get; set; }
}
