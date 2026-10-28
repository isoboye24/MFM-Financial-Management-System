using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class Member : SoftDeletableEntity
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public Guid PositionId { get; private set; }
        public Position? Position { get; private set; }
        public Guid GenderId { get; private set; }
        public Gender? Gender { get; private set; }

        public Member(string firstName, string lastName, string address, string phoneNumber, Guid positionId, Guid genderId)
        {
            ValidateAll(firstName, lastName, address, phoneNumber, positionId, genderId);

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Address = address.Trim();
            PhoneNumber = phoneNumber.Trim();
            PositionId = positionId;
            GenderId = genderId;
            Id = Guid.CreateVersion7();
        }

        private Member()
        {

        }

        private static void ValidateAll(string firstName, string lastName, string address, string phoneNumber, Guid positionId, Guid genderId)
        {
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
            ValidateAddress(address);
            ValidatePhoneNumber(phoneNumber);
            ValidatePositionId(positionId);
            ValidateGenderId(genderId);
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
        
        private static void ValidateGenderId(Guid genderId)
        {
            if (genderId == Guid.Empty)
            {
                throw new BusinessRuleException("Gender is required.");
            }
        }

        public void UpdateGenderId(Guid genderId)
        {
            ValidateGenderId(genderId);
            GenderId = genderId;
        }
    }
}
