namespace GRC.DataAccess.Configuration
{
    using GRC.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ControlMechanismRelationsConfiguration : IEntityTypeConfiguration<ControlMechanismRelations>
    {
        public void Configure(EntityTypeBuilder<ControlMechanismRelations> builder)
        {
            builder.ToTable("ControlMechanismRelations", "mfk");
            builder.HasIndex(e => new { e.ControlMechanizmId, e.ProcessId, e.SubProcessId, e.StageId, e.Version })
                .HasName("UIX_ControlMechanismRelations")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(e => e.Id)
                .IsClustered(true);

            builder.Property(e => e.ControlMechanizmId)
                .HasColumnName("ControlMechanizmID");

            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.PreviusVersionId).HasColumnName("PreviusVersionID");

            builder.Property(e => e.ProcessId).HasColumnName("ProcessID");

            builder.Property(e => e.OriginId).HasColumnName("OriginID");

            builder.Property(e => e.StageId).HasColumnName("StageID");

            builder.Property(e => e.SubProcessId).HasColumnName("SubProcessID");

            builder.Property(e => e.Version).HasDefaultValueSql("((1))");

            builder.HasOne(d => d.ControlMechanizm)
                .WithMany(p => p.ControlMechanismRelations)
                .HasForeignKey(d => d.ControlMechanizmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlMechanismRelations_ControlMechanism");

            builder.HasOne(d => d.PreviusVersion)
                .WithMany(p => p.InversePreviusVersion)
                .HasForeignKey(d => d.PreviusVersionId)
                .HasConstraintName("FK_ControlMechanismRelations_ControlMechanismRelations");

            builder.HasOne(d => d.Process)
                .WithMany(p => p.ControlMechanismRelations)
                .HasForeignKey(d => d.ProcessId)
                .HasConstraintName("FK_ControlMechanismRelations_Process");

            builder.HasOne(d => d.Origin)
                .WithMany(p => p.ControlMechanismRelations)
                .HasForeignKey(d => d.OriginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlMechanismRelations_Origin")
                .IsRequired();

            builder.HasOne(d => d.Stage)
                .WithMany(p => p.ControlMechanismRelations)
                .HasForeignKey(d => d.StageId)
                .HasConstraintName("FK_ControlMechanismRelations_Stage");

            builder.HasOne(d => d.SubProcess)
                .WithMany(p => p.ControlMechanismRelations)
                .HasForeignKey(d => d.SubProcessId)
                .HasConstraintName("FK_ControlMechanismRelations_SubProcess");
        }
    }
}