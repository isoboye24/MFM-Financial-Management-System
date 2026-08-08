using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Months.GetMonthsList;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/months")]
    public class MonthsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MonthsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MonthListsDTO>>> GetAll([FromQuery] GetMonthListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }
    }
}
