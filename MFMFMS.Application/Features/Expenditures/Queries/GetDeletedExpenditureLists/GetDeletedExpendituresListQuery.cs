using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetDeletedExpenditureLists
{
    public class GetDeletedExpendituresListQuery : DeletedExpendituresFilterDTO, IRequest<PaginatedDTO<DeletedExpenditureListDTO>>
    {
    }
}
