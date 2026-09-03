using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.DeleteMeetingCategory
{
    public class DeleteMeetingCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }    
    }
}
