namespace MFMFMS.Application.Features.Members.Queries.GetMemberLists
{
    public class MembersFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid PositionId { get; set; }
    }
}
