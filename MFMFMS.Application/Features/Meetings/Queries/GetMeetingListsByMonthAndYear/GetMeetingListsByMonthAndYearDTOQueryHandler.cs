using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingListsByMonthAndYear
{
    public class GetMeetingListsByMonthAndYearDTOQueryHandler : IRequestHandler<GetMeetingListsByMonthAndYearDTOQuery, PaginatedDTO<MeetingListsByMonthAndYearDTO>>
    {
        private readonly IMeetingRepository _repository;

        public GetMeetingListsByMonthAndYearDTOQueryHandler(IMeetingRepository meetingRepository)
        {
            _repository = meetingRepository;
        }

        public async Task<PaginatedDTO<MeetingListsByMonthAndYearDTO>> Handle(GetMeetingListsByMonthAndYearDTOQuery request)
        {
            var meetings = await _repository.GetFilteredByMonthAndYear(request);

            var meetingList = meetings
                .Select(p => p.ToDTO())
                .ToList();

            var paginatedResult =
                new PaginatedDTO<MeetingListsByMonthAndYearDTO>
                {
                    Items = meetingList
                };

            return paginatedResult;
        }
    }
}
