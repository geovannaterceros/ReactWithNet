
namespace ProgramsManager.DAL.Interfaces
{
    public interface IDataAccess<TEntity> 
    {
        Task<IEnumerable<TEntity>> GetAsync<TId>(TId id, Guid? uid= null);

        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> CreateAsync(TEntity entity, Guid? uid = null);

        Task<TEntity> UpdateAsync(Guid id,TEntity entity);

        Task<TEntity> DeleteAsync(Guid id);
    }
}
