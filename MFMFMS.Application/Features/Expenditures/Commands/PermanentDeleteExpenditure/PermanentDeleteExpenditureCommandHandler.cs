using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Commands.PermanentDeleteExpenditure
{
    public class PermanentDeleteExpenditureCommandHandler : IRequestHandler<PermanentDeleteExpenditureCommand>
    {
        private readonly IExpenditureRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PermanentDeleteExpenditureCommandHandler(IExpenditureRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermanentDeleteExpenditureCommand request)
        {
            var expenditure = await _repository.GetById(request.Id);
            if (expenditure is null)
            {
                throw new NotFoundException("Expenditure not found");
            }

            try
            {
                await _repository.DeletePermanently(expenditure);
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