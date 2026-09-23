namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureListsByMonthAndYear
{
    public class ExpenditureListsByMonthAndYearDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Summary { get; set; } = string.Empty;
    }
}
