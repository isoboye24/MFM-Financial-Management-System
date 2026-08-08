using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Positions.Queries.GetPositionLists
{
    public class GetPositionListsQueryHandler : IRequestHandler<GetPositionListsQuery, PaginatedDTO<PositionListsDTO>>
    {
        private readonly IPositionRepository _repository;
        public GetPositionListsQueryHandler(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<PositionListsDTO>> Handle(GetPositionListsQuery request)
        {
            var positions = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var positionList = positions.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<PositionListsDTO>
            {
                Items = positionList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
