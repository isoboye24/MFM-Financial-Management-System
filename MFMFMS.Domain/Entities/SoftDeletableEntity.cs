using MFMFMS.Domain.Common;

namespace MFMFMS.Domain.Entities
{
    public class SoftDeletableEntity : Entity, ISoftDeletable
    {
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public virtual void Delete()
        {
            if (IsDeleted)
                return;

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        public virtual void Restore()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
