using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Documents.Queries.GetDocumentLists
{
    internal static class MapperExtensions
    {
        internal static DocumentListsDTO ToDTO(this Document document)
        {
            return new DocumentListsDTO
            {
                Id = document.Id,
                Name = document.Name,
                BlobName = document.BlobName,
                DocumentType = document.DocumentType.ToString(),
                UploadedAt = document.UploadedAt
            };
        }
    }
}
