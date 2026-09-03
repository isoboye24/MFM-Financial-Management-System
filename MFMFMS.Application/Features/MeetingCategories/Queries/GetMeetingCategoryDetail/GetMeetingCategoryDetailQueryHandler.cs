using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetMeetingCategoryDetail
{
    public class GetMeetingCategoryDetailQueryHandler : IRequestHandler<GetMeetingCategoryDetailQuery, MeetingCategoryDetailDTO>
    {
        private readonly IMeetingCategoryRepository _repository;

        public GetMeetingCategoryDetailQueryHandler(IMeetingCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<MeetingCategoryDetailDTO> Handle(GetMeetingCategoryDetailQuery request)
        {
            var category = await _repository.GetById(request.Id);

            if (category is null)
            {
                throw new NotFoundException("Category is not found");
            }

            return category.ToDTO();
        }
    }
}
