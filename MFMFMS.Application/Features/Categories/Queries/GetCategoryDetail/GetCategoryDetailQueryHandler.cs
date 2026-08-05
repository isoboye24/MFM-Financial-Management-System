using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailDTO>
    {
        private readonly ICategoryRepository _repository;
        public GetCategoryDetailQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryDetailDTO> Handle(GetCategoryDetailQuery request)
        {
            var category = await _repository.GetById(request.Id);

            if (category is null)
            {
                throw new NotFoundException("Category is not found");
            }

            return category.ToDTO();
        }
    }
}
