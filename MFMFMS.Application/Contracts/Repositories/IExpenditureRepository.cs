using MFMFMS.Application.Features.Expenditures.Queries.GetAnnualExpenditureStatistics;
using MFMFMS.Application.Features.Expenditures.Queries.GetDeletedExpenditureLists;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureLists;
using MFMFMS.Application.Features.Expenditures.Queries.GetExpenditureListsByMonthAndYear;
using MFMFMS.Application.Features.Expenditures.Queries.GetMonthlyExpendituresStatistics;
using MFMFMS.Application.Features.Expenditures.Queries.GetTotalExpenditureStatistics;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IExpenditureRepository : IRepository<Expenditure>
    {
        Task<bool> Exists(string summary, DateTime date, bool isDeleted = false);
        Task<IEnumerable<Expenditure>> GetFiltered(ExpendituresFilterDTO filter);
        Task<IEnumerable<Expenditure>> GetDeletedFiltered(DeletedExpendituresFilterDTO filter);
        Task<IEnumerable<Expenditure>> GetFilteredByMonthAndYear(ExpenditureListsByMonthAndYearFilterDTO filter);

        Task<TotalExpendituresStatisticsDTO> GetTotalExpenditureStatistics();
        Task<MonthlyExpendituresStatisticsDTO> GetMonthlyExpenditureStatistics(int month, int year);
        Task<AnnualExpendituresStatisticsDTO> GetAnnualExpenditureStatistics(int year);
    }
}
