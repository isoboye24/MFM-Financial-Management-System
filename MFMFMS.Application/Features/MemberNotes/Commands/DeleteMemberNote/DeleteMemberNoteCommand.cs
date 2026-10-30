using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.DeleteMemberNote
{
    public class DeleteMemberNoteCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
