using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteDetail
{
    public class GetMemberNoteDetailQuery : IRequest<MemberNoteDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
