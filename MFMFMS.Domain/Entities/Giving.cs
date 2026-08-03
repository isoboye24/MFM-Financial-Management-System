using MFMFMS.Domain.Exceptions;

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

        public Giving(decimal amount, DateTime date, string summary, Guid categoryId)
        {
            ValidateAll(amount, date, summary, categoryId);

            Amount = amount;
            Date = date;
            Summary = summary.Trim();
            CategoryId = categoryId;
            Id = Guid.CreateVersion7();
        }

        private Giving()
        {
            
        }

        private static void ValidateAll(decimal amount, DateTime date, string summary, Guid categoryId)
        {
            ValidateAmount(amount);
            ValidateDate(date);
            ValidateSummary(summary);
            ValidateCategoryId(categoryId);
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

        private static void ValidateCategoryId(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new BusinessRuleException("CategoryId is required.");
            }
        }

        public void UpdateCategoryId(Guid categoryId)
        {
            ValidateCategoryId(categoryId);
            CategoryId = categoryId;
        }
    }
}
