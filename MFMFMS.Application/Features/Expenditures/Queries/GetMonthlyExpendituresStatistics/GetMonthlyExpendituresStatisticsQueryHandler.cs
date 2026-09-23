using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetMonthlyExpendituresStatistics
{
    public class GetMonthlyExpendituresStatisticsQueryHandler : IRequestHandler<GetMonthlyExpendituresStatisticsQuery, MonthlyExpendituresStatisticsDTO>
    {
        private readonly IExpenditureRepository _expenditureRepository;

        public GetMonthlyExpendituresStatisticsQueryHandler(IExpenditureRepository expenditureRepository)
        {
            _expenditureRepository = expenditureRepository;
        }

        public async Task<MonthlyExpendituresStatisticsDTO> Handle(GetMonthlyExpendituresStatisticsQuery request)
        {
            return await _expenditureRepository.GetMonthlyExpenditureStatistics(request.Month, request.Year);
        }
    }
}
