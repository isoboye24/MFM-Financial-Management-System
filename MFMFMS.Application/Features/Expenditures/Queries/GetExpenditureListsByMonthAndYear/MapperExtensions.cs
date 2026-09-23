using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureListsByMonthAndYear
{
    internal static class MapperExtensions
    {
        internal static ExpenditureListsByMonthAndYearDTO ToDTO(this Expenditure expenditure)
        {
            return new ExpenditureListsByMonthAndYearDTO
            {
                Id = expenditure.Id,
                Amount = expenditure.Amount,
                Date = expenditure.Date,
                Summary = expenditure.Summary
            };
        }
    }
}
