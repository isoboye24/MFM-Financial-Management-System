using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureDetail
{
    public class GetExpenditureDetailQuery : IRequest<ExpenditureDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
