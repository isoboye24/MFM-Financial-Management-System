using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Categories.Queries.GetCategoryLists
{
    internal static class MapperExtensions
    {
        internal static CategoryListsDTO ToDTO(this Category category)
        {
            return new CategoryListsDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
