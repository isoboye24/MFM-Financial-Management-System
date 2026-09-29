using MFMFMS.API.DTOs.FinancialSummaryMonthlyReports;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.CreateFSMonthlyReports;
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
    }
}
