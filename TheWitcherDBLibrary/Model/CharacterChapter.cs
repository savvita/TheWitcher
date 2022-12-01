using System;
using System.Collections.Generic;

namespace TheWitcherDBLibrary.Model;

public partial class CharacterChapter
{
    public int Id { get; set; }

    public int CharacterId { get; set; }

    public int ChapterId { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;

    public virtual Character Character { get; set; } = null!;
}
