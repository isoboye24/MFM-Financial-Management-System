using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery : IRequest<CategoryDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
