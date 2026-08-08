using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Months.GetMonthsList
{
    public class GetMonthListsQueryHandler : IRequestHandler<GetMonthListsQuery, PaginatedDTO<MonthListsDTO>>
    {
        private readonly IMonthRepository _repository;
        public GetMonthListsQueryHandler(IMonthRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<MonthListsDTO>> Handle(GetMonthListsQuery request)
        {
            var months = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var categoryList = months.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<MonthListsDTO>
            {
                Items = categoryList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
