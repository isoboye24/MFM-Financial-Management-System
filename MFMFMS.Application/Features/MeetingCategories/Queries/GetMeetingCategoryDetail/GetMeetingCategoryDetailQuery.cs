using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetMeetingCategoryDetail
{
    public class GetMeetingCategoryDetailQuery : IRequest<MeetingCategoryDetailDTO>
    {
        public required Guid Id { get; set; }    
    }
}
