using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists
{
    public class GetExpenditureListsQuery : ExpendituresFilterDTO, IRequest<PaginatedDTO<ExpenditureListDTO>>
    {
    }
}
