using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists
{
    public class GetDeletedGivingListQuery : DeletedGivingsFilterDTO, IRequest<PaginatedDTO<DeletedGivingListsDTO>>
    {
    }
}
