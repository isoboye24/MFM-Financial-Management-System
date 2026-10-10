using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFMFMS.Persistence.Configurations
{
    public class FinancialSummaryMonthlyReportConfig : IEntityTypeConfiguration<FinancialSummaryMonthlyReport>
    {
        public void Configure(EntityTypeBuilder<FinancialSummaryMonthlyReport> builder)
        {
            builder.Property(prop => prop.Month).IsRequired();
            builder.Property(prop => prop.Year).IsRequired();
            builder.Property(prop => prop.OpeningBalance).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(prop => prop.TotalIncome).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(prop => prop.TotalExpenditure).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(prop => prop.ClosingBalance).HasColumnType("decimal(18,2)").IsRequired();            
        }
    }
}
