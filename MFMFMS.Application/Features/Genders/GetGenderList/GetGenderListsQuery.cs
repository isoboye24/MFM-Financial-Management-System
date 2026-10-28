using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Genders.GetGenderList
{
    public class GetGenderListsQuery : GendersFilterDTO, IRequest<PaginatedDTO<GenderListsDTO>>
    {
    }
}
