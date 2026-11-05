using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteByMemberIdLists
{
    internal static class MapperExtensions
    {
        public static MemberNoteByMemberIdListsDTO ToDTO(this MemberNote note)
        {
            return new MemberNoteByMemberIdListsDTO
            {
                Id = note.Id,
                NoteTitle = note.NoteTitle,
                Note = note.Note,
                MemberId = note.MemberId,
                CreationTime = note.CreationTime
            };
        }
    }
}
