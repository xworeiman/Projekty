using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GRC.Api.XModels
{
    public partial class GRCContext : DbContext
    {
        public GRCContext()
        {
        }

        public GRCContext(DbContextOptions<GRCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ControlMechanism> ControlMechanism { get; set; }
        public virtual DbSet<ControlMechanismRelations> ControlMechanismRelations { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<ProcessOrigin> ProcessOrigin { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<SubProcess> SubProcess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GRC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControlMechanism>(entity =>
            {
                entity.ToTable("ControlMechanism", "mfk");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EnterpriseId)
                    .HasColumnName("EnterpriseID")
                    .HasMaxLength(50);

                entity.Property(e => e.ModyfiDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.OwnerOrganisationUnit).HasMaxLength(200);

                entity.Property(e => e.PreviusVersionId).HasColumnName("PreviusVersionID");

                entity.Property(e => e.ProcessOriginId).HasColumnName("ProcessOriginID");

                entity.Property(e => e.Version).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.PreviusVersion)
                    .WithMany(p => p.InversePreviusVersion)
                    .HasForeignKey(d => d.PreviusVersionId)
                    .HasConstraintName("FK_ControlMechanism_ControlMechanism");

                entity.HasOne(d => d.ProcessOrigin)
                    .WithMany(p => p.ControlMechanism)
                    .HasForeignKey(d => d.ProcessOriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ControlMechanism_ProcessOrigin");
            });

            modelBuilder.Entity<ControlMechanismRelations>(entity =>
            {
                entity.ToTable("ControlMechanismRelations", "mfk");

                entity.HasIndex(e => new { e.ControlMechanizmId, e.ProcessId, e.SubProcessId, e.StageId, e.Version })
                    .HasName("UIX_ControlMechanismRelations")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ControlMechanizmId).HasColumnName("ControlMechanizmID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PreviusVersionId).HasColumnName("PreviusVersionID");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.ProcessOriginId).HasColumnName("ProcessOriginID");

                entity.Property(e => e.StageId).HasColumnName("StageID");

                entity.Property(e => e.SubProcessId).HasColumnName("SubProcessID");

                entity.Property(e => e.Version).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ControlMechanizm)
                    .WithMany(p => p.ControlMechanismRelations)
                    .HasForeignKey(d => d.ControlMechanizmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ControlMechanismRelations_ControlMechanism");

                entity.HasOne(d => d.PreviusVersion)
                    .WithMany(p => p.InversePreviusVersion)
                    .HasForeignKey(d => d.PreviusVersionId)
                    .HasConstraintName("FK_ControlMechanismRelations_ControlMechanismRelations");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ControlMechanismRelations)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK_ControlMechanismRelations_Process");

                entity.HasOne(d => d.ProcessOrigin)
                    .WithMany(p => p.ControlMechanismRelations)
                    .HasForeignKey(d => d.ProcessOriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ControlMechanismRelations_ProcessOrigin");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.ControlMechanismRelations)
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("FK_ControlMechanismRelations_Stage");

                entity.HasOne(d => d.SubProcess)
                    .WithMany(p => p.ControlMechanismRelations)
                    .HasForeignKey(d => d.SubProcessId)
                    .HasConstraintName("FK_ControlMechanismRelations_SubProcess");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("Process", "mfk");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcceptDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EnterpriseId)
                    .HasColumnName("EnterpriseID")
                    .HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.OwnerOrganisationUnit).HasMaxLength(200);

                entity.Property(e => e.PreviusVersionId).HasColumnName("PreviusVersionID");

                entity.Property(e => e.ProcessOriginId).HasColumnName("ProcessOriginID");

                entity.Property(e => e.Version).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.PreviusVersion)
                    .WithMany(p => p.InversePreviusVersion)
                    .HasForeignKey(d => d.PreviusVersionId)
                    .HasConstraintName("FK_Process_PreviusVersion");

                entity.HasOne(d => d.ProcessOrigin)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.ProcessOriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Process_ProcessOrigin");
            });

            modelBuilder.Entity<ProcessOrigin>(entity =>
            {
                entity.ToTable("ProcessOrigin", "mfk");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActiveVersion).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastVersion).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("Stage", "mfk");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EnterpriseId)
                    .HasColumnName("EnterpriseID")
                    .HasMaxLength(50);

                entity.Property(e => e.ModyfiDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.OwnerOrganisationUnit).HasMaxLength(200);

                entity.Property(e => e.ParrentId).HasColumnName("ParrentID");

                entity.Property(e => e.PreviusVersionId).HasColumnName("PreviusVersionID");

                entity.Property(e => e.ProcessOriginId).HasColumnName("ProcessOriginID");

                entity.Property(e => e.Version).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Parrent)
                    .WithMany(p => p.Stage)
                    .HasForeignKey(d => d.ParrentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stage_SubProcess");

                entity.HasOne(d => d.PreviusVersion)
                    .WithMany(p => p.InversePreviusVersion)
                    .HasForeignKey(d => d.PreviusVersionId)
                    .HasConstraintName("FK_Stage_Stage");

                entity.HasOne(d => d.ProcessOrigin)
                    .WithMany(p => p.Stage)
                    .HasForeignKey(d => d.ProcessOriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stage_ProcessOrigin");
            });

            modelBuilder.Entity<SubProcess>(entity =>
            {
                entity.ToTable("SubProcess", "mfk");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EnterpriseId)
                    .HasColumnName("EnterpriseID")
                    .HasMaxLength(50);

                entity.Property(e => e.ModyfiDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.OwnerOrganisationUnit).HasMaxLength(200);

                entity.Property(e => e.ParrentId).HasColumnName("ParrentID");

                entity.Property(e => e.PreviusVersionId).HasColumnName("PreviusVersionID");

                entity.Property(e => e.ProcessOriginId).HasColumnName("ProcessOriginID");

                entity.Property(e => e.Version).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Parrent)
                    .WithMany(p => p.SubProcess)
                    .HasForeignKey(d => d.ParrentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubProcess_Process");

                entity.HasOne(d => d.PreviusVersion)
                    .WithMany(p => p.InversePreviusVersion)
                    .HasForeignKey(d => d.PreviusVersionId)
                    .HasConstraintName("FK_SubProcess_SubProcess");

                entity.HasOne(d => d.ProcessOrigin)
                    .WithMany(p => p.SubProcess)
                    .HasForeignKey(d => d.ProcessOriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubProcess_ProcessOrigin");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
