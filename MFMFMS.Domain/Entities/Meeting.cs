using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class Meeting : SoftDeletableEntity
    {
        public DateTime Date { get; private set; }
        public string? Summary { get; private set; } = string.Empty;
        public string MessageTitle { get; private set; } = string.Empty;
        public string Minister { get; private set; } = string.Empty;
        public int NoOfMaleAttendance { get; private set; }
        public int NoOfFemaleAttendance { get; private set; }
        public int NoOfChildrenAttendance { get; private set; }

        public Meeting(DateTime date, string? summary, string messageTitle, string minister, int noOfMaleAttendance, int noOfFemaleAttendance, int noOfChildrenAttendance)
        {
            ValidateAll(date, messageTitle, minister, noOfMaleAttendance, noOfFemaleAttendance, noOfChildrenAttendance);

            Date = date;
            Summary = summary?.Trim() ?? string.Empty;
            MessageTitle = messageTitle.Trim();
            Minister = minister.Trim();
            NoOfMaleAttendance = noOfMaleAttendance;
            NoOfFemaleAttendance = noOfFemaleAttendance;
            NoOfChildrenAttendance = noOfChildrenAttendance;
            Id = Guid.CreateVersion7();
        }

        private Meeting()
        {
            
        }

        private static void ValidateAll(DateTime date, string messageTitle, string minister, int noOfMaleAttendance, int noOfFemaleAttendance, int noOfChildrenAttendance)
        {
            ValidateDate(date);
            ValidateMessageTitle(messageTitle);
            ValidateMinister(minister);
            ValidateAttendance(noOfMaleAttendance, noOfFemaleAttendance, noOfChildrenAttendance);
        }

        private static void ValidateDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                throw new BusinessRuleException("Date is required.");
            }
        }

        public void UpdateDate(DateTime date)
        {
            ValidateDate(date);
            Date = date;
        }

        public void UpdateSummary(string? summary)
        {
            Summary = summary?.Trim() ?? string.Empty;
        }

        private static void ValidateMessageTitle(string messageTitle)
        {
            if (string.IsNullOrWhiteSpace(messageTitle))
            {
                throw new BusinessRuleException("Message Title is required.");
            }
        }

        public void UpdateMessageTitle(string messageTitle)
        {
            ValidateMessageTitle(messageTitle);
            MessageTitle = messageTitle.Trim();
        }

        private static void ValidateMinister(string minister)
        {
            if (string.IsNullOrWhiteSpace(minister))
            {
                throw new BusinessRuleException("Minister is required.");
            }
        }

        public void UpdateMinister(string minister)
        {
            ValidateMinister(minister);
            Minister = minister.Trim();
        }

        private static void ValidateAttendance(int noOfMaleAttendance, int noOfFemaleAttendance, int noOfChildrenAttendance)
        {
            if (noOfMaleAttendance < 0 || noOfFemaleAttendance < 0 || noOfChildrenAttendance < 0)
            {
                throw new BusinessRuleException("Attendance numbers cannot be negative.");
            }
        }

        public void UpdateAttendance(int noOfMaleAttendance, int noOfFemaleAttendance, int noOfChildrenAttendance)
        {
            ValidateAttendance(noOfMaleAttendance, noOfFemaleAttendance, noOfChildrenAttendance);

            NoOfMaleAttendance = noOfMaleAttendance;
            NoOfFemaleAttendance = noOfFemaleAttendance;
            NoOfChildrenAttendance = noOfChildrenAttendance;
        }
    }
}