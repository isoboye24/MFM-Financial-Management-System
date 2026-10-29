using MFMFMS.API.DTOs.MemberNotes;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.MemberNotes.Commands.CreateMemberNote;
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
    }
}
