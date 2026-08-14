using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Documents.Commands.PermanentDeleteDocument
{
    public class PermanentDeleteDocumentCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
