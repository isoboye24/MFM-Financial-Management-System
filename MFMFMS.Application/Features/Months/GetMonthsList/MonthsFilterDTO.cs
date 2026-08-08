namespace MFMFMS.Application.Features.Months.GetMonthsList
{
    public class MonthsFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
