using MFMFMS.Application.Features.Categories.Queries.GetCategoryLists;
using MFMFMS.Application.Features.Categories.Queries.GetDeletedCategoryLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> Exists(string name);
        Task<IEnumerable<Category>> GetFiltered(CategoriesFilterDTO filter);

        Task<IEnumerable<Category>> GetDeletedFiltered(DeletedCategoriesFilterDTO filter);
    }
}
