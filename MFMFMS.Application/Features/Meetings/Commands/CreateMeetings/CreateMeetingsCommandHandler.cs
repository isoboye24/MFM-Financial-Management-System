using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Meetings.Commands.CreateMeetings
{
    public class CreateMeetingsCommandHandler : IRequestHandler<CreateMeetingsCommand, Guid>
    {
        private readonly IMeetingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateMeetingsCommandHandler(IMeetingRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateMeetingsCommand request)
        {
            bool exists = await _repository.Exists(request.Minister, request.Date);

            if (exists)
            {
                throw new CustomValidationException("The Meeting already exists.");
            }
            else
            {
                var meeting = new Meeting(request.Date, request.Summary, request.MessageTitle, request.Minister, request.NoOfMaleAttendance, request.NoOfFemaleAttendance,
                    request.NoOfChildrenAttendance);

                try
                {
                    var result = await _repository.Add(meeting);
                    await _unitOfWork.Commit();
                    return result.Id;
                }
                catch (Exception)
                {
                    await _unitOfWork.Rollback();
                    throw;
                }
            }                
        }
    }
}
