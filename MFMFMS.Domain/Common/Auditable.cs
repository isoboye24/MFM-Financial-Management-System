namespace MFMFMS.Domain.Common
{
    public abstract class Auditable
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreationTime { get; set; }
        public string? LastMofifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
