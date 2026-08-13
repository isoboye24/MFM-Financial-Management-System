using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Commands.PermanentDeleteGiving
{
    public class PermanentDeleteGivingCommandHandler : IRequestHandler<PermanentDeleteGivingCommand>
    {
        private readonly IGivingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PermanentDeleteGivingCommandHandler(IGivingRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermanentDeleteGivingCommand request)
        {
            var giving = await _repository.GetGivingDetail(request.Id);

            if (giving is null)
            {
                throw new NotFoundException("Giving not found");
            }

            try
            {
                await _repository.DeletePermanently(giving);
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
