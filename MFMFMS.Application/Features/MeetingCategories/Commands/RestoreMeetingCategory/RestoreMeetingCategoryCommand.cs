using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.RestoreMeetingCategory
{
    public class RestoreMeetingCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
