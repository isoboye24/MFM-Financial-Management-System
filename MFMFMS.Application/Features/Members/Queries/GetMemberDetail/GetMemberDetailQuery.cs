using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Queries.GetMemberDetail
{
    public class GetMemberDetailQuery : IRequest<MemberDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
