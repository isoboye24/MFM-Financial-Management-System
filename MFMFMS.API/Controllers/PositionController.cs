using MFMFMS.API.DTOs.Positions;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Positions.Commands.CreatePosition;
using MFMFMS.Application.Features.Positions.Commands.DeletePosition;
using MFMFMS.Application.Features.Positions.Commands.PermanentDeletePosition;
using MFMFMS.Application.Features.Positions.Commands.RestorePosition;
using MFMFMS.Application.Features.Positions.Commands.UpdatePosition;
using MFMFMS.Application.Features.Positions.Queries.GetDeletedPositionLists;
using MFMFMS.Application.Features.Positions.Queries.GetPositionDetail;
using MFMFMS.Application.Features.Positions.Queries.GetPositionLists;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/positions")]
    public class PositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionDTO createPositionDTO)
        {
            var command = new CreatePositionCommand
            {
                Name = createPositionDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<PositionListsDTO>>> GetAll([FromQuery] GetPositionListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDetailDTO>> GetById(Guid id)
        {
            var query = new GetPositionDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePositionDTO updatePositionDTO)
        {
            var command = new UpdatePositionCommand
            {
                Id = id,
                Name = updatePositionDTO.Name,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletePositionCommand { Id = id });
            return NoContent();
        }

        [HttpGet("deleted")]
        public async Task<ActionResult<List<DeletedPositionListsDTO>>> GetDeleted([FromQuery] GetDeletedPositionListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            await _mediator.Send(new RestorePositionCommand
            {
                Id = id
            });

            return NoContent();
        }

        [HttpDelete("{id}/permanent")]
        public async Task<IActionResult> DeletePermanently(Guid id)
        {
            await _mediator.Send(new PermanentDeletePositionCommand { Id = id });
            return NoContent();
        }
    }
}
