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
    }
}
