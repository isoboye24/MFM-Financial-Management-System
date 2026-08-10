using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Members.Queries.GetMemberLists
{
    public class GetMemberListQueryHandler : IRequestHandler<GetMemberListQuery, PaginatedDTO<MemberListsDTO>>
    {
        private readonly IMemberRepository _repository;
        public GetMemberListQueryHandler(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<MemberListsDTO>> Handle(GetMemberListQuery request)
        {
            var members = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var memberList = members.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<MemberListsDTO>
            {
                Items = memberList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;


        }
    }
}
