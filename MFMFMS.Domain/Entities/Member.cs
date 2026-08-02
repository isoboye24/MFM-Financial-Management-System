namespace MFMFMS.Domain.Entities
{
    public class Member
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public Guid PositionId { get; private set; }
        public Position? Position { get; private set; }
    }
}
