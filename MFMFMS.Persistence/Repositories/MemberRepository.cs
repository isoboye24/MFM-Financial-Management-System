using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Members.Queries.GetDeletedMemberLists;
using MFMFMS.Application.Features.Members.Queries.GetMemberLists;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        private readonly MFMFMSDBContext _db;
        public MemberRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string FirstName, string LastName, string PhoneNumber)
        {
            var exists = await _db.Members.Where(x => x.FirstName == FirstName && x.LastName == LastName && x.PhoneNumber == PhoneNumber).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Member>> GetFiltered(MembersFilterDTO filter)
        {
            var query = _db.Members.Where(x => !x.IsDeleted).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.FirstName))
            {
                query = query.Where(p => p.FirstName.Contains(filter.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(filter.LastName))
            {
                query = query.Where(p => p.LastName.Contains(filter.LastName));
            }

            if (!string.IsNullOrWhiteSpace(filter.Address))
            {
                query = query.Where(p => p.Address.Contains(filter.Address));
            }

            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
            {
                query = query.Where(p => p.PhoneNumber.Contains(filter.PhoneNumber));
            }

            if (filter.PositionId != Guid.Empty)
            {
                query = query.Where(p => p.PositionId == filter.PositionId);
            }

            return await query
                .Include(x => x.Position)
                .OrderBy(x => x.FirstName)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Member>> GetDeletedFiltered(DeletedMembersFilterDTO filter)
        {
            var query = _db.Members.Where(x => x.IsDeleted).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.FirstName))
            {
                query = query.Where(p => p.FirstName.Contains(filter.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(filter.LastName))
            {
                query = query.Where(p => p.LastName.Contains(filter.LastName));
            }

            if (!string.IsNullOrWhiteSpace(filter.Address))
            {
                query = query.Where(p => p.Address.Contains(filter.Address));
            }

            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
            {
                query = query.Where(p => p.PhoneNumber.Contains(filter.PhoneNumber));
            }

            if (filter.PositionId != Guid.Empty)
            {
                query = query.Where(p => p.PositionId == filter.PositionId);
            }

            return await query
                .Include(x => x.Position)
                .OrderBy(x => x.FirstName)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<Member?> GetMemberDetail(Guid id)
        {
            return await _db.Members
                           .Include(x => x.Position)
                           .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
