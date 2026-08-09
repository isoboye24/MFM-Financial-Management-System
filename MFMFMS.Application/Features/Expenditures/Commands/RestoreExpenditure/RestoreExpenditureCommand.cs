using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Commands.RestoreExpenditure
{
    public class RestoreExpenditureCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
