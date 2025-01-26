
using System.Linq.Expressions;

namespace MeetingRoomBookingSystem.Domain.RepositoryContracts
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : class
        where TKey : IComparable
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IList<TEntity>> GetAllAsync();
        Task EditAsync(TEntity entityToUpdate);
        Task RemoveAsync(TKey id);
        Task RemoveAsync(TEntity entityToDelete);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

    }
}
