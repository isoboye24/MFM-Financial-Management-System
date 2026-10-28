namespace MFMFMS.API.DTOs.MemberNotes
{
    public class CreateMemberNoteDTO
    {
        public required string NoteTitle { get; set; }
        public required string Note { get; set; }
        public required Guid MemberId { get; set; }
    }
}
