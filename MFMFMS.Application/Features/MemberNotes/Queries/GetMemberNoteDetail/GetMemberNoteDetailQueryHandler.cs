using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteDetail
{
    public class GetMemberNoteDetailQueryHandler : IRequestHandler<GetMemberNoteDetailQuery, MemberNoteDetailDTO>
    {
        private readonly IMemberNoteRepository _repository;

        public GetMemberNoteDetailQueryHandler(IMemberNoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<MemberNoteDetailDTO> Handle(GetMemberNoteDetailQuery request)
        {
            var memberNote = await _repository.GetById(request.Id);

            if (memberNote == null)
            {
                throw new NotFoundException("Member note not found");
            }
            return memberNote.ToDTO();
        }
    }
}
