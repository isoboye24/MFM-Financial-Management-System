using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Members.Queries.GetDeletedMemberLists
{
    public class GetDeletedMemberListQueryHandler : IRequestHandler<GetDeletedMemberListQuery, PaginatedDTO<DeletedMemberListDTO>>
    {
        private readonly IMemberRepository _repository;
        public GetDeletedMemberListQueryHandler(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedMemberListDTO>> Handle(GetDeletedMemberListQuery request)
        {
            var members = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var memberList = members.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedMemberListDTO>
            {
                Items = memberList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
