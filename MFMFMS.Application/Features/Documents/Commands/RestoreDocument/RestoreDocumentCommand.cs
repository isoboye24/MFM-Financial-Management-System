using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Documents.Commands.RestoreDocument
{
    public class RestoreDocumentCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
