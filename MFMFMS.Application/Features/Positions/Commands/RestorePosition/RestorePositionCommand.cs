using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Positions.Commands.RestorePosition
{
    public class RestorePositionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
