using MFMFMS.API.DTOs.Documents;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Documents.Commands.CreateDocuments;
using MFMFMS.Application.Features.Documents.Queries.GetDocumentDetail;
using MFMFMS.Application.Features.Documents.Queries.GetDocumentLists;
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

        [HttpGet]
        public async Task<ActionResult<List<DocumentListsDTO>>> GetAll([FromQuery] GetDocumentListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDetailDTO>> GetById(Guid id)
        {
            var query = new GetDocumentDetailQuery { Id = id };
            return await _mediator.Send(query);
        }
    }
}
