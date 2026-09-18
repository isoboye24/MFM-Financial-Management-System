using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Features.Givings.Queries.GetAnnualGivingStatistics;
using MFMFMS.Application.Features.Givings.Queries.GetDeletedGivingLists;
using MFMFMS.Application.Features.Givings.Queries.GetGivingLists;
using MFMFMS.Application.Features.Givings.Queries.GetGivingListsByMonthAndYear;
using MFMFMS.Application.Features.Givings.Queries.GetMonthlyGivingStatistics;
using MFMFMS.Application.Features.Givings.Queries.GetTotalGivingStatistics;
using MFMFMS.Domain.Entities;
using MFMFMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence.Repositories
{
    public class GivingRepository : Repository<Giving>, IGivingRepository
    {
        private readonly MFMFMSDBContext _db;
        public GivingRepository(MFMFMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> Exists(Guid meetingId, Guid categoryId, bool isDeleted = false)
        {
            var exists = await _db.Givings.Where(x => x.MeetingId == meetingId && x.CategoryId == categoryId && x.IsDeleted == isDeleted).AnyAsync();

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Giving>> GetDeletedFiltered(DeletedGivingsFilterDTO filter)
        {
            var query = _db.Givings.Where(x => x.IsDeleted).AsQueryable();

            if (filter.MeetingId.HasValue)
            {
                query = query.Where(p => p.MeetingId == filter.MeetingId.Value);
            }
            
            if (filter.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);
            }
            
            return await query
                .Include(x => x.Category)
                .Include(x => x.Meeting)
                .OrderBy(x => x.Date)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Giving>> GetFiltered(GivingsFilterDTO filter)
        {
            var query = _db.Givings.Where(x => !x.IsDeleted).AsQueryable();

            if (filter.MeetingId.HasValue)
            {
                query = query.Where(p => p.MeetingId == filter.MeetingId.Value);
            }

            if (filter.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);
            }

            return await query
                .Include(x => x.Category)
                .Include(x => x.Meeting)
                .OrderBy(x => x.Date)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }

        public async Task<Giving?> GetGivingDetail(Guid id)
        {
            return await _db.Givings
                           .Include(x => x.Meeting)
                           .Include(x => x.Category)
                           .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MonthlyGivingStatisticsDTO> GetMonthlyGivingStatistics(int month, int year)
        {
            var statistics = await _db.Givings
                                    .Where(x => !x.IsDeleted && x.Date.Month == month && x.Date.Year == year)
                                    .GroupBy(x => x.Category!.Name)
                                    .Select(g => new
                                    {
                                        CategoryName = g.Key,
                                        Total = g.Sum(x => x.Amount)
                                    })
                                    .ToListAsync();

            return new MonthlyGivingStatisticsDTO
            {
                MonthlyTithes = statistics
                    .Where(x => x.CategoryName == "Tithe")
                    .Select(x => x.Total)
                    .FirstOrDefault(),

                MonthlyOfferings = statistics
                    .Where(x => x.CategoryName == "Offering")
                    .Select(x => x.Total)
                    .FirstOrDefault(),

                MonthlySeeds = statistics
                    .Where(x => x.CategoryName == "Seed")
                    .Select(x => x.Total)
                    .FirstOrDefault(),

                MonthlyOtherIncome = statistics
                    .Where(x => x.CategoryName == "Other Income")
                    .Select(x => x.Total)
                    .FirstOrDefault()
            };
        }

        public async Task<AnnualGivingStatisticsDTO> GetAnnualGivingStatistics(int year)
        {
            var statistics = await _db.Givings
                                    .Where(x => !x.IsDeleted && x.Date.Year == year)
                                    .GroupBy(x => x.Category!.Name)
                                    .Select(g => new
                                    {
                                        CategoryName = g.Key,
                                        Total = g.Sum(x => x.Amount)
                                    })
                                    .ToListAsync();

            return new AnnualGivingStatisticsDTO
            {
                AnnualTithes = statistics
                    .Where(x => x.CategoryName == "Tithe")
                    .Select(x => x.Total)
                    .FirstOrDefault(),

                AnnualOfferings = statistics
                    .Where(x => x.CategoryName == "Offering")
                    .Select(x => x.Total)
                    .FirstOrDefault(),

                AnnualSeeds = statistics
                    .Where(x => x.CategoryName == "Seed")
                    .Select(x => x.Total)
                    .FirstOrDefault(),

                AnnualOtherIncome = statistics
                    .Where(x => x.CategoryName == "Other Income")
                    .Select(x => x.Total)
                    .FirstOrDefault()
            };
        }

        public async Task<TotalGivingStatisticsDTO> GetTotalGivingStatistics()
        {
            var statistics = await _db.Givings
                                    .Where(x => !x.IsDeleted)
                                    .GroupBy(x => x.Category!.Name)
                                    .Select(g => new
                                    {
                                        CategoryName = g.Key,
                                        Total = g.Sum(x => x.Amount)
                                    })
                                    .ToListAsync();

            return new TotalGivingStatisticsDTO
            {
                TotalTithes = statistics
                    .Where(x => x.CategoryName == "Tithe")
                    .Select(x => x.Total)
                    .FirstOrDefault(),

                TotalOfferings = statistics
                    .Where(x => x.CategoryName == "Offering")
                    .Select(x => x.Total)
                    .FirstOrDefault(),

                TotalSeeds = statistics
                    .Where(x => x.CategoryName == "Seed")
                    .Select(x => x.Total)
                    .FirstOrDefault(),

                TotalOtherIncome = statistics
                    .Where(x => x.CategoryName == "Other Income")
                    .Select(x => x.Total)
                    .FirstOrDefault()
            };
        }

        public async Task<IEnumerable<Giving>> GetFilteredByMonthAndYear(GivingListsByMonthAndYearFilterDTO filter)
        {
            var query = _db.Givings.Where(x => !x.IsDeleted).AsQueryable();

            if (filter.Month.HasValue)
            {
                query = query.Where(x =>
                    x.Date.Month == filter.Month.Value);
            }

            if (filter.Year.HasValue)
            {
                query = query.Where(x =>
                    x.Date.Year == filter.Year.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.CategoryName))
            {
                query = query.Where(x =>
                    x.Category != null &&
                    x.Category.Name == filter.CategoryName);
            }


            return await query
                .Include(x => x.Category)
                .Include(x => x.Meeting)
                .Include(x => x.Meeting!.MeetingCategory)
                .OrderByDescending(x => x.Date)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
