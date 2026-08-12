using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFMFMS.Persistence.Configurations
{
    public class GivingConfig : IEntityTypeConfiguration<Giving>
    {
        public void Configure(EntityTypeBuilder<Giving> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder.HasOne(x => x.Category)
                   .WithMany()
                   .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Meeting)
                   .WithMany()
                   .HasForeignKey(x => x.MeetingId);
        }
    }
}