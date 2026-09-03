using MFMFMS.API.DTOs.MeetingCategories;
using MFMFMS.Application.Features.MeetingCategories.Commands.CreateMeetingCategories;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/meeting-categories")]
    public class MeetingCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MeetingCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingCategoryDTO createMeetingCategoryDTO)
        {           
            var command = new CreateMeetingCategoryCommand
            {
                Name = createMeetingCategoryDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }

    }
}
