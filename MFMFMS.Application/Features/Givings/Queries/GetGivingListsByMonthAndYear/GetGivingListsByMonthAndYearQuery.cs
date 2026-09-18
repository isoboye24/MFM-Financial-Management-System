using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Givings.Queries.GetGivingListsByMonthAndYear
{
    public class GetGivingListsByMonthAndYearQuery : GivingListsByMonthAndYearFilterDTO, IRequest<PaginatedDTO<GivingListsByMonthAndYearDTO>>
    {
    }
}
