using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFMFMS.Persistence.Configurations
{
    public class DocumentConfig : IEntityTypeConfiguration<Document>
    {        
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Property(prop => prop.Name).IsRequired();
            builder.Property(prop => prop.BlobName).IsRequired();
            builder.Property(prop => prop.DocumentType).IsRequired();
            builder.Property(x => x.UploadedAt).IsRequired();
        }
    }
}
