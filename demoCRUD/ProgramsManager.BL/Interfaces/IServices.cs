
namespace ProgramsManager.BL.Interfaces
{
    public interface IServices<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync<T>(T id, Guid? uid= null);

        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> CreateAsync(TEntity entity, Guid? id = null);

        Task<TEntity> UpdateAsync(Guid id, TEntity entity);

        Task<TEntity> DeleteAsync(Guid id);
    }
}
