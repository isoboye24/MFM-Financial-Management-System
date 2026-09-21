namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureListsByMonthAndYear
{
    public class ExpenditureListsByMonthAndYearFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public Guid Id { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }

        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
