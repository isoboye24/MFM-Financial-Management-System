using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteByMemberIdLists
{
    public class GetMemberNoteByMemberIdListsQueryHandler : IRequestHandler<GetMemberNoteByMemberIdListsQuery, PaginatedDTO<MemberNoteByMemberIdListsDTO>>
    {
        private readonly IMemberNoteRepository _repository;

        public GetMemberNoteByMemberIdListsQueryHandler(IMemberNoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<MemberNoteByMemberIdListsDTO>> Handle(GetMemberNoteByMemberIdListsQuery request)
        {
            var allNotes = await _repository.GetAll();

            var notes = allNotes
                .Where(x => x.MemberId == request.MemberId)
                .OrderByDescending(x => x.CreationTime)
                .ToList();

            var totalAmountOfRecords = notes.Count;

            var noteList = notes
                .Select(x => x.ToDTO())
                .ToList();

            return new PaginatedDTO<MemberNoteByMemberIdListsDTO>
            {
                Items = noteList,
                TotalAmountOfRecords = totalAmountOfRecords
            };
        }
    }
}
