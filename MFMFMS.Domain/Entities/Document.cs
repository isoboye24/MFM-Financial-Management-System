namespace MFMFMS.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string FilePath { get; private set; } = string.Empty;
        public string BlobName { get; private set; } = string.Empty;
        public string DocumentType { get; private set; } = string.Empty;
        public DateTime UploadedAt { get; private set; }
    }
}
