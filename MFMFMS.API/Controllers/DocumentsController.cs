using MFMFMS.API.DTOs.Documents;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Documents.Commands.CreateDocuments;
using MFMFMS.Application.Features.Documents.Commands.DeleteDocument;
using MFMFMS.Application.Features.Documents.Commands.RestoreDocument;
using MFMFMS.Application.Features.Documents.Commands.UpdateDocument;
using MFMFMS.Application.Features.Documents.Queries.GetDeletedDocumentLists;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDocumentDTO updateDocumentDTO)
        {
            var command = new UpdateDocumentCommand
            {
                Id = id,
                Name = updateDocumentDTO.Name,
                BlobName = updateDocumentDTO.BlobName,
                DocumentType = updateDocumentDTO.DocumentType,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteDocumentCommand { Id = id });
            return NoContent();
        }

        [HttpGet("deleted")]
        public async Task<ActionResult<List<DeletedDocumentListDTO>>> GetDeleted([FromQuery] GetDeletedDocumentListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            await _mediator.Send(new RestoreDocumentCommand
            {
                Id = id
            });

            return NoContent();
        }
    }
}
