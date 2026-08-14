using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Documents.Queries.GetDeletedDocumentLists
{
    public class GetDeletedDocumentListQueryHandler : IRequestHandler<GetDeletedDocumentListQuery, PaginatedDTO<DeletedDocumentListDTO>>
    {
        private readonly IDocumentRepository _repository;
        public GetDeletedDocumentListQueryHandler(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DeletedDocumentListDTO>> Handle(GetDeletedDocumentListQuery request)
        {
            var documents = await _repository.GetDeletedFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();

            var documentList = documents.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<DeletedDocumentListDTO>
            {
                Items = documentList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}
