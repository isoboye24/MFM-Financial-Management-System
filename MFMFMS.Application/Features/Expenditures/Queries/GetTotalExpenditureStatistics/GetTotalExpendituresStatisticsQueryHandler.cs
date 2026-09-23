using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetTotalExpenditureStatistics
{
    public class GetTotalExpendituresStatisticsQueryHandler : IRequestHandler<GetTotalExpendituresStatisticsQuery, TotalExpendituresStatisticsDTO>
    {
        private readonly IExpenditureRepository _expenditureRepository;

        public GetTotalExpendituresStatisticsQueryHandler(IExpenditureRepository expenditureRepository)
        {
            _expenditureRepository = expenditureRepository;
        }

        public async Task<TotalExpendituresStatisticsDTO> Handle(GetTotalExpendituresStatisticsQuery request)
        {
            return await _expenditureRepository.GetTotalExpenditureStatistics();
        }
    }
}
