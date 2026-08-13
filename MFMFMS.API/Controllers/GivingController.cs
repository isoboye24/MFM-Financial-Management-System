using MFMFMS.API.DTOs.Givings;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Givings.Commands.CreateGivings;
using MFMFMS.Application.Features.Givings.Commands.DeleteGiving;
using MFMFMS.Application.Features.Givings.Commands.UpdateGiving;
using MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists;
using MFMFMS.Application.Features.Givings.Queries.GetGivingDetail;
using MFMFMS.Application.Features.Givings.Queries.GetGivingLists;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/givings")]
    public class GivingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GivingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGivingDTO createGivingDTO)
        {
            var command = new CreateGivingCommand
            {
                Amount = createGivingDTO.Amount,
                Date = createGivingDTO.Date,
                Summary = createGivingDTO.Summary,
                MeetingId = createGivingDTO.MeetingId,
                CategoryId = createGivingDTO.CategoryId
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<GivingListsDTO>>> GetAll([FromQuery] GetGivingListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GivingDetailDTO>> GetById(Guid id)
        {
            var query = new GetGivingDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateGivingDTO updateGivingDTO)
        {
            var command = new UpdateGivingCommand
            {
                Id = id,
                Amount = updateGivingDTO.Amount,
                Date = updateGivingDTO.Date,
                Summary = updateGivingDTO.Summary,
                MeetingId = updateGivingDTO.MeetingId,
                CategoryId = updateGivingDTO.CategoryId,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteGivingCommand { Id = id });
            return NoContent();
        }

        [HttpGet("deleted")]
        public async Task<ActionResult<List<DeletedGivingListsDTO>>> GetDeleted([FromQuery] GetDeletedGivingListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }
    }
}
