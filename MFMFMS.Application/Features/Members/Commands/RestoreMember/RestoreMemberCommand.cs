using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Commands.RestoreMember
{
    public class RestoreMemberCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
