using MFMFMS.Application.Features.Genders.GetGenderList;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetFiltered(GendersFilterDTO filter);
        Task<Gender?> GetById(Guid id);
    }
}
