using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TheWitcher.Model;

public partial class WitcherDbContext : DbContext
{
    public WitcherDbContext()
    {
    }

    public WitcherDbContext(DbContextOptions<WitcherDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Occupation> Occupations { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Sex> Sexes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chapters__3214EC07E9475645");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC074610CBA6");

            entity.Property(e => e.Death).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Chapter).WithMany(p => p.Characters)
                .HasForeignKey(d => d.ChapterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Character__Chapt__403A8C7D");

            entity.HasOne(d => d.Occupation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.OccupationId)
                .HasConstraintName("FK__Character__Occup__4316F928");

            entity.HasOne(d => d.Race).WithMany(p => p.Characters)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__Character__RaceI__4222D4EF");

            entity.HasOne(d => d.School).WithMany(p => p.Characters)
                .HasForeignKey(d => d.SchoolId)
                .HasConstraintName("FK__Character__Schoo__440B1D61");

            entity.HasOne(d => d.Sex).WithMany(p => p.Characters)
                .HasForeignKey(d => d.SexId)
                .HasConstraintName("FK__Character__SexId__412EB0B6");
        });

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Occupati__3214EC07002E1D35");

            entity.Property(e => e.OccupationName).HasMaxLength(100);
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Races__3214EC074F3D06E4");

            entity.Property(e => e.RaceName).HasMaxLength(100);
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schools__3214EC074BDF6DC7");

            entity.Property(e => e.SchoolName).HasMaxLength(100);
        });

        modelBuilder.Entity<Sex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sex__3214EC07DEA814D6");

            entity.ToTable("Sex");

            entity.Property(e => e.SexName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
