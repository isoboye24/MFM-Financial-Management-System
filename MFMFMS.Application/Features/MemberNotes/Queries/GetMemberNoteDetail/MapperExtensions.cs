namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteDetail
{
    internal static class MapperExtensions
    {
        internal static MemberNoteDetailDTO ToDTO(this Domain.Entities.MemberNote memberNote)
        {
            return new MemberNoteDetailDTO
            {
                Id = memberNote.Id,
                NoteTitle = memberNote.NoteTitle,
                Note = memberNote.Note,
                MemberId = memberNote.MemberId
            };
        }
    }
}
