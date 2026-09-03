using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Meetings.Queries.GetDeletedMeetingLists
{
    internal static class MapperExtensions
    {
        internal static DeletedMeetingListsDTO ToDTO(this Meeting meeting)
        {
            return new DeletedMeetingListsDTO
            {
                Id = meeting.Id,
                MessageTitle = meeting.MessageTitle,
                Date = meeting.Date,
                Summary = meeting.Summary,
                Minister = meeting.Minister,
                NoOfMaleAttendance = meeting.NoOfMaleAttendance,
                NoOfFemaleAttendance = meeting.NoOfFemaleAttendance,
                NoOfChildrenAttendance = meeting.NoOfChildrenAttendance,
                MeetingCategory = meeting.MeetingCategory?.Name ?? string.Empty
            };
        }
    }
}
