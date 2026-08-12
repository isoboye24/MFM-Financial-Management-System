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
                Date = giving.Date,
                Summary = giving.Summary,
                CategoryName = giving.Category?.Name ?? string.Empty,
                MessageTitle = giving.Meeting?.MessageTitle ?? string.Empty,
            };
        }
    }
}
