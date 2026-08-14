namespace MFMFMS.Application.Features.Documents.Queries.GetDocumentLists
{
    public class DocumentListsDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string BlobName { get; set; }
        public required string DocumentType { get; set; }
        public required DateTime UploadedAt { get; set; }
    }
}
