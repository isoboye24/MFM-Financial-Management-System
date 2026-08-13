using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Enums;

namespace MFMFMS.Application.Features.Documents.Commands.CreateDocuments
{
    public class CreateDocumentCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string BlobName { get; set; }
        public required DocumentType DocumentType { get; set; }
    }
}
