namespace MFMFMS.Domain.Entities
{
    public class Giving
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Summary { get; private set; } = string.Empty;
        public Guid CategoryId { get; private set; }
        public Category? Category { get; private set; }
    }
}
