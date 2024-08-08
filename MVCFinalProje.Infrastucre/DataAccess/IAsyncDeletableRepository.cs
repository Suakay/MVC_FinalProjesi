using MVC_FinalProje.Domain.Core.BaseEntities;

namespace MVCFinalProje.Infrastucre.DataAccess
{
    public interface IAsyncDeletableRepository<TEntity> where TEntity : BaseEntity
    {
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}