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
                .HasDefaultValueSql("(NEXT VALUE FOR [mfk].[OriginPK])");

            builder.HasKey(e => e.Id)
                .IsClustered(true);
        }
    }
}