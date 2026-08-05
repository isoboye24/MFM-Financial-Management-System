using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Categories.Queries.GetCategoryDetail
{
    internal static class MapperExtensions
    {
        internal static CategoryDetailDTO ToDTO(this Category category)
        {
            return new CategoryDetailDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
