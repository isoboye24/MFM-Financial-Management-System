using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists
{
    public class GetExpenditureListsQueryHandler : IRequestHandler<GetExpenditureListsQuery, PaginatedDTO<ExpenditureListDTO>>
    {
        private readonly IExpenditureRepository _repository;
        public GetExpenditureListsQueryHandler(IExpenditureRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<ExpenditureListDTO>> Handle(GetExpenditureListsQuery request)
        {
            var expenditures = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var expenditureList = expenditures.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<ExpenditureListDTO>
            {
                Items = expenditureList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
