using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetMonthlyExpendituresStatistics
{
    public class GetMonthlyExpendituresStatisticsQuery : IRequest<MonthlyExpendituresStatisticsDTO>
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
