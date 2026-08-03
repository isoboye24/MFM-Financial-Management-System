using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class Meeting
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Summary { get; private set; } = string.Empty;
        public string MessageTitle { get; private set; } = string.Empty;
        public string Minister { get; private set; } = string.Empty;
        public int NoOfMaleAttendance { get; private set; }
        public int NoOfFemaleAttendance { get; private set; }
        public int NoOfChildrenAttendance { get; private set; }

        public Meeting(DateTime date, string summary, string messageTitle, string minister, int noOfMaleAttendance, int noOfFemaleAttendance, int noOfChildrenAttendance)
        {
            ValidateAll(date, summary, messageTitle, minister, noOfMaleAttendance, noOfFemaleAttendance, noOfChildrenAttendance);
            Date = date;
            Summary = summary.Trim();
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

        private static void ValidateAll(DateTime date, string summary, string messageTitle, string minister, int noOfMaleAttendance, int noOfFemaleAttendance, int noOfChildrenAttendance)
        {
            ValidateDate(date);
            ValidateSummary(summary);
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

        private static void ValidateSummary(string summary)
        {
            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new BusinessRuleException("Summary is required.");
            }
        }
        
        private static void ValidateMessageTitle(string messageTitle)
        {
            if (string.IsNullOrWhiteSpace(messageTitle))
            {
                throw new BusinessRuleException("Message Title is required.");
            }
        }

        private static void ValidateMinister(string minister)
        {
            if (string.IsNullOrWhiteSpace(minister))
            {
                throw new BusinessRuleException("Minister is required.");
            }
        }

        private static void ValidateAttendance(int noOfMaleAttendance, int noOfFemaleAttendance, int noOfChildrenAttendance)
        {
            if (noOfMaleAttendance < 0 || noOfFemaleAttendance < 0 || noOfChildrenAttendance < 0)
            {
                throw new BusinessRuleException("Attendance numbers cannot be negative.");
            }
        }
    }
}