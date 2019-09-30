namespace GRC.DataAccess.Configuration
{
    using GRC.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OriginConfiguration : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> builder)
        {

            builder.ToTable("Origin", "mfk");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(e => e.Id)
                .IsClustered(true);

            //builder.Property(e => e.ActiveVersion)
            //    .HasDefaultValueSql("((1))");

            //builder.Property(e => e.LastVersion)
            //    .HasDefaultValueSql("((1))");
        }
    }
}