using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Months.GetMonthsList
{
    public class GetMonthListsQuery : MonthsFilterDTO, IRequest<PaginatedDTO<MonthListsDTO>>
    {
    }
}
