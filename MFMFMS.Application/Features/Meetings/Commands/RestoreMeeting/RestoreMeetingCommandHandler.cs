using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Meetings.Commands.RestoreMeeting
{
    public class RestoreMeetingCommandHandler : IRequestHandler<RestoreMeetingCommand>
    {
        private readonly IMeetingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGivingRepository _givingRepository;

        public RestoreMeetingCommandHandler(IMeetingRepository repository, IUnitOfWork unitOfWork, IGivingRepository givingRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _givingRepository = givingRepository;
        }

        public async Task Handle(RestoreMeetingCommand request)
        {
            var meeting = await _repository.GetById(request.Id);

            if (meeting is null)
            {
                throw new NotFoundException("Meeting not found");
            }

            try
            {
                var givings = await _givingRepository.GetByMeetingId(meeting.Id);

                foreach (var giving in givings)
                {
                    await _givingRepository.Restore(giving);
                }

                await _repository.Restore(meeting);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
