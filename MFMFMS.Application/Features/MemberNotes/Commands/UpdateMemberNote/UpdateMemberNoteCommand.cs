using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.UpdateMemberNote
{
    public class UpdateMemberNoteCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string NoteTitle { get; set; }
        public required string Note { get; set; }
        public required Guid MemberId { get; set; }
    }
}
