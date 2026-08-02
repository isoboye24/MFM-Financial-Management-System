using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class Position
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public Position(string name)
        {
            ValidateName(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        private Position()
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
                throw new BusinessRuleException("Position's name is required.");
            }
        }
    }
}
