namespace MFMFMS.Application.Features.Positions.Queries.GetDeletedPositionLists
{
    public class DeletedPositionsFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
