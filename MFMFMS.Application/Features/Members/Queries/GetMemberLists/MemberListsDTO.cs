namespace MFMFMS.Application.Features.Members.Queries.GetMemberLists
{
    public class MemberListsDTO
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string PositionName { get; set; }
    }
}
