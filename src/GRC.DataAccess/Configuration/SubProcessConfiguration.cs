﻿namespace GRC.DataAccess.Configuration
{
    using GRC.Domain.Models;
    using GRC.Domain.Models.States;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    internal class SubProcessConfiguration : IEntityTypeConfiguration<SubProcess>
    {
        public void Configure(EntityTypeBuilder<SubProcess> builder)
        {
            builder.ToTable("SubProcess", "mfk");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(e => e.Id)
                .IsClustered(true);

            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.State)
                .HasConversion(new EnumToNumberConverter<MfkStates, int>());

            builder.Property(e => e.EnterpriseId)
                .HasColumnName("EnterpriseID")
                .HasMaxLength(50);

            builder.Property(e => e.ModyfiDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Name).HasMaxLength(300);

            builder.OwnsOne(o => o.Owner, t =>
            {
                t.Property(e => e.OwnerId).HasColumnName("OwnerID");
                t.Property(e => e.OwnerOrganisationUnit).HasColumnName("OwnerOrganisationUnit").HasMaxLength(200);
            });
            //builder.Property(e => e.OwnerId).HasColumnName("OwnerID");

            //builder.Property(e => e.OwnerOrganisationUnit).HasMaxLength(200);

            builder.Property(e => e.ParentId).HasColumnName("ParentID");

            builder.Property(e => e.PreviusVersionId).HasColumnName("PreviusVersionID");

            builder.Property(e => e.OriginId).HasColumnName("OriginID");

            builder.Property(e => e.Version).HasDefaultValueSql("((1))");

            builder.HasOne(d => d.Parent)
                .WithMany(p => p.Childs)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubProcess_Process")
                .IsRequired();

            builder.HasOne(d => d.PreviusVersion)
                .WithMany(p => p.InversePreviusVersion)
                .HasForeignKey(d => d.PreviusVersionId)
                .HasConstraintName("FK_SubProcess_SubProcess");

            builder.HasOne(d => d.Origin)
                .WithMany(p => p.SubProcess)
                .HasForeignKey(d => d.OriginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubProcess_Origin")
                .IsRequired();
        }
    }
}