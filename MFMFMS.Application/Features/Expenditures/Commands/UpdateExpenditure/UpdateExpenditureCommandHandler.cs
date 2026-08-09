using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Commands.UpdateExpenditure
{
    public class UpdateExpenditureCommandHandler : IRequestHandler<UpdateExpenditureCommand>
    {
        private readonly IExpenditureRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateExpenditureCommandHandler(IExpenditureRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateExpenditureCommand request)
        {
            var expenditure = await _repository.GetById(request.Id);

            if (expenditure == null)
            {
                throw new NotFoundException("Expenditure not found.");
            }

            expenditure.UpdateSummary(request.Summary);
            expenditure.UpdateAmount(request.Amount);
            expenditure.UpdateDate(request.Date);

            try { 
                await _repository.Update(expenditure);
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
