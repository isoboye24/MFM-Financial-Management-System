using MFMFMS.Application.Features.Documents.Queries.GetDeletedDocumentLists;
using MFMFMS.Application.Features.Documents.Queries.GetDocumentLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<bool> Exists(string name);
        Task<IEnumerable<Document>> GetFiltered(DocumentsFilterDTO filter);
        Task<IEnumerable<Document>> GetDeletedFiltered(DeletedDocumentsFilterDTO filter);
        Task<Document?> GetDocumentDetail(Guid id);
    }
}
