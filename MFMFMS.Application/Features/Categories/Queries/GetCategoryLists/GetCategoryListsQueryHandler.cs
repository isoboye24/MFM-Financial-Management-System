using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Categories.Queries.GetCategoryLists
{
    public class GetCategoryListsQueryHandler : IRequestHandler<GetCategoryListsQuery, PaginatedDTO<CategoryListsDTO>>
    {
        private readonly ICategoryRepository _repository;
        public GetCategoryListsQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<CategoryListsDTO>> Handle(GetCategoryListsQuery request)
        {
            var categories = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var categoryList = categories.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<CategoryListsDTO>
            {
                Items = categoryList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
