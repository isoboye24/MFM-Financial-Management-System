using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Categories.Queries.GetCategoryLists
{
    public class GetCategoryListsQuery : CategoriesFilterDTO, IRequest<PaginatedDTO<CategoryListsDTO>>
    {
    }
}
