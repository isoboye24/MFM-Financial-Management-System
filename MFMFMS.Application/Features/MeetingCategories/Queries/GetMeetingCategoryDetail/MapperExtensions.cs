using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetMeetingCategoryDetail
{
    internal static class MapperExtensions
    {
        public static MeetingCategoryDetailDTO ToDTO(this MeetingCategory category)
        {
            return new MeetingCategoryDetailDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
