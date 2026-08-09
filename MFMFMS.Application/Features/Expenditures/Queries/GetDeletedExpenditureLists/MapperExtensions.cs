using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetDeletedExpenditureLists
{
    internal static class MapperExtensions
    {
        internal static DeletedExpenditureListDTO ToDTO(this Expenditure expenditure)
        {
            return new DeletedExpenditureListDTO
            {
                Id = expenditure.Id,
                Summary = expenditure.Summary,
                Amount = expenditure.Amount,
                Date = expenditure.Date
            };
        }
    }
}
