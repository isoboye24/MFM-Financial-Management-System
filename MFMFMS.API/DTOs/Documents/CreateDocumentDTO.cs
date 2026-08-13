using MFMFMS.Domain.Enums;

namespace MFMFMS.API.DTOs.Documents
{
    public class CreateDocumentDTO
    {
        public required string Name { get; set; }
        public required string BlobName { get; set; }
        public required DocumentType DocumentType { get; set; }
    }
}
