using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Queries.GetGivingStatistics
{
    public class GetGivingStatisticsQueryHandler : IRequestHandler<GetGivingStatisticsQuery, GivingStatisticsDTO>
    {
        private readonly IGivingRepository _repository;

        public GetGivingStatisticsQueryHandler(IGivingRepository repository)
        {
            _repository = repository;
        }

        public async Task<GivingStatisticsDTO> Handle(GetGivingStatisticsQuery request)
        {
            return await _repository.GetGivingStatistics();
        }
    }
}
