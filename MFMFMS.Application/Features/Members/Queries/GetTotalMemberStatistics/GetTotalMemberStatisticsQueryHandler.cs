using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Queries.GetTotalMemberStatistics
{
    public class GetTotalMemberStatisticsQueryHandler : IRequestHandler<GetTotalMemberStatisticsQuery, TotalMemberStatisticsDTO>
    {
        private readonly IMemberRepository _repository;

        public GetTotalMemberStatisticsQueryHandler(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<TotalMemberStatisticsDTO> Handle(GetTotalMemberStatisticsQuery request)
        {
            return await _repository.GetTotalMemberStatistics();
        }
    }
}
