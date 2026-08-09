using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingLists
{
    internal static class MapperExtensions
    {
        internal static MeetingListsDTO ToDTO(this Meeting meeting)
        {
            return new MeetingListsDTO
            {
                Id = meeting.Id,
                Date = meeting.Date,
                Summary = meeting.Summary,
                MessageTitle = meeting.MessageTitle,
                Minister = meeting.Minister,
                NoOfMaleAttendance = meeting.NoOfMaleAttendance,
                NoOfFemaleAttendance = meeting.NoOfFemaleAttendance,
                NoOfChildrenAttendance = meeting.NoOfChildrenAttendance
            };
        }
    }
}
