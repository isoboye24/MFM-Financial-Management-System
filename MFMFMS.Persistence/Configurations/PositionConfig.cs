using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFMFMS.Persistence.Configurations
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(prop => prop.Name)
               .IsRequired()
               .HasMaxLength(250);
        }
    }
}
