using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Queries.GetAnnualGivingStatistics
{
    public class GetAnnualGivingStatisticsQuery : IRequest<AnnualGivingStatisticsDTO>
    {
        public int Year { get; set; }
    }
}
