using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureListsByMonthAndYear
{
    public class GetExpenditureListsByMonthAndYearDTOQueryHandler : IRequestHandler<GetExpenditureListsByMonthAndYearDTOQuery, PaginatedDTO<ExpenditureListsByMonthAndYearDTO>>
    {
        private readonly IExpenditureRepository _repository;

        public GetExpenditureListsByMonthAndYearDTOQueryHandler(IExpenditureRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<ExpenditureListsByMonthAndYearDTO>> Handle(GetExpenditureListsByMonthAndYearDTOQuery request)
        {
            var expenditures = await _repository
                .GetFilteredByMonthAndYear(request);

            var expenditureList = expenditures
                .Select(p => p.ToDTO())
                .ToList();

            var paginatedResult =
                new PaginatedDTO<ExpenditureListsByMonthAndYearDTO>
                {
                    Items = expenditureList
                };

            return paginatedResult;
        }
    }
}
