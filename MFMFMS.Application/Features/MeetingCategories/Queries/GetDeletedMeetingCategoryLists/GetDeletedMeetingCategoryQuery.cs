using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetDeletedMeetingCategoryLists
{
    public class GetDeletedMeetingCategoryQuery : DeletedMeetingCategoriesFilterDTO, IRequest<PaginatedDTO<DeletedMeetingCategoryListsDTO>>
    {
    }
}
