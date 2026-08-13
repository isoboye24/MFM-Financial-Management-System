using MFMFMS.API.DTOs.Documents;
using MFMFMS.Application.Features.Documents.Commands.CreateDocuments;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDocumentDTO createDocumentDTO)
        {
            var command = new CreateDocumentCommand
            {
                Name = createDocumentDTO.Name,
                BlobName = createDocumentDTO.BlobName,
                DocumentType = createDocumentDTO.DocumentType
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
