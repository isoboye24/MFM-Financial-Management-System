namespace MFMFMS.Application.Features.Documents.Queries.GetDocumentLists
{
    public class DocumentsFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public required string? Name { get; set; }
        public required string? BlobName { get; set; }
        public required string? DocumentType { get; set; }
        public required DateTime? UploadedAt { get; set; }
    }
}
