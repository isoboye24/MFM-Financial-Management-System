using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Commands.DeleteGiving
{
    public class DeleteGivingCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
