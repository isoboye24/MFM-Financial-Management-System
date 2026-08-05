using MFMFMS.Application.Features.Categories.Queries.GetCategoryLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetFiltered(CategoriesFilterDTO filter);
    }
}
