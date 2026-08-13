using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists
{
    internal static class MapperExtensions
    {
        internal static DeletedGivingListsDTO ToDTO(this Giving giving)
        {
            return new DeletedGivingListsDTO
            {
                Id = giving.Id,
                Amount = giving.Amount,
                Date = giving.Date,
                Summary = giving.Summary,
                MessageTitle = giving.Meeting?.MessageTitle ?? string.Empty,
                CategoryName = giving.Category?.Name ?? string.Empty
            };
        }
    }
}
