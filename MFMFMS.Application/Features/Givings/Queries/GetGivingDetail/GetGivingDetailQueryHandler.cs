using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Queries.GetGivingDetail
{
    public class GetGivingDetailQueryHandler : IRequestHandler<GetGivingDetailQuery, GivingDetailDTO>
    {
        private readonly IGivingRepository _repository;
        public GetGivingDetailQueryHandler(IGivingRepository repository)
        {
            _repository = repository;
        }

        public async Task<GivingDetailDTO> Handle(GetGivingDetailQuery request)
        {
            var giving = await _repository.GetGivingDetail(request.Id);

            if (giving is null)
            {
                throw new NotFoundException("Giving is not found");
            }

            return giving.ToDTO();
        }
    }
}
