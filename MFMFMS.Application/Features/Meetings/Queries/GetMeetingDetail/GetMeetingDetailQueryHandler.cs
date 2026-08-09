using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingDetail
{
    public class GetMeetingDetailQueryHandler : IRequestHandler<GetMeetingDetailQuery, MeetingDetailDTO>
    {
        private readonly IMeetingRepository _repository;

        public GetMeetingDetailQueryHandler(IMeetingRepository repository)
        {
            _repository = repository;
        }

        public async Task<MeetingDetailDTO> Handle(GetMeetingDetailQuery request)
        {
            var meeting = await _repository.GetById(request.Id);

            if (meeting is null)
            {
                throw new NotFoundException("Meeting not found");
            }

            return meeting.ToDTO();
        }
    }
}
