using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TheWitcherDBLibrary.Model;

public partial class WitcherDbContext : DbContext
{
    public WitcherDbContext()
    {
    }

    public WitcherDbContext(DbContextOptions<WitcherDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BelongsTo> BelongsTos { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterBelongsTo> CharacterBelongsTos { get; set; }

    public virtual DbSet<CharacterChapter> CharacterChapters { get; set; }

    public virtual DbSet<CharacterOccupation> CharacterOccupations { get; set; }

    public virtual DbSet<Occupation> Occupations { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Sex> Sexes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BelongsTo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BelongsT__3214EC0783772503");

            entity.ToTable("BelongsTo");

            entity.Property(e => e.SchoolName).HasMaxLength(100);
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chapters__3214EC07AB10E580");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC076CC9E97A");

            entity.Property(e => e.Death).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Race).WithMany(p => p.Characters)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__Character__RaceI__412EB0B6");

            entity.HasOne(d => d.Sex).WithMany(p => p.Characters)
                .HasForeignKey(d => d.SexId)
                .HasConstraintName("FK__Character__SexId__403A8C7D");
        });

        modelBuilder.Entity<CharacterBelongsTo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC07A809A321");

            entity.ToTable("CharacterBelongsTo");

            entity.HasOne(d => d.BelongTo).WithMany(p => p.CharacterBelongsTos)
                .HasForeignKey(d => d.BelongToId)
                .HasConstraintName("FK__Character__Belon__48CFD27E");

            entity.HasOne(d => d.Character).WithMany(p => p.CharacterBelongsTos)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("FK__Character__Chara__47DBAE45");
        });

        modelBuilder.Entity<CharacterChapter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC07E38107FC");

            entity.ToTable("CharacterChapter");

            entity.HasOne(d => d.Chapter).WithMany(p => p.CharacterChapters)
                .HasForeignKey(d => d.ChapterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Character__Chapt__4CA06362");

            entity.HasOne(d => d.Character).WithMany(p => p.CharacterChapters)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Character__Chara__4BAC3F29");
        });

        modelBuilder.Entity<CharacterOccupation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC075D3BC34A");

            entity.ToTable("CharacterOccupation");

            entity.HasOne(d => d.Character).WithMany(p => p.CharacterOccupations)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("FK__Character__Chara__440B1D61");

            entity.HasOne(d => d.Occupation).WithMany(p => p.CharacterOccupations)
                .HasForeignKey(d => d.OccupationId)
                .HasConstraintName("FK__Character__Occup__44FF419A");
        });

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Occupati__3214EC0769D580BD");

            entity.Property(e => e.OccupationName).HasMaxLength(100);
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Races__3214EC0772A0E7CA");

            entity.Property(e => e.RaceName).HasMaxLength(100);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sections__3214EC07C559A22B");

            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Character).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("FK__Sections__Charac__4F7CD00D");

            entity.HasOne(d => d.ParentSection).WithMany(p => p.InverseParentSection)
                .HasForeignKey(d => d.ParentSectionId)
                .HasConstraintName("FK__Sections__Parent__5070F446");
        });

        modelBuilder.Entity<Sex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sex__3214EC07444275E6");

            entity.ToTable("Sex");

            entity.Property(e => e.SexName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
