using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Positions.Commands.UpdatePosition
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand>
    {
        private readonly IPositionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePositionCommandHandler(IPositionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePositionCommand request)
        {
            var position = await _repository.GetById(request.Id);

            if (position is null)
            {
                throw new NotFoundException("Position is required");
            }
            position.UpdateName(request.Name);

            try
            {
                await _repository.Update(position);
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
