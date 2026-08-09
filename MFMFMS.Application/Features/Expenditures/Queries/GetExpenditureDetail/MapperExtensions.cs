using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureDetail
{
    internal static class MapperExtensions
    {
        internal static ExpenditureDetailDTO ToDTO(this Expenditure expenditure)
        {
            return new ExpenditureDetailDTO
            {
                Id = expenditure.Id,
                Summary = expenditure.Summary,
                Amount = expenditure.Amount,
                Date = expenditure.Date
            };
        }
    }
}
