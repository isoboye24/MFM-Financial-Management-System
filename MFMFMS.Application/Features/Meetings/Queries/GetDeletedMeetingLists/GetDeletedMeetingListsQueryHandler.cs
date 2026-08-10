using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Meetings.Queries.GetDeletedMeetingLists
{
    public class GetDeletedMeetingListsQueryHandler : IRequestHandler<GetDeletedMeetingListsQuery, PaginatedDTO<DeletedMeetingListsDTO>>
    {
        private readonly IMeetingRepository _repository;
        public GetDeletedMeetingListsQueryHandler(IMeetingRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedMeetingListsDTO>> Handle(GetDeletedMeetingListsQuery request)
        {
            var meetings = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var meetingList = meetings.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedMeetingListsDTO>
            {
                Items = meetingList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
