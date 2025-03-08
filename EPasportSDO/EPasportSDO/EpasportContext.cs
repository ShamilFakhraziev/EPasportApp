using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EPasportSDO;

public partial class EpasportContext : DbContext
{
    public EpasportContext()
    {
    }

    public EpasportContext(DbContextOptions<EpasportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaintenanceWorks> MaintenanceWorksSets { get; set; }

    public virtual DbSet<TechObject> TechObjectSets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-A8O78SR;Database=EPasport;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaintenanceWorks>(entity =>
        {
            entity.ToTable("MaintenanceWorksSet");

            entity.HasIndex(e => e.TechObjectId, "IX_FK_TechObjectMaintenanceWorks");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PriceOfWork).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TechObjectId).HasColumnName("TechObject_Id");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.TechObject).WithMany(p => p.MaintenanceWorksSets)
                .HasForeignKey(d => d.TechObjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TechObjectMaintenanceWorks");
        });

        modelBuilder.Entity<TechObject>(entity =>
        {
            entity.ToTable("TechObjectSet");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfSale).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductionTime).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
