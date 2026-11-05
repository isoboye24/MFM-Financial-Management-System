namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteByMemberIdLists
{
    public class MemberNoteByMemberIdListsDTO
    {
        public Guid Id { get; set; }
        public required string NoteTitle { get; set; }
        public required string Note { get; set; }
        public Guid MemberId { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}
