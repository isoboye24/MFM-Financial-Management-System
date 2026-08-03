using MFMFMS.Domain.Exceptions;

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

        public Member(string firstName, string lastName, string address, string phoneNumber, Guid positionId)
        {
            ValidateAll(firstName, lastName, address, phoneNumber, positionId);

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Address = address.Trim();
            PhoneNumber = phoneNumber.Trim();
            PositionId = positionId;
            Id = Guid.CreateVersion7();
        }

        private Member()
        {

        }

        private static void ValidateAll(string firstName, string lastName, string address, string phoneNumber, Guid positionId)
        {
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
            ValidateAddress(address);
            ValidatePhoneNumber(phoneNumber);
            ValidatePositionId(positionId);
        }

        private static void ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new BusinessRuleException("First Name is required.");
            }
        }

        public void UpdateFirstName(string firstName)
        {
            ValidateFirstName(firstName);
            FirstName = firstName.Trim();
        }

        private static void ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new BusinessRuleException("Last Name is required.");
            }
        }

        public void UpdateLastName(string lastName)
        {
            ValidateLastName(lastName);
            LastName = lastName.Trim();
        }

        private static void ValidateAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new BusinessRuleException("Address is required.");
            }
        }

        public void UpdateAddress(string address)
        {
            ValidateAddress(address);
            Address = address.Trim();
        }

        private static void ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new BusinessRuleException("Phone Number is required.");
            }
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            ValidatePhoneNumber(phoneNumber);
            PhoneNumber = phoneNumber.Trim();
        }

        private static void ValidatePositionId(Guid positionId)
        {
            if (positionId == Guid.Empty)
            {
                throw new BusinessRuleException("Position is required.");
            }
        }

        public void UpdatePositionId(Guid positionId)
        {
            ValidatePositionId(positionId);
            PositionId = positionId;
        }
    }
}
