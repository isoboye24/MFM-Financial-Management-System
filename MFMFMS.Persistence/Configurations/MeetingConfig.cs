using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFMFMS.Persistence.Configurations
{
    public class MeetingConfig : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.Property(prop => prop.Date).IsRequired();
            builder.Property(prop => prop.Minister).IsRequired();
            builder.Property(prop => prop.MessageTitle).IsRequired();
            builder.ToTable(table =>table.HasCheckConstraint("CK_Meeting_NoOfMaleAttendance_Positive", "[NoOfMaleAttendance] >= 0"));
            builder.ToTable(table =>table.HasCheckConstraint("CK_Meeting_NoOfFemaleAttendance_Positive", "[NoOfFemaleAttendance] >= 0"));
            builder.ToTable(table =>table.HasCheckConstraint("CK_Meeting_NoOfChildrenAttendance_Positive", "[NoOfChildrenAttendance] >= 0"));
        }
    }
}
