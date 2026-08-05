namespace MFMFMS.Application.Features.Categories.Queries.GetDeletedCategoryLists
{
    public class DeletedCategoriesFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
