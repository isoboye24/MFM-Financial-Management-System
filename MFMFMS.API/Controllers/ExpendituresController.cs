using MFMFMS.API.DTOs.Expenditures;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Expenditures.Commands.CreateExpenditures;
using MFMFMS.Application.Features.Expenditures.Commands.DeleteExpenditure;
using MFMFMS.Application.Features.Expenditures.Commands.UpdateExpenditure;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureDetail;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenditureDetailDTO>> GetById(Guid id)
        {
            var query = new GetExpenditureDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateExpenditureDTO updateExpenditureDTO)
        {
            var command = new UpdateExpenditureCommand
            {
                Id = id,
                Amount = updateExpenditureDTO.Amount,
                Summary = updateExpenditureDTO.Summary,
                Date = updateExpenditureDTO.Date,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteExpenditureCommand { Id = id });
            return NoContent();
        }
    }
}
