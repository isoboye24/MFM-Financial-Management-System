using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Documents.Queries.GetDocumentLists
{
    public class GetDocumentListQueryHandler : IRequestHandler<GetDocumentListQuery, PaginatedDTO<DocumentListsDTO>>
    {
        private readonly IDocumentRepository _repository;
        public GetDocumentListQueryHandler(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DocumentListsDTO>> Handle(GetDocumentListQuery request)
        {
            var documents = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var documentList = documents.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DocumentListsDTO>
            {
                Items = documentList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
