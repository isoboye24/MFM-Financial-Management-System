namespace MFMFMS.Application.Features.Categories.Queries.GetCategoryLists
{
    public class CategoriesFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
