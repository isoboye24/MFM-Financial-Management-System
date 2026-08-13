using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Documents.Queries.GetDeletedDocumentLists;
using MFMFMS.Application.Features.Documents.Queries.GetDocumentLists;
using MFMFMS.Domain.Entities;
using MFMFMS.Domain.Enums;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        private readonly MFMFMSDBContext _db;
        public DocumentRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string name)
        {
            var exists = await _db.Documents.Where(x => x.Name == name).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Document>> GetDeletedFiltered(DeletedDocumentsFilterDTO filter)
        {
            var query = _db.Documents.Where(x => x.IsDeleted).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            if (!string.IsNullOrWhiteSpace(filter.BlobName))
            {
                query = query.Where(p => p.BlobName.Contains(filter.BlobName));
            }

            if (!string.IsNullOrWhiteSpace(filter.DocumentType))
            {
                if (Enum.TryParse<DocumentType>(
                 filter.DocumentType,
                 ignoreCase: true,
                 out var documentType))
                {
                    query = query.Where(x => x.DocumentType == documentType);
                }
            }

            return await query
                .OrderByDescending(x => x.UploadedAt)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<Document?> GetDocumentDetail(Guid id)
        {
            return await _db.Documents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Document>> GetFiltered(DocumentsFilterDTO filter)
        {
            var query = _db.Documents.Where(x => !x.IsDeleted).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            if (!string.IsNullOrWhiteSpace(filter.BlobName))
            {
                query = query.Where(p => p.BlobName.Contains(filter.BlobName));
            }

            if (!string.IsNullOrWhiteSpace(filter.DocumentType))
            {
                if (Enum.TryParse<DocumentType>(
                 filter.DocumentType,
                 ignoreCase: true,
                 out var documentType))
                {
                    query = query.Where(x => x.DocumentType == documentType);
                }
            }

            return await query
                .OrderByDescending(x => x.UploadedAt)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
