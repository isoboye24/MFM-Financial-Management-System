using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Positions.Queries.GetPositionDetail
{
    public class GetPositionDetailQueryHandler : IRequestHandler<GetPositionDetailQuery, PositionDetailDTO>
    {
        private readonly IPositionRepository _repository;

        public GetPositionDetailQueryHandler(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PositionDetailDTO> Handle(GetPositionDetailQuery request)
        {
            var position = await _repository.GetById(request.Id);

            if (position is null)
            {
                throw new NotFoundException("Position is not found");
            }

            return position.ToDTO();
        }
    }
}
