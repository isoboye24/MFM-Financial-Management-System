using MFMFMS.API.DTOs.Meetings;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Meetings.Commands.CreateMeetings;
using MFMFMS.Application.Features.Meetings.Commands.UpdateMeeting;
using MFMFMS.Application.Features.Meetings.Queries.GetMeetingDetail;
using MFMFMS.Application.Features.Meetings.Queries.GetMeetingLists;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/meetings")]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MeetingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingDTO createMeetingDTO)
        {
            var command = new CreateMeetingsCommand
            {
                Date = createMeetingDTO.Date,
                Summary = createMeetingDTO.Summary,
                MessageTitle = createMeetingDTO.MessageTitle,
                Minister = createMeetingDTO.Minister,
                NoOfMaleAttendance = createMeetingDTO.NoOfMaleAttendance,
                NoOfFemaleAttendance = createMeetingDTO.NoOfFemaleAttendance,
                NoOfChildrenAttendance = createMeetingDTO.NoOfChildrenAttendance
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<MeetingListsDTO>>> GetAll([FromQuery] GetMeetingListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDetailDTO>> GetById(Guid id)
        {
            var query = new GetMeetingDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateMeetingDTO updateMeetingDTO)
        {
            var command = new UpdateMeetingCommand
            {
                Id = id,
                MessageTitle = updateMeetingDTO.MessageTitle,
                Date = updateMeetingDTO.Date,
                Summary = updateMeetingDTO.Summary,
                Minister = updateMeetingDTO.Minister,
                NoOfMaleAttendance = updateMeetingDTO.NoOfMaleAttendance,
                NoOfFemaleAttendance = updateMeetingDTO.NoOfFemaleAttendance,
                NoOfChildrenAttendance = updateMeetingDTO.NoOfChildrenAttendance
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
