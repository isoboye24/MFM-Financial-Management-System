using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Positions.Commands.PermanentDeletePosition
{
    public class PermanentDeletePositionCommandHandler : IRequestHandler<PermanentDeletePositionCommand>
    {
        private readonly IPositionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PermanentDeletePositionCommandHandler(IPositionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermanentDeletePositionCommand request)
        {
            var position = await _repository.GetById(request.Id);

            if (position is null)
            {
                throw new NotFoundException("Position not found");
            }

            try
            {
                await _repository.DeletePermanently(position);
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
