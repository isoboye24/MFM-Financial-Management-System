using MFMFMS.Application.Contracts.Persistence;

namespace MFMFMS.Persistence.UnitOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork 
    {
        private readonly MFMFMSDBContext _db;

        public UnitOfWorkEFCore(MFMFMSDBContext db)
        {
            _db = db;
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
