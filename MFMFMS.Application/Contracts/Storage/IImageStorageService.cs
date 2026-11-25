namespace MFMFMS.Application.Contracts.Storage
{
    public interface IImageStorageService
    {
        Task<string> SaveAsync(
            Stream fileStream,
            string fileName,
            long fileSize,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(string imagePath);
    }
}
