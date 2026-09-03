using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.PermanentDeleteMeetingCategory
{
    public class PermanentDeleteMeetingCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
