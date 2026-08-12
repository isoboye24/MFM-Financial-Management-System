using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Givings.Queries.GetGivingLists
{
    public class GetGivingListQueryHandler : IRequestHandler<GetGivingListQuery, PaginatedDTO<GivingListsDTO>>
    {
        private readonly IGivingRepository _repository;
        public GetGivingListQueryHandler(IGivingRepository repository)
        {
            _repository = repository;
        }
        public async Task<PaginatedDTO<GivingListsDTO>> Handle(GetGivingListQuery request)
        {
            var givings = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var givingList = givings.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<GivingListsDTO>
            {
                Items = givingList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
