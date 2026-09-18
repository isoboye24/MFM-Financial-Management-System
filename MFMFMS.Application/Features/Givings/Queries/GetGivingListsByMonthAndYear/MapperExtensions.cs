using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Givings.Queries.GetGivingListsByMonthAndYear
{
    internal static class MapperExtensions
    {
        internal static GivingListsByMonthAndYearDTO ToDTO(this Giving giving)
        {
            return new GivingListsByMonthAndYearDTO
            {
                Id = giving.Id,
                Amount = giving.Amount,
                Date = giving.Date,
                CategoryId = giving.CategoryId,
                CategoryName = giving.Category?.Name ?? string.Empty,
                MeetingId = giving.MeetingId,
                MessageTitle = giving.Meeting?.MessageTitle ?? string.Empty,
                Minister = giving.Meeting?.Minister ?? string.Empty,
                MeetingCategoryId = giving.Meeting?.MeetingCategoryId ?? Guid.Empty,
                MeetingCategoryName = giving.Meeting?.MeetingCategory?.Name ?? string.Empty
            };
        }
    }
}
