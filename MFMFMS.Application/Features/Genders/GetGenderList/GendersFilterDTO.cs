namespace MFMFMS.Application.Features.Genders.GetGenderList
{
    public class GendersFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
