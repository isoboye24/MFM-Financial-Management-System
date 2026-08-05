namespace MFMFMS.Application.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllDeleted();
        Task<T?> GetById(Guid id);
        Task<T?> GetBack(Guid id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task DeletePermanently(T entity);
        Task<int> GetTotalAmountOfRecords();
    }
}
