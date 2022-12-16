using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sureña_api.Modelos;

public partial class SureñaContext : DbContext
{
    public SureñaContext()
    {
    }

    public SureñaContext(DbContextOptions<SureñaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Funcione> Funciones { get; set; }

    public virtual DbSet<Manual> Manuals { get; set; }

    public virtual DbSet<Relacione> Relaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server = localhost; database = SUREÑA; Trusted_Connection = true; user=sa ;password=Contraseña; Encrypt=false ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.ToTable("Cargo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.ObjetivoCargo).HasColumnName("Objetivo_Cargo");
            entity.Property(e => e.Supervisor).HasMaxLength(50);
        });

        modelBuilder.Entity<Funcione>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdCargo).HasColumnName("ID_Cargo");
            entity.Property(e => e.IdManual).HasColumnName("ID_Manual");
            entity.Property(e => e.NroFuncion)
                .ValueGeneratedOnAdd()
                .HasColumnName("Nro_funcion");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Funciones)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Funciones_Cargo");

            entity.HasOne(d => d.IdManualNavigation).WithMany(p => p.Funciones)
                .HasForeignKey(d => d.IdManual)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Funciones_Manual");
        });

        modelBuilder.Entity<Manual>(entity =>
        {
            entity.ToTable("Manual");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoMan)
                .HasMaxLength(50)
                .HasColumnName("Codigo_Man");
            entity.Property(e => e.EdicionMan)
                .HasMaxLength(50)
                .HasColumnName("Edicion_Man");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Revision).HasMaxLength(50);
        });

        modelBuilder.Entity<Relacione>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdCargo).HasColumnName("ID_Cargo");
            entity.Property(e => e.IdCargoRelacion)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_CargoRelacion");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.RelacioneIdCargoNavigations)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Relaciones_Cargo");

            entity.HasOne(d => d.IdCargoRelacionNavigation).WithMany(p => p.RelacioneIdCargoRelacionNavigations)
                .HasForeignKey(d => d.IdCargoRelacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Relaciones_Cargo1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Contraseña).HasMaxLength(50);
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.Rol).HasMaxLength(50);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
