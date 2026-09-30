using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportLists
{
    public class GetFinancialSummaryMonthlyReportListsQueryHandler : IRequestHandler<GetFinancialSummaryMonthlyReportListsQuery, PaginatedDTO<FinancialSummaryMonthlyReportListsDTO>>
    {
        private readonly IFinancialSummaryMonthlyReportRepository _repository;

        public GetFinancialSummaryMonthlyReportListsQueryHandler(IFinancialSummaryMonthlyReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<FinancialSummaryMonthlyReportListsDTO>> Handle(GetFinancialSummaryMonthlyReportListsQuery request)
        {
            var reports = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var reportList = reports.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<FinancialSummaryMonthlyReportListsDTO>
            {
                Items = reportList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
