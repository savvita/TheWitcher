using System;
using System.Collections.Generic;

namespace TheWitcher.Model;

public partial class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ChapterId { get; set; }

    public int? SexId { get; set; }

    public int? RaceId { get; set; }

    public int? OccupationId { get; set; }

    public int? SchoolId { get; set; }

    public string? Death { get; set; }

    public string? Description { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Chapter Chapter { get; set; } = null!;

    public virtual Occupation? Occupation { get; set; }

    public virtual Race? Race { get; set; }

    public virtual School? School { get; set; }

    public virtual Sex? Sex { get; set; }
}
