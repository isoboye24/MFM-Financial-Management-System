using MFMFMS.Application.Features.Members.Queries.GetDeletedMemberLists;
using MFMFMS.Application.Features.Members.Queries.GetMemberLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<IEnumerable<Member>> GetFiltered(MembersFilterDTO filter);
        Task<IEnumerable<Member>> GetDeletedFiltered(DeletedMembersFilterDTO filter);
    }
}
