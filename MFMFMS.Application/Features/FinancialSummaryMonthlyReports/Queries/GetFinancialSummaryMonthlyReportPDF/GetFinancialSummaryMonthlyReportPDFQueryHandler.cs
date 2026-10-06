using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureListsByMonthAndYear;
using MFMFMS.Application.Features.Givings.Queries.GetGivingListsByMonthAndYear;
using MFMFMS.Application.Features.Meetings.Queries.GetMeetingListsByMonthAndYear;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF
{
    public class GetFinancialSummaryMonthlyReportPDFQueryHandler : IRequestHandler<GetFinancialSummaryMonthlyReportPDFQuery, FinancialSummaryMonthlyReportPDFDTO>
    {
        private readonly IFinancialSummaryMonthlyReportRepository _reportRepository;
        private readonly IMeetingRepository _meetingRepository;
        private readonly IGivingRepository _givingRepository;
        private readonly IExpenditureRepository _expenditureRepository;

        public GetFinancialSummaryMonthlyReportPDFQueryHandler(
            IFinancialSummaryMonthlyReportRepository reportRepository,
            IMeetingRepository meetingRepository,
            IGivingRepository givingRepository,
            IExpenditureRepository expenditureRepository)
        {
            _reportRepository = reportRepository;
            _meetingRepository = meetingRepository;
            _givingRepository = givingRepository;
            _expenditureRepository = expenditureRepository;
        }

        public async Task<FinancialSummaryMonthlyReportPDFDTO> Handle(
     GetFinancialSummaryMonthlyReportPDFQuery request)
        {
            var report = await _reportRepository.GetById(request.Id);

            if (report is null)
            {
                throw new NotFoundException("Report not found.");
            }

            var meetings = await _meetingRepository.GetFilteredByMonthAndYear(
                new MeetingListsByMonthAndYearFilterDTO
                {
                    Month = report.Month,
                    Year = report.Year,
                    Page = 1,
                    RecordsPerPage = 1000
                });

            var givings = await _givingRepository.GetFilteredByMonthAndYear(
                new GivingListsByMonthAndYearFilterDTO
                {
                    Month = report.Month,
                    Year = report.Year,
                    Page = 1,
                    RecordsPerPage = 1000
                });

            var expenditures = await _expenditureRepository.GetFilteredByMonthAndYear(
                new ExpenditureListsByMonthAndYearFilterDTO
                {
                    Month = report.Month,
                    Year = report.Year,
                    Page = 1,
                    RecordsPerPage = 1000
                });

            var result = report.ToPDFDTO();

            // SERVICES
            var number = 1;

            foreach (var meeting in meetings.OrderBy(x => x.Date))
            {
                result.Services.Add(meeting.ToPDFDTO(givings, number));

                number++;
            }

            // EXPENDITURES
            result.Expenditures = expenditures.Select(x => x.ToPDFDTO()).ToList();

            return result;
        }
    }
}
