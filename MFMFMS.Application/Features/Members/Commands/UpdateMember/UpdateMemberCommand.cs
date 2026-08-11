using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Commands.UpdateMember
{
    public class UpdateMemberCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required Guid PositionId { get; set; }
    }    
}
