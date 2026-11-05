namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteByMemberIdLists
{
    public class MemberNoteByMemberIdFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? NoteTitle { get; set; }
        public Guid MemberId { get; set; }
    }
}
