using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Queries.GetGivingDetail
{
    public class GetGivingDetailQuery : IRequest<GivingDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
