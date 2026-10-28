using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Genders.GetGenderList;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Persistence.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly MFMFMSDBContext _db;

        public GenderRepository(MFMFMSDBContext db)
        {
            _db = db;
        }

        public Task<Gender?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Gender>> GetFiltered(GendersFilterDTO filter)
        {
            throw new NotImplementedException();
        }
    }
}
