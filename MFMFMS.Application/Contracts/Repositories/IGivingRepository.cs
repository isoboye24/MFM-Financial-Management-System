using MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists;
using MFMFMS.Application.Features.Givings.Queries.GetGivingLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IGivingRepository : IRepository<Giving>
    {
        Task<bool> Exists(Guid MeetingId, Guid CategoryId);
        Task<IEnumerable<Giving>> GetFiltered(GivingsFilterDTO filter);
        Task<IEnumerable<Giving>> GetDeletedFiltered(DeletedGivingsFilterDTO filter);
        Task<Giving?> GetGivingDetail(Guid id);
    }
}
