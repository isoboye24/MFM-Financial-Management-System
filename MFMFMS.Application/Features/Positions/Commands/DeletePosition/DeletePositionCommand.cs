using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Positions.Commands.DeletePosition
{
    public class DeletePositionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
