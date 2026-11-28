using MFMFMS.API.DTOs.Members;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Contracts.Storage;
using MFMFMS.Application.Features.Members.Commands.CreateMembers;
using MFMFMS.Application.Features.Members.Commands.DeleteMember;
using MFMFMS.Application.Features.Members.Commands.PermanentDeleteMember;
using MFMFMS.Application.Features.Members.Commands.RestoreMember;
using MFMFMS.Application.Features.Members.Commands.UpdateMember;
using MFMFMS.Application.Features.Members.Queries.GetDeletedMemberLists;
using MFMFMS.Application.Features.Members.Queries.GetMemberDetail;
using MFMFMS.Application.Features.Members.Queries.GetMemberLists;
using MFMFMS.Application.Features.Members.Queries.GetTotalMemberStatistics;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IImageStorageService _imageStorageService;

        public MembersController(IMediator mediator, IImageStorageService imageStorageService)
        {
            _mediator = mediator;
            _imageStorageService = imageStorageService;
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
                Email = createMemberDTO.Email,
                ImagePath = createMemberDTO.ImagePath,
                PositionId = createMemberDTO.PositionId,
                GenderId = createMemberDTO.GenderId
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


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateMemberDTO updateMemberDTO)
        {
            var command = new UpdateMemberCommand
            {
                Id = id,
                FirstName = updateMemberDTO.FirstName,
                LastName = updateMemberDTO.LastName,
                Address = updateMemberDTO.Address,
                PhoneNumber = updateMemberDTO.PhoneNumber,
                Email = updateMemberDTO.Email,
                ImagePath = updateMemberDTO.ImagePath,
                PositionId = updateMemberDTO.PositionId,
                GenderId = updateMemberDTO.GenderId,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteMemberCommand { Id = id });
            return NoContent();
        }

        [HttpGet("deleted")]
        public async Task<ActionResult<List<DeletedMemberListDTO>>> GetDeleted([FromQuery] GetDeletedMemberListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            await _mediator.Send(new RestoreMemberCommand
            {
                Id = id
            });

            return NoContent();
        }

        [HttpDelete("{id}/permanent")]
        public async Task<IActionResult> DeletePermanently(Guid id)
        {
            await _mediator.Send(new PermanentDeleteMemberCommand { Id = id });
            return NoContent();
        }

        [HttpPost("images")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, CancellationToken cancellationToken)
        {
            const long maxFileSize = 5 * 1024 * 1024;

            if (file == null || file.Length == 0)
                return BadRequest("Please select an image.");

            if (file.Length > maxFileSize)
                return BadRequest("Image size cannot exceed 5 MB.");

            var extension = Path.GetExtension(file.FileName)
                .ToLowerInvariant();

            if (extension != ".jpg" &&
                extension != ".jpeg" &&
                extension != ".png")
            {
                return BadRequest(
                    "Only JPG, JPEG and PNG images are allowed.");
            }

            await using var stream = file.OpenReadStream();

            // Read the image signature to verify its actual format.
            var signature = new byte[8];
            var bytesRead = await stream.ReadAsync(signature.AsMemory(0, signature.Length), cancellationToken);

            var isJpeg =
                bytesRead >= 3 &&
                signature[0] == 0xFF &&
                signature[1] == 0xD8 &&
                signature[2] == 0xFF;

            var isPng =
                bytesRead == 8 &&
                signature.SequenceEqual(new byte[]
                {
            0x89, 0x50, 0x4E, 0x47,
            0x0D, 0x0A, 0x1A, 0x0A
                });

            if ((extension == ".jpg" || extension == ".jpeg") && !isJpeg)
                return BadRequest("The uploaded file is not a valid JPEG image.");

            if (extension == ".png" && !isPng)
                return BadRequest("The uploaded file is not a valid PNG image.");

            // Reset stream so the storage service reads from the beginning.
            stream.Position = 0;

            var imagePath = await _imageStorageService.SaveAsync(stream, file.FileName, file.Length, cancellationToken);

            return Ok(new
            {
                ImagePath = imagePath
            });
        }

        [HttpGet("total/statistics")]
        public async Task<ActionResult<TotalMemberStatisticsDTO>> GetTotalStatistics()
        {
            var query = new GetTotalMemberStatisticsQuery();

            return await _mediator.Send(query);
        }
    }
}
