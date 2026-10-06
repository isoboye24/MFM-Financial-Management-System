using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingListsByMonthAndYear
{
    internal static class MapperExtensions
    {
        internal static MeetingListsByMonthAndYearDTO ToDTO(this Meeting meeting)
        {
            return new MeetingListsByMonthAndYearDTO
            {
                Id = meeting.Id,
                MessageTitle = meeting.MessageTitle,
                Date = meeting.Date,
                Summary = meeting.Summary,
                Minister = meeting.Minister,
                NoOfMaleAttendance = meeting.NoOfMaleAttendance,
                NoOfFemaleAttendance = meeting.NoOfFemaleAttendance,
                NoOfChildrenAttendance = meeting.NoOfChildrenAttendance,
                MeetingCategoryId = meeting.MeetingCategoryId,
                MeetingCategory = meeting.MeetingCategory?.Name ?? string.Empty
            };
        }
    }
}
