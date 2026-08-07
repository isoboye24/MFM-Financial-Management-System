using MFMFMS.Application.Features.Positions.Queries.GetDeletedPositionLists;
using MFMFMS.Application.Features.Positions.Queries.GetPositionLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<IEnumerable<Position>> GetFiltered(PositionFilterDTO filter);

        Task<IEnumerable<Position>> GetDeletedFiltered(DeletedPositionsFilterDTO filter);
    }
}
