namespace Project.Domail.Abstractions.QueryRepositories.Base
{
    public interface IQueryRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> IsInExistsAsync(Guid id);
        // Generic repository for all if any
    }
}
