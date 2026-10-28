using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Genders.GetGenderList
{
    public class GetGenderListsQueryHandler : IRequestHandler<GetGenderListsQuery, PaginatedDTO<GenderListsDTO>>
    {
        private readonly IGenderRepository _repository;
        public GetGenderListsQueryHandler(IGenderRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<GenderListsDTO>> Handle(GetGenderListsQuery request)
        {
            var genders = await _repository.GetFiltered(request);
            var genderLists = genders.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<GenderListsDTO>
            {
                Items = genderLists,
            };

            return paginatedResult;
        }
    }
}
