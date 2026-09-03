using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Meetings.Queries.GetMeetingDetail
{
    internal static class MapperExtensions
    {
        internal static MeetingDetailDTO ToDTO(this Meeting meeting)
        {
            return new MeetingDetailDTO
            {
                Id = meeting.Id,
                MessageTitle = meeting.MessageTitle,
                Date = meeting.Date,
                Summary = meeting.Summary,
                Minister = meeting.Minister,
                NoOfMaleAttendance = meeting.NoOfMaleAttendance,
                NoOfFemaleAttendance = meeting.NoOfFemaleAttendance,
                NoOfChildrenAttendance = meeting.NoOfChildrenAttendance,
                MeetingCategoryId = meeting.MeetingCategoryId
            };
        }
    }
}
