using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Queries.GetMonthlyGivingStatistics
{
    public class GetMonthlyGivingStatisticsQuery : IRequest<MonthlyGivingStatisticsDTO>
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
