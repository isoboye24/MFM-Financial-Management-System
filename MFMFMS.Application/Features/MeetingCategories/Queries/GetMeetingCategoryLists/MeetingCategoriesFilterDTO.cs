namespace MFMFMS.Application.Features.MeetingCategories.Queries.GetMeetingCategoryLists
{
    public class MeetingCategoriesFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
