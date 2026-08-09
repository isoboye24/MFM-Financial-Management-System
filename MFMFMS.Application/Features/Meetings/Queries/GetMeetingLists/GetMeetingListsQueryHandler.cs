using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Categories.Queries.GetCategoryLists;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingLists
{
    public class GetMeetingListsQueryHandler : IRequestHandler<GetMeetingListsQuery, PaginatedDTO<MeetingListsDTO>>
    {
        private readonly IMeetingRepository _repository;

        public GetMeetingListsQueryHandler(IMeetingRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<MeetingListsDTO>> Handle(GetMeetingListsQuery request)
        {
            var meetings = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var meetingList = meetings.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<MeetingListsDTO>
            {
                Items = meetingList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
