using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class Expenditure
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Summary { get; private set; } = string.Empty;

        public Expenditure(decimal amount, DateTime date, string summary)
        {
            ValidateAll(amount, date, summary);

            Amount = amount;
            Date = date;
            Summary = summary.Trim();
            Id = Guid.CreateVersion7();
        }

        private Expenditure()
        {
            
        }

        private static void ValidateAll(decimal amount, DateTime date, string summary)
        {
            ValidateSummary(summary);
            ValidateAmount(amount);
            ValidateDate(date);
        }

        private static void ValidateSummary(string summary)
        {
            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new BusinessRuleException("Summary is required.");
            }
        }

        public void UpdateSummary(string summary)
        {
            ValidateSummary(summary);
            Summary = summary.Trim();
        }

        private static void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new BusinessRuleException("Amount must be greater than zero.");
            }
        }

        public void UpdateAmount(decimal amount)
        {
            ValidateAmount(amount);
            Amount = amount;
        }

        private static void ValidateDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                throw new BusinessRuleException("Date is required.");
            }
        }

        public void UpdateDate(DateTime date)
        {
            ValidateDate(date);
            Date = date;
        }
    }
}
