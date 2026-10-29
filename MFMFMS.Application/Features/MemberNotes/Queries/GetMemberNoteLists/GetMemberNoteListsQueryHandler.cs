using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteLists
{
    public class GetMemberNoteListsQueryHandler : IRequestHandler<GetMemberNoteListsQuery, PaginatedDTO<MemberNoteListsDTO>>
    {
        private readonly IMemberNoteRepository _repository;

        public GetMemberNoteListsQueryHandler(IMemberNoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<MemberNoteListsDTO>> Handle(GetMemberNoteListsQuery request)
        {
            var notes = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var noteList = notes.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<MemberNoteListsDTO>
            {
                Items = noteList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
