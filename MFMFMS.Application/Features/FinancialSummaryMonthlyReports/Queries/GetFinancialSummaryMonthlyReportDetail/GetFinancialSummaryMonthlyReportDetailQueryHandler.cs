using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportDetail
{
    public class GetFinancialSummaryMonthlyReportDetailQueryHandler : IRequestHandler<GetFinancialSummaryMonthlyReportDetailQuery, FinancialSummaryMonthlyReportDetailDTO>
    {
        private readonly IFinancialSummaryMonthlyReportRepository _repository;

        public GetFinancialSummaryMonthlyReportDetailQueryHandler(IFinancialSummaryMonthlyReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<FinancialSummaryMonthlyReportDetailDTO> Handle(GetFinancialSummaryMonthlyReportDetailQuery request)
        {
            var report = await _repository.GetById(request.Id);

            if (report is null)
            {
                throw new NotFoundException("Report not found");
            }

            return report.ToDTO();
        }
    }
}
