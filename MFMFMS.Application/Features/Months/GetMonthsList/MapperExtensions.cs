using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Months.GetMonthsList
{
    internal static class MapperExtensions
    {
        internal static MonthListsDTO ToDTO(this Month month)
        {
            return new MonthListsDTO
            {
                Id = month.Id,
                Name = month.Name
            };
        }
    }
}
