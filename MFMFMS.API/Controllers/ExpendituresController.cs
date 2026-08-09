using MFMFMS.API.DTOs.Expenditures;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Expenditures.Commands.CreateExpenditures;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/expenditures")]
    public class ExpendituresController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExpendituresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenditureDTO createExpenditureDTO)
        {
            var command = new CreateExpenditureCommand
            {
                Amount = createExpenditureDTO.Amount,
                Summary = createExpenditureDTO.Summary,
                Date = createExpenditureDTO.Date
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpenditureListDTO>>> GetAll([FromQuery] GetExpenditureListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }
    }
}
