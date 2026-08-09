using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Commands.RestoreExpenditure
{
    public class RestoreExpenditureCommandHandler : IRequestHandler<RestoreExpenditureCommand>
    {
        private readonly IExpenditureRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RestoreExpenditureCommandHandler(IExpenditureRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RestoreExpenditureCommand request)
        {
            var expenditure = await _repository.GetById(request.Id);
            if (expenditure is null)
            {
                throw new NotFoundException("Expenditure not found");
            }

            try
            {
                await _repository.Restore(expenditure);
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
