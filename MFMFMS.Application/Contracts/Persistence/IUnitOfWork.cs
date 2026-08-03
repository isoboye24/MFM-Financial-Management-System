namespace MFMFMS.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}
