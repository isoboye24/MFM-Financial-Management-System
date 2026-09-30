using MFMFMS.API.DTOs.FinancialSummaryMonthlyReports;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.CreateFSMonthlyReports;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportLists;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/financial-summary-monthly-reports")]
    public class FinancialSummaryMonthlyReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FinancialSummaryMonthlyReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFinancialSummaryMonthlyReportsDTO createReportDTO)
        {
            var command = new CreateFSMonthlyReportsCommand
            {
                Month = createReportDTO.Month,
                Year = createReportDTO.Year,
                OpeningBalance = createReportDTO.OpeningBalance                                
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<FinancialSummaryMonthlyReportListsDTO>>> GetAll([FromQuery] GetFinancialSummaryMonthlyReportListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }
    }
}
