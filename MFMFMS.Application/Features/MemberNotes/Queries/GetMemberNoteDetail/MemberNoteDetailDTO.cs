namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteDetail
{
    public class MemberNoteDetailDTO
    {
        public Guid Id { get; set; }
        public string NoteTitle { get; set; } = null!;
        public string Note { get; set; } = null!;
        public Guid MemberId { get; set; }
    }
}
