using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Queries.GetTotalGivingStatistics
{
    public class GetGivingStatisticsQueryHandler : IRequestHandler<GetTotalGivingStatisticsQuery, TotalGivingStatisticsDTO>
    {
        private readonly IGivingRepository _repository;

        public GetGivingStatisticsQueryHandler(IGivingRepository repository)
        {
            _repository = repository;
        }

        public async Task<TotalGivingStatisticsDTO> Handle(GetTotalGivingStatisticsQuery request)
        {
            return await _repository.GetTotalGivingStatistics();
        }
    }
}
