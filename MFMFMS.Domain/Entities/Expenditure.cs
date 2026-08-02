namespace MFMFMS.Domain.Entities
{
    public class Expenditure
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Summary { get; private set; } = string.Empty;
    }
}
