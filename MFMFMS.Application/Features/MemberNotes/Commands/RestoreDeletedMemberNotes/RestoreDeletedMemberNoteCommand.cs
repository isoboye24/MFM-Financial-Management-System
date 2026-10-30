using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.RestoreDeletedMemberNotes
{
    public class RestoreDeletedMemberNoteCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
