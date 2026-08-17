using MFMFMS.Application.Features.Expenditures.Queries.GetDeletedExpenditureLists;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IExpenditureRepository : IRepository<Expenditure>
    {
        Task<bool> Exists(string summary, DateTime date);
        Task<IEnumerable<Expenditure>> GetFiltered(ExpendituresFilterDTO filter);

        Task<IEnumerable<Expenditure>> GetDeletedFiltered(DeletedExpendituresFilterDTO filter);
    }
}
