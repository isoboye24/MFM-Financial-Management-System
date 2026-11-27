using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Members.Queries.GetDeletedMemberLists;
using MFMFMS.Application.Features.Members.Queries.GetMemberLists;
using MFMFMS.Application.Features.Members.Queries.GetTotalMemberStatistics;
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

        public async Task<bool> Exists(string FirstName, string LastName, string PhoneNumber, bool isDeleted = false)
        {
            var exists = await _db.Members.Where(x => x.FirstName == FirstName && x.LastName == LastName && x.PhoneNumber == PhoneNumber && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> IsImagePathInUse(string imagePath)
        {
            return await _db.Members.AnyAsync(x => x.ImagePath == imagePath);
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

            if (filter.PositionId != Guid.Empty)
            {
                query = query.Where(p => p.PositionId == filter.PositionId);
            }
            
            if (filter.GenderId != Guid.Empty)
            {
                query = query.Where(p => p.GenderId == filter.GenderId);
            }

            return await query
                .Include(x => x.Gender)
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

            if (filter.PositionId.HasValue)
            {
                query = query.Where(p => p.PositionId == filter.PositionId.Value);
            }
            if (filter.GenderId != Guid.Empty)
            {
                query = query.Where(p => p.GenderId == filter.GenderId);
            }

            return await query
                .Include(x => x.Gender)
                .Include(x => x.Position)
                .OrderBy(x => x.FirstName)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<Member?> GetMemberDetail(Guid id)
        {
            return await _db.Members
                           .Include(x => x.Gender)
                           .Include(x => x.Position)
                           .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TotalMemberStatisticsDTO> GetTotalMemberStatistics()
        {
            var sixMonthsAgo = DateTime.UtcNow.AddMonths(-6);

            var statistics = await _db.Members
                .Where(x => !x.IsDeleted)
                .GroupBy(x => x.Gender!.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Total = g.Count()
                })
                .ToListAsync();

            var totalWorkers = await _db.Members
                .CountAsync(x => !x.IsDeleted);

            var totalNewWorkers = await _db.Members
                .CountAsync(x =>
                    !x.IsDeleted &&
                    x.CreationTime >= sixMonthsAgo);

            return new TotalMemberStatisticsDTO
            {
                TotalMaleWorkers = statistics
                    .Where(x => x.Name == "Male")
                    .Select(x => (decimal)x.Total)
                    .FirstOrDefault(),

                TotalFemaleWorkers = statistics
                    .Where(x => x.Name == "Female")
                    .Select(x => (decimal)x.Total)
                    .FirstOrDefault(),

                TotalNewWorkers = totalNewWorkers,
                TotalWorkers = totalWorkers
            };
        }
    }
}
