using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace MFMFMS.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : SoftDeletableEntity
    {
        private readonly MFMFMSDBContext _db;

        public Repository(MFMFMSDBContext db)
        {
            _db = db;
        }

        public Task<T> Add(T entity)
        {
            _db.Add(entity);
            return Task.FromResult(entity);
        }

        public Task Delete(T entity)
        {
            entity.Delete();

            _db.Update(entity);

            return Task.CompletedTask;
        }

        public Task DeletePermanently(T entity)
        {
            _db.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>()
                        .Where(x => !x.IsDeleted)
                        .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllDeleted()
        {
            return await _db.Set<T>()
                        .Where(x => x.IsDeleted)
                        .ToListAsync();
        }

        public async Task<T?> GetBack(Guid id)
        {
            return await _db.Set<T>()
                        .IgnoreQueryFilters()
                        .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted);
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<int> GetTotalAmountOfRecords()
        {
            return await _db.Set<T>().CountAsync();
        }

        public Task Update(T entity)
        {
            _db.Update(entity);
            return Task.CompletedTask;
        }
    }
}
