using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetMeetingCategoryLists
{
    internal static class MapperExtensions
    {
        internal static MeetingCategoryListDTO ToDTO(this MeetingCategory meetingCategory)
        {
            return new MeetingCategoryListDTO
            {
                Id = meetingCategory.Id,
                Name = meetingCategory.Name
            };
        }
    }
}
