using MFMFMS.Application.Features.MeetingCategories.Queries.GetDeletedMeetingCategoryLists;
using MFMFMS.Application.Features.MeetingCategories.Queries.GetMeetingCategoryLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IMeetingCategoryRepository : IRepository<MeetingCategory>
    {
        Task<bool> Exists(string name, bool isDeleted = false);
        Task<IEnumerable<MeetingCategory>> GetFiltered(MeetingCategoriesFilterDTO filter);

        Task<IEnumerable<MeetingCategory>> GetDeletedFiltered(DeletedMeetingCategoriesFilterDTO filter);
    }
}
