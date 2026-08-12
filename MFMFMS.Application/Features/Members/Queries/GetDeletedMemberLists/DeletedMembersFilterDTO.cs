namespace MFMFMS.Application.Features.Members.Queries.GetDeletedMemberLists
{
    public class DeletedMembersFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public required string? FirstName { get; set; }
        public required string? LastName { get; set; }
        public required string? Address { get; set; }
        public required string? PhoneNumber { get; set; }
        public required Guid? PositionId { get; set; }
    }
}
