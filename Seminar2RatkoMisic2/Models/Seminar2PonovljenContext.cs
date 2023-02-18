using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Seminar2RatkoMisic2.Models;

public partial class Seminar2PonovljenContext : DbContext
{
    public Seminar2PonovljenContext()
    {
    }

    public Seminar2PonovljenContext(DbContextOptions<Seminar2PonovljenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adrese> Adreses { get; set; }

    public virtual DbSet<Drzave> Drzaves { get; set; }

    public virtual DbSet<Gradovi> Gradovis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-R9D8B02J\\MSSQLSERVER01;Initial Catalog=Seminar2Ponovljen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adrese>(entity =>
        {
            entity.ToTable("adrese");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdGradovi).HasColumnName("idGradovi");
            entity.Property(e => e.Kat)
                .HasMaxLength(200)
                .HasColumnName("kat");
            entity.Property(e => e.KucniBroj)
                .HasMaxLength(10)
                .HasColumnName("kucniBroj");
            entity.Property(e => e.NazivUlice)
                .HasMaxLength(200)
                .HasColumnName("nazivUlice");

            entity.HasOne(d => d.IdGradoviNavigation).WithMany(p => p.Adreses)
                .HasForeignKey(d => d.IdGradovi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_adrese_gradovi");
        });

        modelBuilder.Entity<Drzave>(entity =>
        {
            entity.ToTable("drzave");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Kratica)
                .HasMaxLength(10)
                .HasColumnName("kratica");
            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .HasColumnName("naziv");
            entity.Property(e => e.Opis)
                .HasMaxLength(50)
                .HasColumnName("opis");
        });

        modelBuilder.Entity<Gradovi>(entity =>
        {
            entity.ToTable("gradovi");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDrzave).HasColumnName("idDrzave");
            entity.Property(e => e.Naziv)
                .HasMaxLength(200)
                .HasColumnName("naziv");
            entity.Property(e => e.PostanskiBroj)
                .HasMaxLength(20)
                .HasColumnName("postanskiBroj");

            entity.HasOne(d => d.IdDrzaveNavigation).WithMany(p => p.Gradovis)
                .HasForeignKey(d => d.IdDrzave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gradovi_drzave");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
