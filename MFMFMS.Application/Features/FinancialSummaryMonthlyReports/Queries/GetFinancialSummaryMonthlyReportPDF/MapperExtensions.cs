using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF
{
    public static class MapperExtensions
    {
        internal static FinancialSummaryMonthlyReportPDFDTO ToPDFDTO(
            this FinancialSummaryMonthlyReport report)
        {
            return new FinancialSummaryMonthlyReportPDFDTO
            {
                Id = report.Id,
                Year = report.Year,
                Month = report.Month,
                OpeningBalance = report.OpeningBalance,
                TotalIncome = report.TotalIncome,
                TotalExpenditure = report.TotalExpenditure,
                ClosingBalance = report.ClosingBalance
            };
        }

        internal static FinancialSummaryMonthlyReportExpenditureDTO ToPDFDTO(
            this Expenditure expenditure)
        {
            return new FinancialSummaryMonthlyReportExpenditureDTO
            {
                Summary = expenditure.Summary,
                Amount = expenditure.Amount
            };
        }

        internal static FinancialSummaryMonthlyReportServiceDTO ToPDFDTO(
    this Meeting meeting,
    IEnumerable<Giving> givings,
    int number)
        {
            var meetingGivings = givings
                .Where(x => x.MeetingId == meeting.Id)
                .ToList();

            var offering = meetingGivings
                .Where(x => x.Category?.Name == "Offering")
                .Sum(x => x.Amount);

            var tithe = meetingGivings
                .Where(x => x.Category?.Name == "Tithe")
                .Sum(x => x.Amount);

            var seed = meetingGivings
                .Where(x => x.Category?.Name == "Seed")
                .Sum(x => x.Amount);
            
            var otherIncome = meetingGivings
                .Where(x => x.Category?.Name == "Other Income")
                .Sum(x => x.Amount);

            var totalAttendance =
                meeting.NoOfMaleAttendance +
                meeting.NoOfFemaleAttendance +
                meeting.NoOfChildrenAttendance;

            var totalIncome =
                offering +
                tithe +
                seed +
                otherIncome;

            return new FinancialSummaryMonthlyReportServiceDTO
            {
                Number = number,

                Date = meeting.Date,
                Message = meeting.MessageTitle,
                Minister = meeting.Minister,

                Male = meeting.NoOfMaleAttendance,
                Female = meeting.NoOfFemaleAttendance,
                Children = meeting.NoOfChildrenAttendance,
                TotalAttendance = totalAttendance,

                Offering = offering,
                Tithe = tithe,
                Seed = seed,
                OtherIncome = otherIncome,

                TotalIncome = totalIncome
            };
        }


    }
}
