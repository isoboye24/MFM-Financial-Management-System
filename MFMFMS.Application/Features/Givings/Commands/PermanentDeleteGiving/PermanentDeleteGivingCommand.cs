using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Commands.PermanentDeleteGiving
{
    public class PermanentDeleteGivingCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
