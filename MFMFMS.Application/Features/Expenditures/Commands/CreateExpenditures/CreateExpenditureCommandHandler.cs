using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Expenditures.Commands.CreateExpenditures
{
    public class CreateExpenditureCommandHandler : IRequestHandler<CreateExpenditureCommand, Guid>
    {
        private readonly IExpenditureRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateExpenditureCommandHandler(IExpenditureRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateExpenditureCommand request)
        {
            bool exists = await _repository.Exists(request.Summary, request.Date);

            if (exists)
            {
                throw new CustomValidationException("The Expenditure already exists.");
            }
            else
            {
                var expenditure = new Expenditure(request.Amount, request.Date, request.Summary);

                try
                {
                    var result = await _repository.Add(expenditure);
                    await _unitOfWork.Commit();
                    return result.Id;
                }
                catch (Exception)
                {
                    await _unitOfWork.Rollback();
                    throw;
                }
            }            
        }
    }
}
