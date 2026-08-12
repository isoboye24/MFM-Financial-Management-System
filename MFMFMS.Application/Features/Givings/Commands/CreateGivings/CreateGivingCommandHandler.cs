using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Givings.Commands.CreateGivings
{
    public class CreateGivingCommandHandler : IRequestHandler<CreateGivingCommand, Guid>
    {
        private readonly IGivingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateGivingCommandHandler(IGivingRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateGivingCommand request)
        {
            bool exists = await _repository.Exists(request.MeetingId, request.CategoryId);

            if (exists)
            {
                throw new CustomValidationException("The giving already exists.");
            }
            else
            {
                var giving = new Giving(request.Amount, request.Date, request.Summary, request.CategoryId, request.MeetingId);
                try
                {
                    var result = await _repository.Add(giving);
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
