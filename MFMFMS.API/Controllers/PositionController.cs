using MFMFMS.API.DTOs.Positions;
using MFMFMS.Application.Features.Positions.Commands.CreatePosition;
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
    }
}
