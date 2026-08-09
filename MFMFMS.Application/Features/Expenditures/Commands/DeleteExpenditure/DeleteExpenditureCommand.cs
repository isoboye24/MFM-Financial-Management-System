using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Commands.DeleteExpenditure
{
    public class DeleteExpenditureCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
