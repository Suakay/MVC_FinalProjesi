using MVC_FinalProje.Domain.Core.BaseEntities;
using System.Linq.Expressions;

namespace MVCFinalProje.Infrastucre.DataAccess
{
    public interface IAsyncFindable<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AnyAsync(Expression<Func<TEntity,bool>>expression=null);
        Task<TEntity?>GetByIdAsync(Guid id,bool tracing =true);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking= true);
    }
}