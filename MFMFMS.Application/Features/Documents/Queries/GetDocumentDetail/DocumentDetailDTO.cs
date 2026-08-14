namespace MFMFMS.Application.Features.Documents.Queries.GetDocumentDetail
{
    public class DocumentDetailDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string BlobName { get; set; }
        public required string DocumentType { get; set; }
        public required DateTime UploadedAt { get; set; }
    }
}
