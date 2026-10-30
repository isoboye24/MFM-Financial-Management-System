namespace MFMFMS.Application.Features.MemberNotes.Queries.GetDeletedMemberNoteLists
{
    public class DeletedMemberNoteListsDTO
    {
        public Guid Id { get; set; }
        public string NoteTitle { get; set; } = null!;
        public string Note { get; set; } = null!;
        public Guid MemberId { get; set; }
    }
}
