using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using consultorioNutricion.Models;

namespace consultorioNutricion.Data;

public partial class ConsultorioDbContext : DbContext
{
    public ConsultorioDbContext()
    {
    }

    public ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Consultum> Consulta { get; set; }

    public virtual DbSet<ObraSocial> ObraSocials { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<ProfesionalSalud> ProfesionalSaluds { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.CiudadId).HasName("PK__ciudad__9FC23FCA070C2500");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Ciudads)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ciudad__provinci__398D8EEE");
        });

        modelBuilder.Entity<Consultum>(entity =>
        {
            entity.HasKey(e => e.ConsultaId).HasName("PK__consulta__6EE42A6A938B2FDE");

            entity.HasOne(d => d.Turno).WithMany(p => p.Consulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__consulta__turnoI__48CFD27E");
        });

        modelBuilder.Entity<ObraSocial>(entity =>
        {
            entity.HasKey(e => e.ObraSocialId).HasName("PK__obraSoci__D2B23EF97374D02F");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId).HasName("PK__paciente__0AB98B0EE3EF8262");

            entity.Property(e => e.Dni).IsFixedLength();

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Pacientes).HasConstraintName("FK__paciente__ciudad__412EB0B6");

            entity.HasOne(d => d.ObraSocial).WithMany(p => p.Pacientes).HasConstraintName("FK__paciente__obraSo__4222D4EF");
        });

        modelBuilder.Entity<ProfesionalSalud>(entity =>
        {
            entity.HasKey(e => e.ProfesionalSaludId).HasName("PK__profesio__55AC456B734C3FE7");

            entity.Property(e => e.Dni).IsFixedLength();

            entity.HasOne(d => d.Ciudad).WithMany(p => p.ProfesionalSaluds).HasConstraintName("FK__profesion__ciuda__3E52440B");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__provinci__671F12A57E2EA03C");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.TurnoId).HasName("PK__turno__44E227011C6BBA66");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Turnos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__turno__pacienteI__44FF419A");

            entity.HasOne(d => d.ProfesionalSalud).WithMany(p => p.Turnos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__turno__profesion__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
