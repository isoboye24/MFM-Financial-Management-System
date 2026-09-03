using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.CreateMeetingCategories
{
    public class CreateMeetingCategoryCommand : IRequest<Guid>
    {
        public required string Name { get; set; }    
    }
}