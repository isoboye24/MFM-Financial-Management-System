using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetDeletedExpenditureLists
{
    public class GetDeletedExpendituresListQueryHandler : IRequestHandler<GetDeletedExpendituresListQuery, PaginatedDTO<DeletedExpenditureListDTO>>
    {
        private readonly IExpenditureRepository _repository;

        public GetDeletedExpendituresListQueryHandler(IExpenditureRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedExpenditureListDTO>> Handle(GetDeletedExpendituresListQuery request)
        {
            var expenditures = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var expenditureList = expenditures.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedExpenditureListDTO>
            {
                Items = expenditureList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
