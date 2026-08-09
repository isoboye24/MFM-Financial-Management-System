using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Commands.DeleteExpenditure
{
    public class DeleteExpenditureCommandHandler : IRequestHandler<DeleteExpenditureCommand>
    {
        private readonly IExpenditureRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteExpenditureCommandHandler(IExpenditureRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteExpenditureCommand request)
        {
            var expenditure = await _repository.GetById(request.Id);
            if (expenditure is null)
            {
                throw new NotFoundException("Expenditure not found");
            }

            try
            {
               await _repository.Delete(expenditure);
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
