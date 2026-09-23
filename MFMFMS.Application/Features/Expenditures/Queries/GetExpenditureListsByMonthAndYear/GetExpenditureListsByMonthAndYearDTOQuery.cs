using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureListsByMonthAndYear
{
    public class GetExpenditureListsByMonthAndYearDTOQuery : ExpenditureListsByMonthAndYearFilterDTO, IRequest<PaginatedDTO<ExpenditureListsByMonthAndYearDTO>>
    {
    }
}
