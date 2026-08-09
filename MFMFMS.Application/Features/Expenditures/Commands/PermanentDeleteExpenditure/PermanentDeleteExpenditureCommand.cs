using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Expenditures.Commands.PermanentDeleteExpenditure
{
    public class PermanentDeleteExpenditureCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
