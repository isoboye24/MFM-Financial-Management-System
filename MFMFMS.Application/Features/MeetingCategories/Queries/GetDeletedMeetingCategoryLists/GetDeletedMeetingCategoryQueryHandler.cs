using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetDeletedMeetingCategoryLists
{
    public class GetDeletedMeetingCategoryQueryHandler : IRequestHandler<GetDeletedMeetingCategoryQuery, PaginatedDTO<DeletedMeetingCategoryListsDTO>>
    {
        private readonly IMeetingCategoryRepository _repository;

        public GetDeletedMeetingCategoryQueryHandler(IMeetingCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedMeetingCategoryListsDTO>> Handle(GetDeletedMeetingCategoryQuery request)
        {
            var categories = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var categoryList = categories.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedMeetingCategoryListsDTO>
            {
                Items = categoryList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
