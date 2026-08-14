using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Documents.Queries.GetDocumentDetail
{
    internal static class MapperExtensions
    {
        internal static DocumentDetailDTO ToDTO(this Document document)
        {
            return new DocumentDetailDTO
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
