namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetDeletedMeetingCategoryLists
{
    public class DeletedMeetingCategoriesFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
