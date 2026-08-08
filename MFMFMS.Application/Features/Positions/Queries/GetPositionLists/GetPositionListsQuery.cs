using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Positions.Queries.GetPositionLists
{
    public class GetPositionListsQuery : PositionFilterDTO, IRequest<PaginatedDTO<PositionListsDTO>>
    {
    }
}
