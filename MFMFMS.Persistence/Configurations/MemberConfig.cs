using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFMFMS.Persistence.Configurations
{
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(prop => prop.FirstName).IsRequired();
            builder.Property(prop => prop.LastName).IsRequired();
            builder.Property(prop => prop.Address).IsRequired();
            builder.Property(prop => prop.PhoneNumber).IsRequired();
            builder.Property(prop => prop.Position).IsRequired();
        }
    }
}
