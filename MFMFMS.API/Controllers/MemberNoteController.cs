using MFMFMS.API.DTOs.Meetings;
using MFMFMS.API.DTOs.MemberNotes;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Expenditures.Commands.DeleteExpenditure;
using MFMFMS.Application.Features.Meetings.Commands.UpdateMeeting;
using MFMFMS.Application.Features.MemberNotes.Commands.CreateMemberNote;
using MFMFMS.Application.Features.MemberNotes.Commands.DeleteMemberNote;
using MFMFMS.Application.Features.MemberNotes.Commands.UpdateMemberNote;
using MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteDetail;
using MFMFMS.Application.Features.MemberNotes.Queries.GetMemberNoteLists;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/member-notes")]
    public class MemberNoteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MemberNoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberNoteDTO createMemberNoteDTO)
        {
            var command = new CreateMemberNoteCommand
            {
                Note = createMemberNoteDTO.Note,
                NoteTitle = createMemberNoteDTO.NoteTitle,
                MemberId = createMemberNoteDTO.MemberId                
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<MemberNoteListsDTO>>> GetAll([FromQuery] GetMemberNoteListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberNoteDetailDTO>> GetById(Guid id)
        {
            var query = new GetMemberNoteDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateMemberNoteDTO updateMemberNoteDTO)
        {
            var command = new UpdateMemberNoteCommand
            {
                Id = id,
                NoteTitle = updateMemberNoteDTO.NoteTitle,
                Note = updateMemberNoteDTO.Note,
                MemberId = updateMemberNoteDTO.MemberId
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteMemberNoteCommand { Id = id });
            return NoContent();
        }
    }
}