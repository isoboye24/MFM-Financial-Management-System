using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Documents.Queries.GetDeletedDocumentLists
{
    internal static class MapperExtensions
    {
        internal static DeletedDocumentListDTO ToDTO(this Document document)
        {
            return new DeletedDocumentListDTO
            {
                Id = document.Id,
                Name = document.Name,
                BlobName = document.BlobName,
                DocumentType = document.DocumentType.ToString(),
                UploadedAt = document.UploadedAt,
                DeletedAt = document.DeletedAt ?? DateTime.MinValue
            };
        }
    }
}
