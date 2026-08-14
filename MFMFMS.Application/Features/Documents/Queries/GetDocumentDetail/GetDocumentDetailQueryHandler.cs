using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Documents.Queries.GetDocumentDetail
{
    public class GetDocumentDetailQueryHandler : IRequestHandler<GetDocumentDetailQuery, DocumentDetailDTO>
    {
        private readonly IDocumentRepository _repository;
        public GetDocumentDetailQueryHandler(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<DocumentDetailDTO> Handle(GetDocumentDetailQuery request)
        {
            var document = await _repository.GetDocumentDetail(request.Id);

            if (document is null)
            {
                throw new NotFoundException("Document is not found");
            }

            return document.ToDTO();
        }
    }
}
