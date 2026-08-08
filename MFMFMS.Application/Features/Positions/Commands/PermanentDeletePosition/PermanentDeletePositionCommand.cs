using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Positions.Commands.PermanentDeletePosition
{
    public class PermanentDeletePositionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
