using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Queries.GetAnnualGivingStatistics
{
    public class GetAnnualGivingStatisticsQueryHandler : IRequestHandler<GetAnnualGivingStatisticsQuery, AnnualGivingStatisticsDTO>
    {
        private readonly IGivingRepository _repository;

        public GetAnnualGivingStatisticsQueryHandler(IGivingRepository repository)
        {
            _repository = repository;
        }

        public async Task<AnnualGivingStatisticsDTO> Handle(GetAnnualGivingStatisticsQuery request)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            return await _repository.GetAnnualGivingStatistics(currentDate.Year);
        }
    }
}
