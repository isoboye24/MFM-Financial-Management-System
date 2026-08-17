using MFMFMS.Domain.Common;
using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class Category : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public Category(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private Category()
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
                throw new BusinessRuleException("Category's name is required.");
            }
        }
    }
}
