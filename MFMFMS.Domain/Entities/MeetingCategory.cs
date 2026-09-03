using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class MeetingCategory : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public MeetingCategory(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private MeetingCategory()
        {

        }

        public void UpdateName(string name)
        {
            ValidateName(name);
            Name = name;
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException("Meeting category's name is required.");
            }
        }
    }
}
