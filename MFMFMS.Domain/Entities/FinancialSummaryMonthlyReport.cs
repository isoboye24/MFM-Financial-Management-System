using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class FinancialSummaryMonthlyReport : SoftDeletableEntity
    {
        public int Year { get; private set; }
        public int Month { get; private set; }

        public decimal OpeningBalance { get; private set; }
        public decimal TotalIncome { get; private set; }
        public decimal TotalExpenditure { get; private set; }
        public decimal ClosingBalance { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public FinancialSummaryMonthlyReport(int year, int month, decimal openingBalance)
        {
            ValidateAll(year, month, openingBalance);

            Year = year;
            Month = month;
            OpeningBalance = openingBalance;

            Id = Guid.CreateVersion7();
            CreatedAt = DateTime.UtcNow;
        }

        private FinancialSummaryMonthlyReport()
        {
        }

        private static void ValidateAll(int year, int month, decimal openingBalance)
        {
            ValidateDate(year, month);
            ValidateOpeningBalance(openingBalance);
        }

        private static void ValidateDate(int year, int month)
        {
            if (year < 1)
            {
                throw new BusinessRuleException("Year must be valid.");
            }

            if (month < 1 || month > 12)
            {
                throw new BusinessRuleException("Month must be between 1 and 12.");
            }

            var currentDate = DateTime.Today;

            var selectedPeriod = new DateTime(year, month, 1);
            var currentPeriod = new DateTime(currentDate.Year, currentDate.Month, 1);

            if (selectedPeriod > currentPeriod)
            {
                throw new BusinessRuleException("The report month and year cannot be later than the current month and year.");
            }
        }

        private static void ValidateOpeningBalance(decimal openingBalance)
        {
            if (openingBalance < 0)
            {
                throw new BusinessRuleException("Opening balance cannot be negative.");
            }
        }

        public void SetTotals(decimal totalIncome, decimal totalExpenditure)
        {
            if (totalIncome < 0)
            {
                throw new BusinessRuleException("Total income cannot be negative.");
            }

            if (totalExpenditure < 0)
            {
                throw new BusinessRuleException("Total expenditure cannot be negative.");
            }

            TotalIncome = totalIncome;
            TotalExpenditure = totalExpenditure;

            GetClosingBalance();
        }

        public void UpdateOpeningBalance( decimal openingBalance)
        {
            ValidateOpeningBalance(openingBalance);

            OpeningBalance = openingBalance;

            GetClosingBalance();
        }

        private void GetClosingBalance()
        {
            ClosingBalance = OpeningBalance + TotalIncome - TotalExpenditure;

            UpdatedAt = DateTime.UtcNow;
        }
    }
}