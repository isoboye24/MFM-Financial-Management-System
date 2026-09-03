using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetMeetingCategoryLists
{
    public class GetMeetingCategoryListQuery : MeetingCategoriesFilterDTO, IRequest<PaginatedDTO<MeetingCategoryListDTO>>
    {
    }
}
