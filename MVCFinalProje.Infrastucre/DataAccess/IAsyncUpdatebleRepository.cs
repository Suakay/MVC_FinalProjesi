using MVC_FinalProje.Domain.Core.BaseEntities;

namespace MVCFinalProje.Infrastucre.DataAccess
{
     public interface IAsyncUpdatebleRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}