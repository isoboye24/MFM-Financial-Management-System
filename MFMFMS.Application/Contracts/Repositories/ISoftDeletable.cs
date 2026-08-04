namespace MFMFMS.Application.Contracts.Repositories
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }
        DateTime? DeletedAt { get; }

        void Delete();
        void Restore();
    }
}
