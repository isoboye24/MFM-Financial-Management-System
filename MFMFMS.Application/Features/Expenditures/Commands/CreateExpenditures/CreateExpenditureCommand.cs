using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Commands.CreateExpenditures
{
    public class CreateExpenditureCommand : IRequest<Guid>
    {
        public required decimal Amount { get; set; }
        public required string Summary { get; set; }
        public required DateTime Date { get; set; }
    }
}
