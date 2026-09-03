using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetMeetingCategoryLists
{
    public class GetMeetingCategoryListQueryHandler : IRequestHandler<GetMeetingCategoryListQuery, PaginatedDTO<MeetingCategoryListDTO>>
    {
        private readonly IMeetingCategoryRepository _repository;

        public GetMeetingCategoryListQueryHandler(IMeetingCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<MeetingCategoryListDTO>> Handle(GetMeetingCategoryListQuery request)
        {
            var categories = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var categoryList = categories.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<MeetingCategoryListDTO>
            {
                Items = categoryList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
