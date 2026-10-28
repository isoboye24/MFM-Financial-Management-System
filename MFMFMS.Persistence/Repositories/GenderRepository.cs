using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Genders.GetGenderList;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly MFMFMSDBContext _db;

        public GenderRepository(MFMFMSDBContext db)
        {
            _db = db;
        }

        public async Task<Gender?> GetById(Guid id)
        {
            return await _db.Genders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Gender>> GetFiltered(GendersFilterDTO filter)
        {
            var query = _db.Genders.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(x =>
                    x.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
