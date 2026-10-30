using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MemberNotes.Queries.GetDeletedMemberNoteLists
{
    public class GetDeletedMemberNoteListsQueryHandler : IRequestHandler<GetDeletedMemberNoteListsQuery, PaginatedDTO<DeletedMemberNoteListsDTO>>
    {
        private readonly IMemberNoteRepository _repository;

        public GetDeletedMemberNoteListsQueryHandler(IMemberNoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedMemberNoteListsDTO>> Handle(GetDeletedMemberNoteListsQuery request)
        {
            var notes = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var notesList = notes.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedMemberNoteListsDTO>
            {
                Items = notesList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
