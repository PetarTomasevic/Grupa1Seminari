﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Seminar2HelgaAbramovic.Models;

public partial class Seminar2Context : DbContext
{
    public Seminar2Context()
    {
    }

    public Seminar2Context(DbContextOptions<Seminar2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Adrese> Adreses { get; set; }

    public virtual DbSet<Drzave> Drzaves { get; set; }

    public virtual DbSet<Gradovi> Gradovis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DAD59KM;Initial Catalog=Seminar2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adrese>(entity =>
        {
            entity.ToTable("Adrese");

            entity.Property(e => e.Kat).HasMaxLength(10);
            entity.Property(e => e.KucniBroj).HasMaxLength(10);
            entity.Property(e => e.NazivUlice).HasMaxLength(200);

            entity.HasOne(d => d.IdGradoviNavigation).WithMany(p => p.Adreses)
                .HasForeignKey(d => d.IdGradovi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adrese_Gradovi");
        });

        modelBuilder.Entity<Drzave>(entity =>
        {
            entity.ToTable("Drzave");

            entity.Property(e => e.Kratica).HasMaxLength(10);
            entity.Property(e => e.Naziv).HasMaxLength(50);
            entity.Property(e => e.Opis).HasMaxLength(50);
        });

        modelBuilder.Entity<Gradovi>(entity =>
        {
            entity.ToTable("Gradovi");

            entity.Property(e => e.Naziv).HasMaxLength(200);
            entity.Property(e => e.Postanskibroj).HasMaxLength(20);

            entity.HasOne(d => d.IdDrzaveNavigation).WithMany(p => p.Gradovis)
                .HasForeignKey(d => d.IdDrzave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gradovi_Drzave");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
