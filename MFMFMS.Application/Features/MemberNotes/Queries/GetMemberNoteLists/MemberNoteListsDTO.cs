namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteLists
{
    public class MemberNoteListsDTO
    {
        public Guid Id { get; set; }
        public required string NoteTitle { get; set; }
        public required string Note { get; set; }
        public Guid MemberId { get; set; }
    }
}
