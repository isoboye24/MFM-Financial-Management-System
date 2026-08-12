namespace MFMFMS.Application.Features.Givings.Queries.GetGivingLists
{
    internal static class MapperExtensions
    {
        internal static GivingListsDTO ToDTO(this Domain.Entities.Giving giving)
        {
            return new GivingListsDTO
            {
                Id = giving.Id,
                Amount = giving.Amount,
                Date = giving.Date,
                Summary = giving.Summary,
                CategoryName = giving.Category?.Name ?? string.Empty,
                MessageTitle = giving.Meeting?.MessageTitle ?? string.Empty
            };
        }
    }
}
