namespace MFMFMS.API.DTOs.Members
{
    public class UpdateMemberDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required Guid PositionId { get; set; }
    }
}
