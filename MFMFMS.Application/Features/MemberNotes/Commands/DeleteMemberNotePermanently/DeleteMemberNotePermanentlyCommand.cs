using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.DeleteMemberNotePermanently
{
    public class DeleteMemberNotePermanentlyCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
