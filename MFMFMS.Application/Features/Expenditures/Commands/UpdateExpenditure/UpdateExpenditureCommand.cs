using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Commands.UpdateExpenditure
{
    public class UpdateExpenditureCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Summary { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime Date { get; set; }
    }
}
