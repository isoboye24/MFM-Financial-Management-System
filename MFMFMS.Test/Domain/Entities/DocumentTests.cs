using MFMFMS.Domain.Entities;
using MFMFMS.Domain.Enums;

namespace MFMFMS.Test.Domain.Entities
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void Should_Create_Document_When_Valid_Data_Is_Provided()
        {
            var name = "Monthly Report";
            var blobName = "documents/monthly-report.pdf";
            var documentType = DocumentType.Report;

            var beforeCreation = DateTime.UtcNow;

            var document = new Document(name, blobName, documentType);

            var afterCreation = DateTime.UtcNow;

            Assert.AreNotEqual(Guid.Empty, document.Id);
            Assert.AreEqual(name, document.Name);
            Assert.AreEqual(blobName, document.BlobName);
            Assert.AreEqual(documentType, document.DocumentType);

            Assert.IsTrue(
                document.UploadedAt >= beforeCreation &&
                document.UploadedAt <= afterCreation);
        }
    }
}
