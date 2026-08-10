using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Commands.CreateMembers
{
    public class CreateMemberCommand : IRequest<Guid>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required Guid PositionId { get; set; }
    }
}
