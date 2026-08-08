using MFMFMS.Application.Features.Months.GetMonthsList;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IMonthRepository
    {
        Task<IEnumerable<Month>> GetFiltered(MonthsFilterDTO filter);

        Task<Month?> GetById(Guid id);

        Task<int> GetTotalAmountOfRecords();
    }
}
