using MFMFMS.Domain.Enums;
using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string BlobName { get; private set; } = string.Empty;
        public DocumentType DocumentType { get; private set; }
        public DateTime UploadedAt { get; private set; }

        public Document(string name, string blobName, DocumentType documentType)
        {
            ValidateAll(name, blobName, documentType);

            Name = name.Trim();
            BlobName = blobName.Trim();
            DocumentType = documentType;
            UploadedAt = DateTime.UtcNow;
            Id = Guid.CreateVersion7();
        }

        private Document()
        {
        }

        public void UpdateDocument(string name, string blobName, DocumentType documentType)
        {
            ValidateAll(name, blobName, documentType);

            Name = name;
            BlobName = blobName;
            DocumentType = documentType;
        }

        private static void ValidateAll(string name, string blobName, DocumentType documentType)
        {
            ValidateName(name);
            ValidateBlobName(blobName);
            ValidateDocumentType(documentType);
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException("Document's name is required.");
            }

            if (name.Length > 200)
            {
                throw new BusinessRuleException("Document name cannot exceed 200 characters.");
            }                
        }

        private static void ValidateBlobName(string blobName)
        {
            if (string.IsNullOrWhiteSpace(blobName))
            {
                throw new BusinessRuleException("Document's blob name is required.");
            }
        }

        private static void ValidateDocumentType(DocumentType documentType)
        {
            if (!Enum.IsDefined(documentType))
            {
                throw new BusinessRuleException("Document type is invalid.");
            }
        }
    }
}
