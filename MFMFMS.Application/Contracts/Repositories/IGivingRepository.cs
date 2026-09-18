using MFMFMS.Application.Features.Givings.Queries.GetAnnualGivingStatistics;
using MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists;
using MFMFMS.Application.Features.Givings.Queries.GetGivingLists;
using MFMFMS.Application.Features.Givings.Queries.GetGivingListsByMonthAndYear;
using MFMFMS.Application.Features.Givings.Queries.GetMonthlyGivingStatistics;
using MFMFMS.Application.Features.Givings.Queries.GetTotalGivingStatistics;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IGivingRepository : IRepository<Giving>
    {
        Task<bool> Exists(Guid MeetingId, Guid CategoryId, bool isDeleted = false);
        Task<IEnumerable<Giving>> GetFiltered(GivingsFilterDTO filter);
        Task<IEnumerable<Giving>> GetFilteredByMonthAndYear(GivingListsByMonthAndYearFilterDTO filter);
        Task<IEnumerable<Giving>> GetDeletedFiltered(DeletedGivingsFilterDTO filter);
        Task<Giving?> GetGivingDetail(Guid id);

        Task<TotalGivingStatisticsDTO> GetTotalGivingStatistics();
        Task<MonthlyGivingStatisticsDTO> GetMonthlyGivingStatistics(int month, int year);
        Task<AnnualGivingStatisticsDTO> GetAnnualGivingStatistics(int year);
    }
}
