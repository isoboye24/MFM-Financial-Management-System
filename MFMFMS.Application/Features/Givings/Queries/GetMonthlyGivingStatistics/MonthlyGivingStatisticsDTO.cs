namespace MFMFMS.Application.Features.Givings.Queries.GetMonthlyGivingStatistics
{
    public class MonthlyGivingStatisticsDTO
    {
        public decimal MonthlyTithes { get; set; }
        public decimal MonthlyOfferings { get; set; }
        public decimal MonthlySeeds { get; set; }
        public decimal MonthlyOtherIncome { get; set; }
    }
}
