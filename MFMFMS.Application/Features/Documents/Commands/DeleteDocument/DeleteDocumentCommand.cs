using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Documents.Commands.DeleteDocument
{
    public class DeleteDocumentCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
