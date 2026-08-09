using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureDetail
{
    public class GetExpenditureDetailQueryHandler : IRequestHandler<GetExpenditureDetailQuery, ExpenditureDetailDTO>
    {
        private readonly IExpenditureRepository _repository;
        public GetExpenditureDetailQueryHandler(IExpenditureRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExpenditureDetailDTO> Handle(GetExpenditureDetailQuery request)
        {
            var expenditure =await _repository.GetById(request.Id);

            if (expenditure is null)
            {
                throw new NotFoundException("Expenditure Not Found");
            }

            return expenditure.ToDTO();
        }
    }
}
