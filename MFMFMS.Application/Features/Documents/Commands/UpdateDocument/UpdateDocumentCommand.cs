using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Enums;

namespace MFMFMS.Application.Features.Documents.Commands.UpdateDocument
{
    public class UpdateDocumentCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string BlobName { get; set; }
        public required DocumentType DocumentType { get; set; }
    }
}
