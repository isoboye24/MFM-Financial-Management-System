using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetDeletedMeetingCategoryLists
{
    internal static class MapperExtensions
    {
        internal static DeletedMeetingCategoryListsDTO ToDTO(this MeetingCategory category)
        {
            return new DeletedMeetingCategoryListsDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
