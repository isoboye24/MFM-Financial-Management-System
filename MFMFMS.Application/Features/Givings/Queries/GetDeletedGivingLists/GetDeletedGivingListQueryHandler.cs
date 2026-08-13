using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists
{
    public class GetDeletedGivingListQueryHandler : IRequestHandler<GetDeletedGivingListQuery, PaginatedDTO<DeletedGivingListsDTO>>
    {
        private readonly IGivingRepository _repository;
        public GetDeletedGivingListQueryHandler(IGivingRepository repository)
        {
            _repository = repository;
        }
        public async Task<PaginatedDTO<DeletedGivingListsDTO>> Handle(GetDeletedGivingListQuery request)
        {
            var givings = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var givingList = givings.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedGivingListsDTO>
            {
                Items = givingList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
