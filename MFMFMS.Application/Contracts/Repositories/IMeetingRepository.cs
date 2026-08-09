using MFMFMS.Application.Features.Meetings.Queries.GetDeletedMeetingLists;
using MFMFMS.Application.Features.Meetings.Queries.GetMeetingLists;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
        Task<IEnumerable<Meeting>> GetFiltered(MeetingsFilterDTO filter);
        Task<IEnumerable<Meeting>> GetDeletedFiltered(DeletedMeetingsFilterDTO filter);
    }
}
