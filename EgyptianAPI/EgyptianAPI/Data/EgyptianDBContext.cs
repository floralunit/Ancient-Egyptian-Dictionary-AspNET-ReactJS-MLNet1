﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EgyptianAPI.Models
{
    public partial class EgyptianDBContext : DbContext
    {

        public EgyptianDBContext()
        {
        }

        public EgyptianDBContext(DbContextOptions<EgyptianDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<AbydosCanon> AbydosCanons { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Glyph> Glyphs { get; set; } = null!;
        public virtual DbSet<God> Gods { get; set; } = null!;
        public virtual DbSet<Phonogram> Phonograms { get; set; } = null!;
        public virtual DbSet<SaqqaraCanon> SaqqaraCanons { get; set; } = null!;
        public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=wpl37.hosting.reg.ru;Database=u1667294_EgyptianDB;User Id=u1667294_u1667294;Password=51ApEpAv;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("u1667294_u1667294");

            modelBuilder.Entity<AbydosCanon>(entity =>
            {
                entity.ToTable("AbydosCanon", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dynasty)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EnglishPharaohName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameInList).HasMaxLength(255);

                entity.Property(e => e.PharaohName).HasMaxLength(255);

                entity.Property(e => e.Transliteration).HasMaxLength(255);
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Categoria", "dbo");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Glyph>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Glyph", "dbo");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.GardinerCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.GlyphUnicode).HasMaxLength(10);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.Phonogram).HasMaxLength(255);

                entity.Property(e => e.Transliteration).HasMaxLength(255);

                entity.Property(e => e.UnicodeString).HasMaxLength(25);
            });

            modelBuilder.Entity<God>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("God", "dbo");

                entity.Property(e => e.GardinerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hieroglyphic).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Transliteration).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<Phonogram>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Phonogram", "dbo");

                entity.Property(e => e.GardinerCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Glyph).HasMaxLength(10);

                entity.Property(e => e.ManuelCotage)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Transliteration).HasMaxLength(25);

                entity.Property(e => e.Type)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SaqqaraCanon>(entity =>
            {
                entity.ToTable("SaqqaraCanon", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EnglishPharaohName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameInList).HasMaxLength(255);

                entity.Property(e => e.PharaohName).HasMaxLength(255);

                entity.Property(e => e.Transliteration).HasMaxLength(255);
            });

            modelBuilder.Entity<Sysdiagram>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sysdiagrams", "dbo");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
