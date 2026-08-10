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

        public RestoreMeetingCommandHandler(IMeetingRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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
