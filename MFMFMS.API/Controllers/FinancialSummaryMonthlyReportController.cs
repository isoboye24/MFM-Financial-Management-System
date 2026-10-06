using MFMFMS.API.DTOs.FinancialSummaryMonthlyReports;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.CreateFSMonthlyReports;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.DeleteFSMonthlyReportsPermanently;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.UpdateFSMonthlyReports;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportDetail;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportLists;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialSummaryMonthlyReportDetailDTO>> GetById(Guid id)
        {
            var query = new GetFinancialSummaryMonthlyReportDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateFinancialSummaryMonthlyReportsDTO updateReportDTO)
        {
            var command = new UpdateFSMonthlyReportsCommand
            {
                Id = id,
                Month = updateReportDTO.Month,
                Year = updateReportDTO.Year,
                OpeningBalance = updateReportDTO.OpeningBalance               
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}/permanent")]
        public async Task<IActionResult> DeletePermanently(Guid id)
        {
            await _mediator.Send(new PermanentDeleteFSMonthlyReportCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id}/pdf-data")]
        public async Task<ActionResult<FinancialSummaryMonthlyReportPDFDTO>> GetPDFData(Guid id)
        {
            var query = new GetFinancialSummaryMonthlyReportPDFQuery
            {
                Id = id
            };

            return await _mediator.Send(query);
        }

    }
}
