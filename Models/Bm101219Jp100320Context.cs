using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Parcial02_BM101219_JP100320.Models;

public partial class Bm101219Jp100320Context : DbContext
{
    public Bm101219Jp100320Context()
    {
    }

    public Bm101219Jp100320Context(DbContextOptions<Bm101219Jp100320Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Elecciones2019> Elecciones2019s { get; set; }

    public virtual DbSet<VCandidato> VCandidatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Bernal-Lap;Database=BM101219_JP100320;Trusted_Connection=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Elecciones2019>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__eleccion__3213E83F86B9C0AC");

            entity.ToTable("elecciones_2019");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Candidato)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("candidato");
            entity.Property(e => e.Departamento)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("departamento");
            entity.Property(e => e.Votos).HasColumnName("votos");
        });

        modelBuilder.Entity<VCandidato>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Candidato");

            entity.Property(e => e.Candidato)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("candidato");
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
