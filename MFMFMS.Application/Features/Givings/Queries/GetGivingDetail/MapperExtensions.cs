using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Givings.Queries.GetGivingDetail
{
    internal static class MapperExtensions
    {
        internal static GivingDetailDTO ToDTO(this Giving giving)
        {
            return new GivingDetailDTO
            {
                Id = giving.Id,
                Amount = giving.Amount,
                Date = giving.Meeting?.Date ?? default,
                Summary = giving.Summary,
                CategoryName = giving.Category?.Name ?? string.Empty,
                MessageTitle = giving.Meeting?.MessageTitle ?? string.Empty,
                Minister = giving.Meeting?.Minister ?? string.Empty,
                MeetingId = giving.MeetingId,
                CategoryId = giving.CategoryId,
                NoOfMaleAttendance = giving.Meeting?.NoOfMaleAttendance ?? 0,
                NoOfFemaleAttendance = giving.Meeting?.NoOfFemaleAttendance ?? 0,
                NoOfChildrenAttendance = giving.Meeting?.NoOfChildrenAttendance ?? 0
            };
        }
    }
}
