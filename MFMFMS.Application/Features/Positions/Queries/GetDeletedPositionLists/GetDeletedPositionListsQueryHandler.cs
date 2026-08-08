using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Categories.Queries.GetDeletedCategoryLists;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Positions.Queries.GetDeletedPositionLists
{
    public class GetDeletedPositionListsQueryHandler : IRequestHandler<GetDeletedPositionListsQuery, PaginatedDTO<DeletedPositionListsDTO>>
    {
        private readonly IPositionRepository _repository;
        public GetDeletedPositionListsQueryHandler(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedPositionListsDTO>> Handle(GetDeletedPositionListsQuery request)
        {
            var positions = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var positionList = positions.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedPositionListsDTO>
            {
                Items = positionList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
