using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Expenditures.Queries.SearchExpenditures
{
    public class SearchExpendituresQuery : IRequest<PaginatedDTO<ExpenditureListDTO>>
    {
        public string SearchTerm { get; set; } = string.Empty;

        public int Page { get; set; } = 1;

        public int RecordsPerPage { get; set; } = 10;
    }
}
