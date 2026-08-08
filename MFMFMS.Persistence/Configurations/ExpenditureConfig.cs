using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFMFMS.Persistence.Configurations
{
    public class ExpenditureConfig : IEntityTypeConfiguration<Expenditure>
    {
        public void Configure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.Property(prop => prop.Amount)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.ToTable(table =>
                table.HasCheckConstraint(
                    "CK_Expenditure_Amount_Positive",
                    "[Amount] > 0"));
        }
    }
}
