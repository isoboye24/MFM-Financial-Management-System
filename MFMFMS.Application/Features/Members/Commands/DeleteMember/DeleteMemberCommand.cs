using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Commands.DeleteMember
{
    public class DeleteMemberCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
