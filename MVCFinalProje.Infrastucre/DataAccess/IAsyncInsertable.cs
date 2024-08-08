using MVC_FinalProje.Domain.Core.BaseEntities;

namespace MVCFinalProje.Infrastucre.DataAccess
{
    public interface IAsyncInsertable<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entity); // Dönüş yok
    }
}