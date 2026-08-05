using MFMFMS.Application.Features.Categories.Queries.GetCategoryLists;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly MFMFMSDBContext _db;
        public CategoryRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> GetFiltered(CategoriesFilterDTO filter)
        {
            var query = _db.Categories.AsQueryable();

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
