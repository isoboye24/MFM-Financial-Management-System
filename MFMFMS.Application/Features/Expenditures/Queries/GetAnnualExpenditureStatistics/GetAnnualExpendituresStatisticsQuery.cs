using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetAnnualExpenditureStatistics
{
    public class GetAnnualExpendituresStatisticsQuery : IRequest<AnnualExpendituresStatisticsDTO>
    {
        public int Year { get; set; }
    }
}
