using MFMFMS.Application.Features.Categories.Queries.GetCategoryLists;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;
using MFMFMS.Application.Features.Categories.Queries.GetDeletedCategoryLists;

namespace MFMFMS.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly MFMFMSDBContext _db;
        public CategoryRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string name)
        {
            var exists = await _db.Categories.Where(x => x.Name == name).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Category>> GetDeletedFiltered(DeletedCategoriesFilterDTO filter)
        {
            var query = _db.Categories.Where(x => x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetFiltered(CategoriesFilterDTO filter)
        {
            var query = _db.Categories.Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
