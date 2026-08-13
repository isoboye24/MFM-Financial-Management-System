using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Commands.RestoreGiving
{
    public class RestoreGivingCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
