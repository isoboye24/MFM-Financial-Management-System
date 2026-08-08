using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Positions.Commands.RestorePosition
{
    public class RestorePositionCommandHandler : IRequestHandler<RestorePositionCommand>
    {
        private readonly IPositionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RestorePositionCommandHandler(IPositionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RestorePositionCommand request)
        {
            var position = await _repository.GetById(request.Id);

            if (position is null)
            {
                throw new NotFoundException("Position not found");
            }

            try
            {
                await _repository.Restore(position);
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
