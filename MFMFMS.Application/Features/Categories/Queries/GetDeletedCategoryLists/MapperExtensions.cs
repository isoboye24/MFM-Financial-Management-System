using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Categories.Queries.GetDeletedCategoryLists
{
    internal static class MapperExtensions
    {
        internal static DeletedCategoryListsDTO ToDTO(this Category category)
        {
            return new DeletedCategoryListsDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
