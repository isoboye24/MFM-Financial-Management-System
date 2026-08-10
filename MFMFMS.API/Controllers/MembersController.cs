using MFMFMS.API.DTOs.Members;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Members.Commands.CreateMembers;
using MFMFMS.Application.Features.Members.Queries.GetMemberDetail;
using MFMFMS.Application.Features.Members.Queries.GetMemberLists;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberDTO createMemberDTO)
        {
            var command = new CreateMemberCommand
            {
                FirstName = createMemberDTO.FirstName,
                LastName = createMemberDTO.LastName,
                Address = createMemberDTO.Address,
                PhoneNumber = createMemberDTO.PhoneNumber,
                PositionId = createMemberDTO.PositionId
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<MemberListsDTO>>> GetAll([FromQuery] GetMemberListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDetailDTO>> GetById(Guid id)
        {
            var query = new GetMemberDetailQuery { Id = id };
            return await _mediator.Send(query);
        }
    }
}
