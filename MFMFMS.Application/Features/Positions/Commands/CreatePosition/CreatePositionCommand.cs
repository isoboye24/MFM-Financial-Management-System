using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
