using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Queries.GetMonthlyGivingStatistics
{
    public class GetMonthlyGivingStatisticsQueryHandler : IRequestHandler<GetMonthlyGivingStatisticsQuery, MonthlyGivingStatisticsDTO>
    {
        private readonly IGivingRepository _repository;

        public GetMonthlyGivingStatisticsQueryHandler(IGivingRepository repository)
        {
            _repository = repository;
        }

        public async Task<MonthlyGivingStatisticsDTO> Handle(GetMonthlyGivingStatisticsQuery request)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            return await _repository.GetMonthlyGivingStatistics(currentDate.Month, currentDate.Year);
        }
    }
}
