using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists
{
    internal static class MapperExtensions
    {
        internal static ExpenditureListDTO ToDTO(this Expenditure expenditure)
        {
            return new ExpenditureListDTO
            {
                Id = expenditure.Id,
                Summary = expenditure.Summary,
                Amount = expenditure.Amount,
                Date = expenditure.Date
            };
        }
    }
}
