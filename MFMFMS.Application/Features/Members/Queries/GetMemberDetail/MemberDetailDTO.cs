namespace MFMFMS.Application.Features.Members.Queries.GetMemberDetail
{
    public class MemberDetailDTO
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string PositionName { get; set; }
    }
}
