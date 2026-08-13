using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Commands.RestoreGiving
{
    public class RestoreGivingCommandHandler : IRequestHandler<RestoreGivingCommand>
    {
        private readonly IGivingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RestoreGivingCommandHandler(IGivingRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RestoreGivingCommand request)
        {
            var giving = await _repository.GetGivingDetail(request.Id);

            if (giving is null)
            {
                throw new NotFoundException("Giving not found");
            }

            try
            {
                await _repository.Restore(giving);
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
