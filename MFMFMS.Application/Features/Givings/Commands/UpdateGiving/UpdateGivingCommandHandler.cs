using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Commands.UpdateGiving
{
    public class UpdateGivingCommandHandler : IRequestHandler<UpdateGivingCommand>
    {
        private readonly IGivingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateGivingCommandHandler(IGivingRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateGivingCommand request)
        {
            var giving = await _repository.GetGivingDetail(request.Id);

            if (giving is null)
            {
                throw new NotFoundException("Giving is required");
            }

            giving.UpdateAmount(request.Amount);
            giving.UpdateDate(request.Date);
            giving.UpdateSummary(request.Summary);
            giving.UpdateMeetingId(request.MeetingId);
            giving.UpdateCategoryId(request.CategoryId);

            try
            {
                await _repository.Update(giving);
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
