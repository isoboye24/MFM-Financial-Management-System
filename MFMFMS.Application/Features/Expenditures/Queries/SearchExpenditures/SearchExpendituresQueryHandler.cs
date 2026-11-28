using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Expenditures.Queries.SearchExpenditures
{
    public class SearchExpendituresQueryHandler: IRequestHandler<SearchExpendituresQuery, PaginatedDTO<ExpenditureListDTO>>
    {
        private readonly IExpenditureRepository _repository;

        public SearchExpendituresQueryHandler(IExpenditureRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<ExpenditureListDTO>> Handle(SearchExpendituresQuery request)
        {
            var (items, totalCount) = await _repository.Search(request.SearchTerm, request.Page, request.RecordsPerPage);

            var expenditureList = items.Select(x => x.ToDTO()).ToList();

            return new PaginatedDTO<ExpenditureListDTO>
            {
                Items = expenditureList,
                TotalAmountOfRecords = totalCount
            };
        }

    }
}
