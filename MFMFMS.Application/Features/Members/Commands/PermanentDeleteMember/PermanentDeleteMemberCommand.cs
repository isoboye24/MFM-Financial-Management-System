using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Commands.PermanentDeleteMember
{
    public class PermanentDeleteMemberCommand : IRequest
    {
        public required Guid Id { get; set; }    
    }
}
