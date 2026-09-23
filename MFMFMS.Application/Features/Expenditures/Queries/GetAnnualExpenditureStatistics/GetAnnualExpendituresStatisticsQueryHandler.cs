using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetAnnualExpenditureStatistics
{
    public class GetAnnualExpendituresStatisticsQueryHandler : IRequestHandler<GetAnnualExpendituresStatisticsQuery, AnnualExpendituresStatisticsDTO>
    {
        private readonly IExpenditureRepository _expenditureRepository;

        public GetAnnualExpendituresStatisticsQueryHandler(IExpenditureRepository expenditureRepository)
        {
            _expenditureRepository = expenditureRepository;
        }

        public async Task<AnnualExpendituresStatisticsDTO> Handle(GetAnnualExpendituresStatisticsQuery request)
        {
            return await _expenditureRepository.GetAnnualExpenditureStatistics(request.Year);
        }
    }
}
