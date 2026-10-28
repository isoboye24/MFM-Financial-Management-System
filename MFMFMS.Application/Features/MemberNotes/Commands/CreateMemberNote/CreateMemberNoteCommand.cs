using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.CreateMemberNote
{
    public class CreateMemberNoteCommand : IRequest<Guid>
    {
        public required string NoteTitle { get; set; }
        public required string Note { get; set; }
        public required Guid MemberId { get; set; }
    }
}
