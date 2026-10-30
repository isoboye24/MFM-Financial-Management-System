namespace MFMFMS.Application.Features.MemberNotes.Queries.GetDeletedMemberNoteLists
{
    internal static class MapperExtensions
    {
        internal static DeletedMemberNoteListsDTO ToDTO(this Domain.Entities.MemberNote memberNote)
        {
            return new DeletedMemberNoteListsDTO
            {
                Id = memberNote.Id,
                NoteTitle = memberNote.NoteTitle,
                Note = memberNote.Note,
                MemberId = memberNote.MemberId
            };
        }
    }
}
