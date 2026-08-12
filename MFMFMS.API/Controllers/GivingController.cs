using MFMFMS.API.DTOs.Givings;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Givings.Commands.CreateGivings;
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
    }
}
