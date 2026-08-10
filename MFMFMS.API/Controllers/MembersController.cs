using MFMFMS.API.DTOs.Members;
using MFMFMS.Application.Features.Members.Commands.CreateMembers;
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
    }
}
