using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Documents.Queries.GetDocumentDetail
{
    public class GetDocumentDetailQuery : IRequest<DocumentDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
