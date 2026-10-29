namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteLists
{
    internal static class MapperExtensions
    {
        internal static MemberNoteListsDTO ToDTO(this Domain.Entities.MemberNote memberNote)
        {
            return new MemberNoteListsDTO
            {
                Id = memberNote.Id,
                NoteTitle = memberNote.NoteTitle,
                Note = memberNote.Note,
                MemberId = memberNote.MemberId
            };
        }
    }
}
