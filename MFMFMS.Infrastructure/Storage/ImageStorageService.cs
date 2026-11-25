using MFMFMS.Application.Contracts.Storage;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace MFMFMS.Infrastructure.Storage
{
    public class ImageStorageService : IImageStorageService
    {
        private const long MaxFileSize = 5 * 1024 * 1024;

        private static readonly string[] AllowedExtensions =
        {
            ".jpg",
            ".jpeg",
            ".png"
        };

        private readonly string _storagePath;

        public ImageStorageService(IHostEnvironment environment)
        {
            _storagePath = Path.Combine(
                environment.ContentRootPath,
                "Uploads",
                "Members"
            );
        }

        public async Task<string> SaveAsync(
            Stream fileStream,
            string fileName,
            long fileSize,
            CancellationToken cancellationToken = default)
        {
            if (fileStream == null || !fileStream.CanRead)
                throw new ArgumentException("Invalid image stream.");

            if (fileSize <= 0 || fileSize > MaxFileSize)
                throw new ArgumentException(
                    "Image must be greater than 0 bytes and no larger than 5 MB."
                );

            var extension = Path.GetExtension(
                fileName.Replace('\\', '/')
            ).ToLowerInvariant();

            if (!AllowedExtensions.Contains(extension))
                throw new ArgumentException(
                    "Only JPG, JPEG and PNG images are allowed."
                );

            Directory.CreateDirectory(_storagePath);

            var generatedFileName =
                $"{Guid.NewGuid():N}{extension}";

            var fullPath = Path.Combine(
                _storagePath,
                generatedFileName
            );

            try
            {
                await using var destination = new FileStream(
                    fullPath,
                    FileMode.CreateNew,
                    FileAccess.Write,
                    FileShare.None,
                    81920,
                    useAsync: true
                );

                await fileStream.CopyToAsync(
                    destination,
                    cancellationToken
                );

                return generatedFileName;
            }
            catch
            {
                if (File.Exists(fullPath))
                    File.Delete(fullPath);

                throw;
            }
        }

        public Task DeleteAsync(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                return Task.CompletedTask;

            var normalizedPath = imagePath.Replace('\\', '/');
            var fileName = Path.GetFileName(normalizedPath);

            if (string.IsNullOrWhiteSpace(fileName) ||
                fileName != normalizedPath)
            {
                throw new ArgumentException(
                    "Invalid image path.",
                    nameof(imagePath)
                );
            }

            var fullPath = Path.Combine(_storagePath, fileName);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            return Task.CompletedTask;
        }
    }
}
