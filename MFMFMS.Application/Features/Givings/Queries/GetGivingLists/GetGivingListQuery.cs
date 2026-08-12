using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Givings.Queries.GetGivingLists
{
    public class GetGivingListQuery : GivingsFilterDTO, IRequest<PaginatedDTO<GivingListsDTO>>
    {
    }
}
