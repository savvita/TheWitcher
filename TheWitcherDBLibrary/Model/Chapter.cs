using System;
using System.Collections.Generic;

namespace TheWitcherDBLibrary.Model;

public partial class Chapter
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CharacterChapter> CharacterChapters { get; } = new List<CharacterChapter>();
}
