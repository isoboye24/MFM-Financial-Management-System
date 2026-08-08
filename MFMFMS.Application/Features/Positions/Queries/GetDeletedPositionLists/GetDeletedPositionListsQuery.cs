using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Positions.Queries.GetDeletedPositionLists
{
    public class GetDeletedPositionListsQuery : DeletedPositionsFilterDTO, IRequest<PaginatedDTO<DeletedPositionListsDTO>>
    {
    }
}
