using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Categories.Queries.GetDeletedCategoryLists
{
    public class GetDeletedCategoryListsQuery : DeletedCategoriesFilterDTO, IRequest<PaginatedDTO<DeletedCategoryListsDTO>>
    {
    }
}
