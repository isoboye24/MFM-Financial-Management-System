namespace MFMFMS.Application.Features.MemberNotes.Queries.GetDeletedMemberNoteLists
{
    public class DeletedMemberNotesFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? NoteTitle { get; set; }
    }
}
