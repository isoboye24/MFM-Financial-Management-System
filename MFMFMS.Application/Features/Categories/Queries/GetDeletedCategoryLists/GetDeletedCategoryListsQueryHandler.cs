using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Categories.Queries.GetCategoryLists;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Categories.Queries.GetDeletedCategoryLists
{
    public class GetDeletedCategoryListsQueryHandler : IRequestHandler<GetDeletedCategoryListsQuery, PaginatedDTO<DeletedCategoryListsDTO>>
    {
        private readonly ICategoryRepository _repository;
        public GetDeletedCategoryListsQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<PaginatedDTO<DeletedCategoryListsDTO>> Handle(GetDeletedCategoryListsQuery request)
        {
            var categories = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var categoryList = categories.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedCategoryListsDTO>
            {
                Items = categoryList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
