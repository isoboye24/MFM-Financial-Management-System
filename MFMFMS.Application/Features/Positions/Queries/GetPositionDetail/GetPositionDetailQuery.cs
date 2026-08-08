using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Positions.Queries.GetPositionDetail
{
    public class GetPositionDetailQuery : IRequest<PositionDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
