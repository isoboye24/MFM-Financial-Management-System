namespace MFMFMS.Domain.Common
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }
        DateTime? DeletedAt { get; }

        void Delete();
        void Restore();
    }
}
