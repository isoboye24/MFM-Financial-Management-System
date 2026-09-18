using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Givings.Queries.GetGivingListsByMonthAndYear
{
    public class GetGivingListsByMonthAndYearQueryHander : IRequestHandler<GetGivingListsByMonthAndYearQuery, PaginatedDTO<GivingListsByMonthAndYearDTO>>
    {
        private readonly IGivingRepository _repository;
        public GetGivingListsByMonthAndYearQueryHander(IGivingRepository repository)
        {
            _repository = repository;
        }
        

        public async Task<PaginatedDTO<GivingListsByMonthAndYearDTO>> Handle(GetGivingListsByMonthAndYearQuery request)
        {
            var givings = await _repository
                .GetFilteredByMonthAndYear(request);

            var givingList = givings
                .Select(p => p.ToDTO())
                .ToList();

            var paginatedResult =
                new PaginatedDTO<GivingListsByMonthAndYearDTO>
                {
                    Items = givingList
                };

            return paginatedResult;
        }
    }
}
